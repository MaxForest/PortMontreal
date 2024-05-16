using GestionVoyage.API.Models;
using GestionVoyage.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GestionVoyage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArriveeController(ArriveRepository repository) : ControllerBase
    {
        private readonly ArriveRepository _repository = repository;

        // GET: api/<ArriveeController>
        [HttpGet]
        public async Task<IEnumerable<Arrivee>> Get()
        {
            return await _repository.Get();
        }

        // GET api/<ArriveeController>/5
        [HttpGet("{id}")]
        public async Task<Arrivee> Get(int id)
        {
            return await _repository.Get(id);
        }

        // POST api/<ArriveeController>
        [HttpPost]
        public async Task Post([FromBody] Arrivee value)
        {
            await _repository.Add(value);
        }

        // PUT api/<ArriveeController>/5
        // Cette version de PUT utilise la méthode avec CurrentValues.SetValues
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Arrivee value)
        {
            await _repository.Update(id, value);
        }

        // DELETE api/<ArriveeController>/5
        [HttpDelete("{ids}")]
        public async Task Delete(int[] ids)
        {
            await _repository.Delete(ids);
        }
    }
}
