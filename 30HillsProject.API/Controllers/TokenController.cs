using _30HillsProject.API.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _30HillsProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {
        private readonly JWTManager _manager;

        public TokenController(JWTManager manager)
        {
            _manager = manager;
        }

        // POST api/<TokenController>
        [HttpPost]
        public IActionResult Post([FromBody] TokenRequest request)
        {
            try
            {
                var token = _manager.MakeToken(request.Username, request.Password);

                return Ok(new { token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        public class TokenRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
