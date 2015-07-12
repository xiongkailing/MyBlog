using PersonalCMS.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Repository
{
    interface IRepositoryContext : IUnitOfWork,IDisposable
    {
        void RegisterNew<TAggregateRoot>(TAggregateRoot obj)
           where TAggregateRoot : BaseEntity;

        void RegisterModified<TAggregateRoot>(TAggregateRoot obj)
           where TAggregateRoot : BaseEntity;

        void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj)
            where TAggregateRoot : BaseEntity;


    }
}
