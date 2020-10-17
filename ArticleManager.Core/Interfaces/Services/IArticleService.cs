using ArticleManager.Core.Entities;
using System.Threading.Tasks;

namespace ArticleManager.Core.Interfaces.Services
{
    public interface IArticleService
    {
        public Task<Article> GetLastArticle();
    }
}
