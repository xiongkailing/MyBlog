using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.ModelDTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public UserDTO User { get; set; }
        /// <summary>
        /// 打分
        /// </summary>
        public int Grade { get; set; }
        /// <summary>
        /// 所属文章
        /// </summary>
        public ArticleDTO Article { get; set; }
        /// <summary>
        /// 所评论的评论
        /// </summary>
        public CommentDTO ParentComment { get; set; }
    }
}
