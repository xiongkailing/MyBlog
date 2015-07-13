using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model.ModelsMapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.ToTable("Users");
            this.HasKey(u => u.Id);
            this.HasMany(u => u.Articles).WithRequired(a => a.Author);
            this.HasMany(u => u.Comments).WithOptional(c => c.User);
            this.HasOptional(u => u.Role);
            this.Property(u => u.BirthDay).IsOptional();
            this.Property(u => u.NickName).IsRequired();
            this.Property(u => u.Password).IsRequired();
            this.Property(u => u.DeleteTime).IsOptional();
        }
    }
}
