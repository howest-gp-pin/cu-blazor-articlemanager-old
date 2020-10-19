using ArticleManager.Core.Entities.Base;
using ArticleManager.Core.Interfaces.Repositories.Base;

namespace ArticleManager.Core.Interfaces.Services.Base
{
    public interface IRepositoryService<T, TKey> where T : EntityBase<TKey>
    {
        IRepository<T, TKey> Repository { get; set; }
    }
}
