using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model
{
    public class User : BaseEntity
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 电邮
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BirthDay { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public virtual UserRole Role { get; set; }
        /// <summary>
        /// 文章
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public User()
        {
            this.Articles = new HashSet<Article>();
            this.Comments = new HashSet<Comment>();
        }
    }
}
