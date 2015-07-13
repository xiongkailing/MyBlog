using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model
{
    public class ArticleField:BaseEntity
    {
        /// <summary>
        /// 领域
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descriptor { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; }
        public ArticleField()
        {
            this.Articles = new HashSet<Article>();
        }
    }
}
