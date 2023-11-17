using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Metadata;
using _30HillsProject.Application.UseCases.Commands;
using _30HillsProject.Application.UseCases.DTO;
using _30HillsProject.API.DTO;
using _30HillsProject.Implementation;
using _30HillsProject.Application.UseCases.DTO.Searches;
using _30HillsProject.Application.UseCases.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _30HillsProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {

        private UseCaseHandler useCaseHandler;

        public ProductController(UseCaseHandler useCaseHandler)
        {
            this.useCaseHandler = useCaseHandler;
        }


        // GET: api/<ProductController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] ProductSearch search, [FromServices] IGetProductsQuery query)
        {
            return Ok(useCaseHandler.HandleQuery(query,search));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IGetSingleProductQuery query)
        {
            return Ok(useCaseHandler.HandleQuery(query, id));
        }

        // POST api/<ProductController>
        [HttpPost]

        public IActionResult Post([FromForm] CreateProductAPIDTO dto, [FromServices] ICreateProductCommand command)
        {
            if (dto.Images != null)
            {
                foreach (var image in dto.Images)
                {
                    var guid = Guid.NewGuid();
                    var extension = Path.GetExtension(image.FileName);

                    if (!SupportedExtension.Contains(extension))
                    {
                        throw new InvalidOperationException("Invalid file extension");
                    }

                    var newFileName = guid + extension;

                    var path = Path.Combine("wwwroot", "images", newFileName);


                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(filestream);
                    }


                    dto.ImageFileNames.Add(newFileName);
                }

            }

            useCaseHandler.HandleCommand(command, dto);
            return StatusCode(201);


        }

        private IEnumerable<string> SupportedExtension => new List<string> { ".Png", ".jpg", ".jpeg" };

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
