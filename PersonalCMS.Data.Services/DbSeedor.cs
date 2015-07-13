using PersonalCMS.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Services
{
    public class DbSeedor : CreateDatabaseIfNotExists<CmsDBContext>
    {
        protected override void Seed(CmsDBContext context)
        {
            context.Set<UserRole>().Add(new UserRole
            {
                RoleName = "admin",
                Descriptor = "管理员",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                IsDeleted = false
            });
            context.SaveChanges();
            context.Set<User>().Add(new User
            {
                NickName = "admin",
                Password = "123456",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                Phone = "18521030064",
                LastLoginTime = DateTime.Now,
                Remark = "初始化账户",
                Sex = false,
                Role = context.Set<UserRole>().First(),
                IsDeleted = false
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
