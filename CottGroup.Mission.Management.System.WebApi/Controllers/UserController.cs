using CottGroup.Mission.Management.System.Services.UserComponents;
using CottGroup.Mission.Management.System.Services.UserComponents.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _userService.GetAllAsync();
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] RequestInsertUser request)
        {
            var response = await _userService.InsertAsync(request);
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RequestUpdateUser request)
        {
            var response = await _userService.UpdateAsync(request);
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }

    }
}
