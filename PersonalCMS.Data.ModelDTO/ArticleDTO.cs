using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.ModelDTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public ArticleFieldDTO ArticleType { get; set; }
        public string Title { get; set; }
        public UserDTO Author { get; set; }
        public bool IsPublic { get; set; }
        public string Content { get; set; }
        public string Img { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }
        public string Summary { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
