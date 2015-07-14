using NLog;
using PersonalCMS.Data.Model;
using PersonalCMS.Data.ModelDTO;
using PersonalCMS.Data.Repository;
using PersonalCMS.Infrastructure.SystemLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Services
{
    public class UserService : IUserService
    {
        private IDbContext dbContext;
        private IRepository<User> repository;
        private IRepository<UserRole> roleRepository;
        public UserService(IDbContext dbContext, IRepository<User> repository,
            IRepository<UserRole> roleRepository)
        {
            this.dbContext = dbContext;
            this.repository = repository;
            this.roleRepository = roleRepository;
        }
        public IEnumerable<UserDTO> Get()
        {
            var query = this.repository.Get();
            return AutoMapper.Mapper.Map<IEnumerable<UserDTO>>(query);
        }


        public UserDTO Login(string name, string passsword)
        {
            var query = this.repository.Get();
            try
            {
                var user = query.SingleOrDefault(u => u.NickName.ToUpper() == name.ToUpper() && u.Password.ToUpper() == passsword.ToUpper());
                return AutoMapper.Mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                var mount = query.Where(u => u.NickName.ToUpper() == name.ToUpper() && u.Password.ToUpper() == passsword.ToUpper()).Count();
                if (mount > 1)
                    Log.Instance.WriteLog(LogLevel.Fatal, "出现相同用户Name:" + name, ex);
                else
                    Log.Instance.WriteLog(LogLevel.Error, "登入查询出现bug", ex);
                return null;
            }

        }
    }
}
