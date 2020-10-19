using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces.Repositories.Base;
using System.Threading.Tasks;

namespace ArticleManager.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        
    }
}
