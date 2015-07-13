using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model.ModelsMapping
{
    public class UserRoleMapping : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMapping()
        {
            this.ToTable("UserRoles");
            this.HasKey(u => u.Id);
            this.Property(u => u.DeleteTime).IsOptional();
            this.Property(u => u.RoleName).IsRequired();
        }
    }
}
