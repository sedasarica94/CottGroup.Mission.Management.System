using CottGroup.Mission.Management.System.Services.MissionComponents;
using CottGroup.Mission.Management.System.Services.MissionComponents.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly IMissionService _missionService;

        public MissionController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _missionService.GetAllAsync();
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] RequestInsertMission request)
        {
            var response = await _missionService.InsertAsync(request);
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RequestUpdateMission request)
        {
            var response = await _missionService.UpdateAsync(request);
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            await _missionService.DeleteAsync(id);
            return Ok();
        }
    }
}
