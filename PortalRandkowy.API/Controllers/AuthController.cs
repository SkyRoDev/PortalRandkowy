using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalRandkowy.API.Data;
using PortalRandkowy.API.Dtos;
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
        public async Task<IActionResult> Regiser(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repository.UserExists(userForRegisterDto.Username))
                return BadRequest("Użytkownik o takiej nazwie już isteniej");

            var userToCreate = new User{
                UserName = userForRegisterDto.Username
            };

            var createUser = await _repository.Regiser(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
        
    }
}