using PersonalCMS.Data.Model;
using PersonalCMS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Console
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(IDbContext dbcontext)
            : base(dbcontext)
        { }
    }
}
