using ArticleManager.Api.Controllers.Base;
using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerCrudBase<Article, int, IRepository<Article, int>>
    {
        private readonly IRepository<Article, int> _repository;

        public ArticlesController(IRepository<Article, int> repository): base(repository)
        {
            _repository = repository;
        }
    }
}
