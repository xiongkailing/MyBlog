using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model
{
    public class ArticleType:BaseEntity
    {
        public string TypeName { get; set; }
        public string Descriptor { get; set; }
    }
}
