using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.ModelDTO
{
    public class PageQuery<T> where T:class
    {
        public int Total { get; set; }
        public IEnumerable<T> Datas { get; set; }
    }
}
