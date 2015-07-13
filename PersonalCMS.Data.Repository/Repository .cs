using PersonalCMS.Data.Model;
using PersonalCMS.Infrastructure.Serilaizor;
using PersonalCMS.Infrastructure.SystemLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PersonalCMS.Data.Repository
{
    public class Repository<TEntity> : IUnitOfWork<TEntity>, IRepository<TEntity> where TEntity : BaseEntity
    {
        private IList<TEntity> addEntities;
        private IList<TEntity> updateEntities;
        private IList<TEntity> deleteEntities;
        private bool disposed = false;

        private readonly DbContext db;
        public Repository(IDbContext context)
        {
            addEntities = new List<TEntity>();
            updateEntities = new List<TEntity>();
            deleteEntities = new List<TEntity>();
            this.db = context.dbContext;
        }
        public IQueryable<TEntity> Get()
        {
            return this.db.Set<TEntity>().Where(e => !e.IsDeleted);
        }

        public TEntity GetById(int id)
        {
            return this.db.Set<TEntity>().Where(e => !e.IsDeleted).SingleOrDefault(e => e.Id == id);
        }

        public void Insert(TEntity entity, bool IsCommit = true)
        {
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            entity.IsDeleted = false;
            this.db.Set<TEntity>().Add(entity);
            if (IsCommit)
                this.db.SaveChanges();
        }

        public void Update(TEntity entity, bool IsCommit = true)
        {
            this.db.Entry<TEntity>(entity).State = EntityState.Modified;
            entity.UpdateTime = DateTime.Now;
            if (IsCommit)
                this.db.SaveChanges();
        }

        public void Delete(int id, bool IsCommit = true)
        {
            var entity = this.db.Set<TEntity>().Find(id);
            if (entity == null)
                return;
            Delete(entity, IsCommit);
        }

        public void Delete(TEntity entity, bool IsCommit = true)
        {
            entity.IsDeleted = true;
            entity.DeleteTime = DateTime.Now;
            this.db.Entry<TEntity>(entity).State = EntityState.Modified;
            if (IsCommit)
                this.db.SaveChanges();
        }

        public void RegisterInsert(TEntity entity)
        {
            this.addEntities.Add(entity);
        }

        public void RegisterUpdate(TEntity entity)
        {
            this.updateEntities.Add(entity);
        }

        public void RegisterDelete(TEntity entity)
        {
            this.deleteEntities.Add(entity);
        }

        public void SaveChanges()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (var entity in this.addEntities)
                {
                    Insert(entity, false);
                }

                foreach (var entity in this.updateEntities)
                {
                    Update(entity);
                }

                foreach (var entity in this.deleteEntities)
                {
                    Delete(entity);
                }
                try
                {
                    this.db.SaveChanges();
                }
                catch (Exception ex)
                {
                    RollBack();
                    Log.Instance.WriteLog(NLog.LogLevel.Fatal, "执行数据库操作时发生错误,该操作已经回滚,实体对象相见回滚日志", ex);
                }
                scope.Complete();
            }
        }

        public void RollBack()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Add:{0};Update:{1};Delete:{2}",
                JsonHelper.JsonSerliarize<IEnumerable<TEntity>>(this.addEntities),
                JsonHelper.JsonSerliarize<IEnumerable<TEntity>>(this.updateEntities),
                JsonHelper.JsonSerliarize<IEnumerable<TEntity>>(this.deleteEntities));
            Log.Instance.WriteLog(NLog.LogLevel.Fatal, sb.ToString());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~Repository()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                this.db.Dispose();
                this.addEntities = null;
                this.deleteEntities = null;
                this.updateEntities = null;
            }
            //让类型知道自己已经被释放
            disposed = true;
        }

    }
}
