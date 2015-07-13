using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model.ModelsMapping
{
    public class CommentMapping : EntityTypeConfiguration<Comment>
    {
        public CommentMapping()
        {
            this.ToTable("Comments");
            this.HasKey(c => c.Id);
            this.HasRequired(c => c.Article).WithMany(a => a.Comments);
            this.Property(c => c.Grade).IsRequired();
            this.Property(c => c.DeleteTime).IsOptional();
            this.Property(c => c.Content).HasMaxLength(200);
            this.HasOptional(c => c.ParentComment);
        }
    }
}
