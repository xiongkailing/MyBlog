using PersonalCMS.Data.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> Get();
    }
}
