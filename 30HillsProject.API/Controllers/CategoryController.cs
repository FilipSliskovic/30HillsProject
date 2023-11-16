using _30HillsProject.Application.UseCases.Commands;
using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _30HillsProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CategoryController : ControllerBase
    {

        private UseCaseHandler useCaseHandler;

        public CategoryController(UseCaseHandler useCaseHandler)
        {
            this.useCaseHandler = useCaseHandler;
        }


        // GET: api/<CategoryController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<CategoryController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCategoryDTO dto, [FromServices] ICreateCategoryCommand command)
        {
            useCaseHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
