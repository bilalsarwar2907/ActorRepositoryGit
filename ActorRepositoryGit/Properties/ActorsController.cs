using ActorRepositoryGit.Models;
using ActorRepositoryGit.Repositories; // Ensure this using directive is present
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActorRepositoryGit.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepositoryList _actorRepo;

        // Constructor added to inject IActorRepository dependency
        public ActorsController(IActorRepositoryList actorRepo)
        {
            _actorRepo = actorRepo;
        }

        // GET: api/<ActorsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_actorRepo.GetAll());
        }

        // GET api/<ActorsController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var actor = _actorRepo.GetById(id);
            if (actor == null)
            
                return NotFound();
            return Ok(actor);

        }

        // POST api/<ActorsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}