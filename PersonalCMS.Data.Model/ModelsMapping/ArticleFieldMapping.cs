using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model.ModelsMapping
{
    public class ArticleFieldMapping : EntityTypeConfiguration<ArticleField>
    {
        public ArticleFieldMapping()
        {
            this.ToTable("ArticleFields");
            this.HasKey(t => t.Id);
            this.Property(t => t.FieldName).IsRequired();
            this.Property(t => t.DeleteTime).IsOptional();
            this.HasMany(t => t.Articles).WithRequired(t => t.ArticleType);            
        }
    }
}
