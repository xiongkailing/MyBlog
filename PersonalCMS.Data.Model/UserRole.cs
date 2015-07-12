using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Model
{
    public class UserRole:BaseEntity
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Descriptor { get; set; }
    }
}
