using ArticleManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ArticleManager.Web.Services
{
    public class ArticlesService
        : ICRUDService<ArticleListItem, ArticleItem>
    {
        private string baseUrl = "https://localhost:5003/api/articles";

        private readonly HttpClient _httpClient = null;

        public ArticlesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ArticleListItem[]> GetList()
        {
            return _httpClient
                .GetFromJsonAsync<ArticleListItem[]>
                    ($"{baseUrl}");
        }

        public Task<ArticleItem> GetNew()
        {
            return _httpClient
                .GetFromJsonAsync<ArticleItem>
                    ($"{baseUrl}/new");
        }
        public Task<ArticleItem> Get(int id)
        {
            return _httpClient
                .GetFromJsonAsync<ArticleItem>
                    ($"{baseUrl}/{id}");
        }

        public Task Create(ArticleItem item)
        {
            return _httpClient
                .PostAsJsonAsync<ArticleItem>
                    ($"{baseUrl}", item);
        }

        public Task Update(ArticleItem item)
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
