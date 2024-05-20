using GestionVoyage.API.Models;
using GestionVoyage.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GestionVoyage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrajetController(TrajetRepository repository) : ControllerBase
    {
        private readonly TrajetRepository _repository = repository;

        // GET: api/<DepartController>
        [HttpGet]
        public async Task<IEnumerable<Trajet>> Get()
        {
            return await _repository.Get();
        }

        // GET api/<DepartController>/5
        [HttpGet("{id}")]
        public async Task<Trajet> Get(int id)
        {
            return await _repository.Get(id);
        }

        // POST api/<DepartController>
        [HttpPost]
        public async Task Post([FromBody] Trajet value)
        {
            await _repository.Add(value);
        }

        // PUT api/<DepartController>/5
        // Cette version de PUT utilise la méthode avec ExecuteUpdateAsync
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Trajet value)
        {
            await _repository.Update(id, value);
        }

        // DELETE api/<DepartController>/5
        [HttpDelete("{ids}")]
        public async Task Delete(int[] ids)
        {
            await _repository.Delete(ids);
        }
    }
}
