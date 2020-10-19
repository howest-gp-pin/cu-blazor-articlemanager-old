using ArticleManager.Core.Entities.Base;
using ArticleManager.Core.Interfaces.Repositories.Base;
using ArticleManager.Core.Interfaces.Services.Base;

namespace ArticleManager.Core.Services.Base
{
    public class RepositoryServiceBase<T, TKey> : IRepositoryService<T, TKey> where T : EntityBase<TKey>
    {
        public IRepository<T, TKey> Repository { get; set; }

        public RepositoryServiceBase(IRepository<T, TKey> repository)
        {
            Repository = repository;
        }    
    }
}
