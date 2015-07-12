using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model
{
    public class Comment
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// 打分
        /// </summary>
        public int Grade { get; set; }
    }
}
