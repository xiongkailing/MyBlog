using NLog;
using PersonalCMS.Console;
using PersonalCMS.Data.Model;
using PersonalCMS.Data.Repository;
using PersonalCMS.Infrastructure.SystemLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CmsDBcontext())
            {
                UserRepository repository = new UserRepository(context);
                var userRoleRepository = new Repository<UserRole>(context);
                var role = userRoleRepository.GetById(2);
                repository.RegisterInsert(new User()
                {
                    NickName = "xuyy",
                    Sex = false,
                    Password = "123456",
                    Role = role
                });
                repository.RegisterInsert(new User()
                {
                    NickName = "liuyin",
                    Sex = false,
                    Password = "123456",
                    Role = role
                });
                repository.SaveChanges();
            }
        }
    }
}
