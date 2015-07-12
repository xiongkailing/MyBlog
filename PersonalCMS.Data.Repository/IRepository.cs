using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        TEntity GetById(int id);
        void Insert(TEntity entity, bool isSave = true);
        void Update(TEntity entity, bool isSave = true);
        void Delete(int id, bool isSave = true);
    }
}
