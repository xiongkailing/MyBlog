using PersonalCMS.Data.Model;
using PersonalCMS.Data.ModelDTO;
using PersonalCMS.Data.Repository;
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
    }
}
