using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model
{
    public class Comment:BaseEntity
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
        /// <summary>
        /// 所属文章
        /// </summary>
        public virtual Article Article { get; set; }
        /// <summary>
        /// 所评论的评论
        /// </summary>
        public virtual Comment ParentComment { get; set; }
    }
}
