using ArticleManager.Core.Entities.Base;
using ArticleManager.Core.Interfaces.Services.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArticleManager.Api.Controllers.Base
{
    public class ControllerCrudBase<T, TKey, S> : ControllerBase
        where T : EntityBase<TKey>
        where S : IRepositoryService<T, TKey>
    {
        protected S service;
        public ControllerCrudBase(S s)
        {
            service = s;
        }

        // GET: api/T
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(service.Repository.GetAll());
        }


        // GET: api/T/2
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(TKey id)
        {
            return Ok(await service.Repository.GetByIdAsync(id));
        }

        // PUT: api/T/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] TKey id,
            [FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!id.Equals(entity.Id)) return BadRequest();

            T updated = await service.Repository.UpdateAsync(entity);

            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // POST api/T
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] T entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await service.Repository.AddAsync(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/T/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] TKey id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id == null) return NotFound();            
            var deleted = await service.Repository.DeleteAsync(id);
            if (deleted == null) return NotFound();
            return Ok(deleted);
        }
    }
}
