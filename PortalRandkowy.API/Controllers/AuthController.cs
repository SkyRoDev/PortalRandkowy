using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalRandkowy.API.Data;
using PortalRandkowy.API.Models;

namespace PortalRandkowy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        public AuthController(IAuthRepository repository)
        {
            _repository = repository;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Regiser(string username,string password){
            username = username.ToLower();

            if(await _repository.UserExists(username))
                return BadRequest("Użytkownik o takiej nazwie już isteniej");

            var userToCreate = new User{
                UserName = username
            };

            var createUser = await _repository.Regiser(userToCreate, password);

            return StatusCode(201);
        }
        
    }
}