using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces.Repositories;
using ArticleManager.Infrastructure.Data;
using ArticleManager.Infrastructure.Repositories.Base;

namespace ArticleManager.Infrastructure.Repositories
{
    public class CategoryRepository : EfRepositoryBase<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
