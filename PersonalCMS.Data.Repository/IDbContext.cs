using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Repository
{
    public interface IDbContext : IDisposable
    {
        DbContext dbContext { get; }
    }
}
