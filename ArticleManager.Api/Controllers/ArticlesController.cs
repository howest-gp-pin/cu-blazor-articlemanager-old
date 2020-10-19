using ArticleManager.Api.Controllers.Base;
using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerCrudBase<Article, int, IArticleService>
    {

        public ArticlesController(IArticleService s) : base(s)
        {
        }

        // GET: api/Articles/Last
        [HttpGet("Last")]
        public virtual IActionResult GetLastArticle()
        {
            return Ok(service.GetLastArticle());
        }
    }
}
