using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces.Repositories;
using ArticleManager.Core.Interfaces.Services;
using ArticleManager.Core.Services.Base;
using System.Threading.Tasks;

namespace ArticleManager.Core.Services
{
    public class CategoryService : RepositoryServiceBase<Category, int>, ICategoryService
    {
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
