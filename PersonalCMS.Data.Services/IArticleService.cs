using PersonalCMS.Data.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Services
{
    public interface IArticleService
    {
        IEnumerable<ArticleFieldDTO> Get();
        ArticleFieldDTO GetById(int id);
        PageQuery<ArticleDTO> GetArticles(int index, int pageSize);
        PageQuery<ArticleDTO> GetArticleByField(int fieldId, int index, int pageSize);
        ArticleDTO GetArticleById(int id);
        IEnumerable<ArticleDTO> SearchArticles(string keyWords);
    }
}
