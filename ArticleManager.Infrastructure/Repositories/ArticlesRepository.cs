using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces;
using ArticleManager.Infrastructure.Data;
using System.Linq;

namespace ArticleManager.Infrastructure.Repositories
{
    public class ArticlesRepository: EfRepository<Article, int>
    {
        public ArticlesRepository(ApplicationDbContext dbContext): base(dbContext)
        {
        }

        public Article GetLastArticle()
        {
            return _dbContext.Articles.OrderBy(a => a.Title).Select(a => a).Last();
        }

    }
}
