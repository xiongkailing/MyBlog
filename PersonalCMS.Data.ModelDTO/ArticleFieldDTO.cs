using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.ModelDTO
{
    public class ArticleFieldDTO
    {
        public int Id { get; set; }
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
        public virtual IEnumerable<ArticleDTO> Articles { get; set; }
    }
}
