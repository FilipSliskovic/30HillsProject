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
    public class RegisterController : ControllerBase
    {

        private readonly UseCaseHandler useCaseHandler;
        private readonly IRegisterUserCommand command;

        public RegisterController(UseCaseHandler useCaseHandler, IRegisterUserCommand command)
        {
            this.useCaseHandler = useCaseHandler;
            this.command = command;
        }

        // POST api/<RegisterController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisterDTO dto)
        {
            useCaseHandler.HandleCommand(command, dto);

            return StatusCode(201);


        }

       
    }
}
