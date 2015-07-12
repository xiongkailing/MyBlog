using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model
{
    public class Article : BaseEntity
    {
        public virtual ArticleType ArticleType { get; set; }
        public string Title { get; set; }
        public virtual User Author { get; set; }
        public bool IsPublic { get; set; }
        public string Content { get; set; }
        public string Img { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public string Summary { get; set; }
    }
}
