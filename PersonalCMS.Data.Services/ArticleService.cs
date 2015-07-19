using PersonalCMS.Data.Model;
using PersonalCMS.Data.ModelDTO;
using PersonalCMS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCMS.Data.Services
{
    public class ArticleService : IArticleService
    {
        private IDbContext dbContext;
        private IRepository<Article> repository;
        private IRepository<ArticleField> fieldRepository;
        public ArticleService(IDbContext _dbContext,
            IRepository<Article> _repository,
            IRepository<ArticleField> _fieldRepository)
        {
            this.dbContext = _dbContext;
            this.repository = _repository;
            this.fieldRepository = _fieldRepository;
        }
        public IEnumerable<ArticleFieldDTO> Get()
        {
            var query = this.fieldRepository.Get();
            var dtos = AutoMapper.Mapper.Map<IEnumerable<ArticleFieldDTO>>(query);
            return dtos;
        }


        public ArticleFieldDTO GetById(int id)
        {
            var query = this.fieldRepository.GetById(id);
            return AutoMapper.Mapper.Map<ArticleFieldDTO>(query);
        }

        public PageQuery<ArticleDTO> GetArticles(int index, int pageSize)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("页码不能小于0");
            var query = this.repository.Get();
            int total = query.Count<Article>();
            query = query.Skip(pageSize * index).Take(pageSize);
            var datas = AutoMapper.Mapper.Map<IEnumerable<ArticleDTO>>(query);
            return new PageQuery<ArticleDTO>()
            {
                Total = total,
                Datas = datas
            };
        }

        public PageQuery<ArticleDTO> GetArticleByField(int fieldId, int index, int pageSize)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index 参数<0");
            var query = this.repository.Get();
            query = query.Where(a => a.ArticleType.Id == fieldId);
            int total = query.Count<Article>();
            query = query.Skip(index * pageSize).Take(pageSize);
            var datas = AutoMapper.Mapper.Map<IEnumerable<ArticleDTO>>(query);
            return new PageQuery<ArticleDTO>()
            {
                Total = total,
                Datas = datas
            };
        }

        public ArticleDTO GetArticleById(int id)
        {
            var query = this.repository.GetById(id);
            return AutoMapper.Mapper.Map<ArticleDTO>(query);
        }

        public IEnumerable<ArticleDTO> SearchArticles(string keyWords)
        {
            if(string.IsNullOrWhiteSpace(keyWords))
                throw new ArgumentException("keywords 为空");
            //if(fieldId==0)
            List<string> keywordList=new List<string>();
            string[] keywordArr=keyWords.Split(new char[]{' ','/','\\',','});
            keywordArr=keywordArr.Where(s=>!string.IsNullOrWhiteSpace(s)).ToArray();
            if(keywordArr.Length>3)
            {
                keywordList.Add(keywordArr[0]);
                keywordList.Add(keywordArr[1]);
                keywordList.Add(keywordArr[2]);
            }
            else if(keywordArr.Length==2)
            {
                keywordList.Add(keywordArr[0]);
                keywordList.Add(keywordArr[1]);
                keywordList.Add("****$$$**@@@***@@@@@**");//保证搜不到
            }
            else{
                keywordList.Add(keywordArr[0]);
                keywordList.Add("** **$$$**@@@**~~~ *@@@@@**");
                keywordList.Add("*** *$$$*~*@@@** *@@@@@**");//保证搜不到
            }
            var query = this.repository.Get();
            var titlequery = query.Where(a => a.Title.Contains(keywordList[0]) || a.Title.Contains(keywordList[1]) || a.Title.Contains(keywordList[2]));
            var sumamryQuery = query.Where(a => a.Summary.Contains(keywordList[0]) || a.Summary.Contains(keywordList[1]) || a.Summary.Contains(keywordList[2]));
            var contentQuery = query.Where(a => a.Content.Contains(keywordList[0]) || a.Content.Contains(keywordList[1]) || a.Summary.Contains(keywordList[2])).Take(20);
            List<ArticleDTO> datas = new List<ArticleDTO>();
            datas.AddRange(AutoMapper.Mapper.Map<IEnumerable<ArticleDTO>>(titlequery));
            datas.AddRange(AutoMapper.Mapper.Map<IEnumerable<ArticleDTO>>(sumamryQuery));
            datas.AddRange(AutoMapper.Mapper.Map<IEnumerable<ArticleDTO>>(contentQuery));
            return datas;
        }
    }
}
