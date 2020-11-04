using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticleManager.Api.Data;
using ArticleManager.Api.Data.Entities;
using ArticleManager.Core.Models;

namespace ArticleManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public  IActionResult Get()
        {
            return Ok( _context.Categories
                .Select(x => new ArticleCategoryListItem()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList());
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var category = await _context.Categories
                .Where(x => x.Id == id)
                .Select(x => new ArticleCategoryItem()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .SingleOrDefaultAsync();

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ArticleCategoryItem item)
        {
            if (ModelState.IsValid)
            {
                var entity = _context.Categories.SingleOrDefault(x => x.Id == id);
                if (entity == null) return NotFound();
                entity.Name = item.Name;
                entity.Description = item.Description;
                _context.SaveChanges();
                return Ok(entity);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult Post(ArticleCategoryItem item)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    Name = item.Name,
                    Description = item.Description,
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
            var entity = _context.Categories.SingleOrDefault(x => x.Id == id);
            if (entity == null) return NotFound();
            _context.Remove(entity);
            _context.SaveChanges();
            return Ok(entity);
        }

       
    }
}
