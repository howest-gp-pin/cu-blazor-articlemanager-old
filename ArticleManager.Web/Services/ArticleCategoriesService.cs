using ArticleManager.Core.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ArticleManager.Web.Services
{
    public class ArticleCategoriesService
        : ICRUDService<ArticleCategoryListItem, ArticleCategoryItem>
    {
        private string baseUrl = "https://localhost:5003/api/categories";
        private readonly HttpClient _httpClient = null;

        public ArticleCategoriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ArticleCategoryListItem[]> GetList()
        {
            var result = _httpClient
                .GetFromJsonAsync<ArticleCategoryListItem[]>
                    ($"{baseUrl}");
            return result;
        }

        public Task<ArticleCategoryItem> GetNew()
        {
            return Task.FromResult(
                new ArticleCategoryItem()
            );
        }
        public Task<ArticleCategoryItem> Get(int id)
        {
            return _httpClient
                .GetFromJsonAsync<ArticleCategoryItem>
                    ($"{baseUrl}/{id}");
        }

        public Task Create(ArticleCategoryItem item)
        {
            return _httpClient
                .PostAsJsonAsync<ArticleCategoryItem>
                    ($"{baseUrl}", item);
        }

        public Task Update(ArticleCategoryItem item)
        {
            return _httpClient
                .PutAsJsonAsync
                    ($"{baseUrl}/{item.Id}", item);
        }

        public Task Delete(int id)
        {
            return _httpClient
                .DeleteAsync($"{baseUrl}/{id}");
        }
    }
}
