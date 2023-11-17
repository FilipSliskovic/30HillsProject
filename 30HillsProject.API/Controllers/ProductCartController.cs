using _30HillsProject.Application.UseCases.Commands;
using _30HillsProject.Application.UseCases.DTO;
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
    public class ProductCartController : ControllerBase
    {

        private UseCaseHandler useCaseHandler;

        public ProductCartController(UseCaseHandler useCaseHandler)
        {
            this.useCaseHandler = useCaseHandler;
        }


        // GET: api/<ProductCartController>
        //[HttpGet]
        //public IActionResult Get([FromQuery] ProductCartSearch search, [FromServices] IGetProductCartQuery query )
        //{
        //    return Ok(useCaseHandler.HandleQuery(query,search));
        //}

        // GET api/<ProductCartController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ProductCartController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCartDTO dto, [FromServices] ICreateProductCartCommand command)
        {
            useCaseHandler.HandleCommand(command,dto);
            return StatusCode(201);

        }

        // PUT api/<ProductCartController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProductCartController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteProductCartCommand command)
        {
            useCaseHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
