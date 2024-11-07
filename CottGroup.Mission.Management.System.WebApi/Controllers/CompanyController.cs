using CottGroup.Mission.Management.System.Core.Filters;
using CottGroup.Mission.Management.System.Services.Company;
using CottGroup.Mission.Management.System.Services.CompanyComponents.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _companyService.GetAllAsync();
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "AdminPolicy")]
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] RequestInsertCompany request)
        {
            var response = await _companyService.InsertAsync(request);
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "CompanyManagerPolicy")]
        [CompanyAuthorization]
        [HttpPut("{id}")] //CompanyId. Kullanıcının kendi bağlı olduğu şirketinde işlem yapabilmesi için
        public async Task<IActionResult> UpdateAsync([FromBody] RequestUpdateCompany request)
        { 
            var response = await _companyService.UpdateAsync(request);
            if (!response.IsSuccess || response.Data is null)
                return NotFound(response.Errors);
            return Ok(response.Data);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "AdminPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            await _companyService.DeleteAsync(id);
            return Ok();
        }
    }
}
