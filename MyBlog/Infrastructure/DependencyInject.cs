using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using PersonalCMS.Data.Services;
using PersonalCMS.Data.Repository;

namespace MyBlog.Infrastructure
{
    public class DependencyInject
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<CmsDBContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
        }

    }
}