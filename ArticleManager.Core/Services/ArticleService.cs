using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces.Repositories;
using ArticleManager.Core.Interfaces.Services;
using ArticleManager.Core.Services.Base;
using System.Threading.Tasks;

namespace ArticleManager.Core.Services
{
    public class ArticleService: RepositoryServiceBase<Article, int>, IArticleService
    {
        private IArticleRepository _repository;

        public ArticleService(IArticleRepository repository): base(repository)
        {
            _repository = repository;
        }

       
        public async Task<Article> GetLastArticle()
        {
            return await _repository.GetLastArticle();
        }

    }
}
