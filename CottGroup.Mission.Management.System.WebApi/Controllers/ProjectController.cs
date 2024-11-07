using CottGroup.Mission.Management.System.Services.ProjectComponents;
using CottGroup.Mission.Management.System.Services.ProjectComponents.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _projectService.GetAllAsync();
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] RequestInsertProject request)
        {
            var response = await _projectService.InsertAsync(request);
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RequestUpdateProject request)
        {
            var response = await _projectService.UpdateAsync(request);
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            await _projectService.DeleteAsync(id);
            return Ok();
        }

    }

}
