using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Repository
{
    public class CmsDBcontext : DbContext, IDbContext
    {
        public CmsDBcontext()
            : base()
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typeToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(t => !string.IsNullOrEmpty(t.Namespace)).
                 Where(t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typeToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public DbContext dbContext
        {
            get
            {
                return this;
            }
        }
    }
}
