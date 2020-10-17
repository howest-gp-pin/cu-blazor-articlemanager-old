using ArticleManager.Api.Controllers.Base;
using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces;
using ArticleManager.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerCrudBase<Article, int, ArticlesRepository>
    {

        public ArticlesController(ArticlesRepository repository): base(repository)
        {
        }

        // GET: api/Articles/Last
        [HttpGet("Last")]
        public virtual IActionResult GetLastArticle()
        {
            return Ok(repository.GetLastArticle());
        }
    }
}
