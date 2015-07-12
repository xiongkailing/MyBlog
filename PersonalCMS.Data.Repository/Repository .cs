using PersonalCMS.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext db;
        public Repository(IDbContext context)
        {
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

        public void Insert(TEntity entity, bool isSave = true)
        {
            entity.CreateTime = DateTime.Now;
            entity.UpdateTime = DateTime.Now;
            entity.IsDeleted = false;
            this.db.Set<TEntity>().Add(entity);
            if (isSave)
            {
                this.db.SaveChanges();
            }
        }

        public void Update(TEntity entity, bool isSave = true)
        {
            this.db.Entry<TEntity>(entity).State = EntityState.Modified;
            entity.UpdateTime = DateTime.Now;
            if (isSave)
            {
                this.db.SaveChanges();
            }
        }

        public void Delete(int id, bool isSave = true)
        {
            var entity = this.db.Set<TEntity>().Find(id);
            if (entity == null)
                return;
            entity.IsDeleted = true;
            entity.DeleteTime = DateTime.Now;
            this.db.Entry<TEntity>(entity).State = EntityState.Modified;
            this.db.SaveChanges();
        }
    }
}
