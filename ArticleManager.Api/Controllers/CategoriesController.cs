using ArticleManager.Api.Controllers.Base;
using ArticleManager.Core.Entities;
using ArticleManager.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerCrudBase<Category, int, IRepository<Category, int>>
    {
        public CategoriesController(IRepository<Category, int> repository) : base(repository)
        {

        }
    }
}
