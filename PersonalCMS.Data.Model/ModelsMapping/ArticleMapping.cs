using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model.ModelsMapping
{
    public class ArticleMapping : EntityTypeConfiguration<Article>
    {
        public ArticleMapping()
        {
            this.ToTable("Articles");
            this.HasKey(a => a.Id);
            this.Property(a => a.DeleteTime).IsOptional();
            this.Property(a => a.Title).HasMaxLength(50).IsRequired();
            this.Property(a => a.Content).IsVariableLength().IsRequired();
        }
    }
}
