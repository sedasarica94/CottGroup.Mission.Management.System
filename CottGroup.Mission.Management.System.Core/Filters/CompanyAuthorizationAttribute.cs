using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace CottGroup.Mission.Management.System.Core.Filters
{
    public class CompanyAuthorizationAttribute : AuthorizeAttribute, IAuthorizationFilter
    {

        public CompanyAuthorizationAttribute()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!user.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Supervisor" || c.Value == "Admin"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var companyIdClaim = user.Claims.FirstOrDefault(c => c.Type == "company_id")?.Value;
            if (companyIdClaim == null)
            {
                context.Result = new UnauthorizedObjectResult("CompanyId claim'i bulunamadı.");
                return;
            }

            if (!context.RouteData.Values.TryGetValue("id", out var routeCompanyId) ||
                routeCompanyId?.ToString() != companyIdClaim)
            {
                context.Result = new UnauthorizedObjectResult("Kendi Şirketinizde İşlem Yapabilirsiniz");
            }
        }
    }
}
