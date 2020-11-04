using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleManager.Api.Data;
using ArticleManager.Api.Data.Entities;
using ArticleManager.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> Get()
        {
            return Ok(await _context.Articles
                .Select(x => new ArticleListItem()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Category = x.Category.Name
                })
                .ToListAsync());
        }

        [HttpGet("new")]
        public async Task<IActionResult> GetNew()
        {
            var article = new ArticleItem()
            {
                Categories = await getCategories()
            };
            if (article.Categories.Count() > 0)
            {
                article.CategoryId = article.Categories.First().Value;
            }
            return Ok(article);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> Get(int id)
        {
            var result = await _context.Articles
                .Where(x => x.Id == id)
                .Select(x => new ArticleItem()
                {
                    Id = x.Id,
                    Title = x.Title,
                    CategoryId = x.CategoryId.ToString(),
                    Content = x.Content
                })
                .SingleOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }

            result.Categories = await getCategories();

            return Ok(result);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ArticleItem item)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Articles.SingleOrDefault(x => x.Id == id);
                if (entity == null) return NotFound();
                entity.Title = item.Title;
                entity.Content = item.Content;
                entity.CategoryId = int.Parse(item.CategoryId);
                _context.SaveChanges();
                return Ok(entity);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult Post(ArticleItem item)
        {
            if (ModelState.IsValid)
            {
                var entity = new Article()
                {
                    Title = item.Title,
                    Content = item.Content,
                    CategoryId = int.Parse(item.CategoryId)
                };
                _context.Add(entity);
                _context.SaveChanges();
                item.Id = entity.Id;
                return CreatedAtAction(nameof(Get), new { id = entity.Id }, item);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.Articles.SingleOrDefault(x => x.Id == id);
            if (entity == null) return NotFound();
            _context.Remove(entity);
            _context.SaveChanges();
            return Ok(entity);
        }

        private async Task<InputSelectItem[]> getCategories()
        {
            return await _context.Categories
                .Select(x => new InputSelectItem()
                {
                    Value = x.Id.ToString(),
                    Label = x.Name
                }).ToArrayAsync();
        }
    }
}
