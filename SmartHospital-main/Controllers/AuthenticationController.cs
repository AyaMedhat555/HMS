
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;
using Repository;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController: ControllerBase
    {

        private IUserService _userService { get; }

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto request)
        {
            Console.WriteLine(request.ToString());
            //check if username already used
            var user = await _userService.GetUserByName(request.UserName);
            if (user != null)
            {
                return Ok("Username already taken.");
            }
            await _userService.AddUser(request);
            return Ok("User: "+request.UserName+" was added successfully!");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequest request)
        {
            var response = await _userService.Login(request);
            return Ok(response);   
        }
    }
}
