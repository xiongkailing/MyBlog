using PersonalCMS.Data.Model;
using PersonalCMS.Data.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Services.Mapper
{
    public class PeronalCMSMapperProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<UserRole, UserRoleDTO>();

            AutoMapper.Mapper.CreateMap<User, UserDTO>();

            AutoMapper.Mapper.CreateMap<Article, ArticleDTO>();

            AutoMapper.Mapper.CreateMap<Comment, CommentDTO>();

            AutoMapper.Mapper.CreateMap<ArticleField, ArticleFieldDTO>();

            var usermap = AutoMapper.Mapper.CreateMap<UserDTO, User>();
            usermap.ForMember(d => d.Id, s => s.Ignore());
            usermap.ForMember(d => d.Articles, s => s.Ignore());
            usermap.ForMember(d => d.Comments, s => s.Ignore());
            usermap.ForMember(d => d.Role, s => s.Ignore());

            var userRoleMap = AutoMapper.Mapper.CreateMap<UserRoleDTO, UserRole>();
            userRoleMap.ForMember(d => d.Id, s => s.Ignore());

            var articleMap = AutoMapper.Mapper.CreateMap<ArticleDTO, Article>();
            articleMap.ForMember(d => d.Id, s => s.Ignore());
            articleMap.ForMember(d => d.Author, s => s.Ignore());
            articleMap.ForMember(d => d.ArticleType, s => s.Ignore());
            articleMap.ForMember(d => d.Comments, s => s.Ignore());

            var articleFieldMap = AutoMapper.Mapper.CreateMap<ArticleFieldDTO, ArticleField>();
            articleFieldMap.ForMember(d => d.Id, s => s.Ignore());
            articleFieldMap.ForMember(d => d.Articles, s => s.Ignore());

            var commentMap = AutoMapper.Mapper.CreateMap<CommentDTO, Comment>();
            commentMap.ForMember(d => d.Id, s => s.Ignore());
            commentMap.ForMember(d => d.ParentComment, s => s.Ignore());
            commentMap.ForMember(d => d.User, s => s.Ignore());
            commentMap.ForMember(d => d.Article, s => s.Ignore());
        }
    }
}
