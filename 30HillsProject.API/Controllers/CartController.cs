using _30HillsProject.Application.UseCases.Commands;
using _30HillsProject.Application.UseCases.DTO.Searches;
using _30HillsProject.Application.UseCases.Queries;
using _30HillsProject.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _30HillsProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {

        private UseCaseHandler useCaseHandler;

        public CartController(UseCaseHandler useCaseHandler)
        {
            this.useCaseHandler = useCaseHandler;
        }

        // GET: api/<CartController>
        [HttpGet]
        public IActionResult Get([FromQuery] CartSearch search, [FromServices] IGetCartsQuery query)
        {
            return Ok(useCaseHandler.HandleQuery(query,search));
        }

        //// GET api/<CartController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<CartController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CartController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCartCommand command)
        {
            useCaseHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
