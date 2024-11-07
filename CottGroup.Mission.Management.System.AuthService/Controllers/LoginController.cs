using CottGroup.Mission.Management.System.AuthService.Models.Requests;
using CottGroup.Mission.Management.System.Infrastructure.Repositories;
using CottGroup.Mission.Management.System.Services.TokenComponents;
using CottGroup.Mission.Management.System.Services.UserComponents;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.AuthService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] RequestLogin request)
        {
            var userResponse =await _userService.GetUserInfoAsync(request.Username,request.Password);
            if(userResponse.IsSuccess)
                return Ok(new { Token = _tokenService.GenerateToken(userResponse.Data) });
             
            return NotFound(userResponse.Errors); 
        }
    }
     
}
