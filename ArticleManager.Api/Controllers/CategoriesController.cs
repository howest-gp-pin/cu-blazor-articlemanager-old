using ArticleManager.Api.Controllers.Base;
using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerCrudBase<Category, int, ICategoryService>
    {
        public CategoriesController(ICategoryService s) : base(s)
        {
        }
    }
}
