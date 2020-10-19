using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces.Services.Base;
using System.Threading.Tasks;

namespace ArticleManager.Core.Interfaces.Services
{
    public interface ICategoryService : IRepositoryService<Category, int>
    {

    }
}
