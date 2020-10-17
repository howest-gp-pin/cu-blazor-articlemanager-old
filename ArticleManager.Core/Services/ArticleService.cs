using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces;
using ArticleManager.Core.Interfaces.Repositories;
using ArticleManager.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Core.Services
{
    public class ArticleService: IArticleService
    {
        private IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Article> GetLastArticle()
        {
            return await _articleRepository.GetLastArticle();
        }

    }
}
