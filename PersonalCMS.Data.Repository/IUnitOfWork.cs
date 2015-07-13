using PersonalCMS.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Repository
{
    public interface IUnitOfWork<TEntity>:IDisposable where TEntity : BaseEntity
    {
        void RegisterInsert(TEntity entity);
        void RegisterUpdate(TEntity entity);
        void RegisterDelete(TEntity entity);
        void SaveChanges();
        void RollBack();
    }
}
