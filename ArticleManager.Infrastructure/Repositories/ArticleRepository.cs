using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces.Repositories;
using ArticleManager.Infrastructure.Data;
using ArticleManager.Infrastructure.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleManager.Infrastructure.Repositories
{
    public class ArticleRepository: EfRepositoryBase<Article, int>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext dbContext): base(dbContext)
        {
        }

        public async Task<Article> GetLastArticle()
        {
            return GetAll().OrderBy(a => a.Title).Select(a => a).Last();
        }

    }
}
