using CottGroup.Mission.Management.System.Core.Base;
using CottGroup.Mission.Management.System.Services.CompanyComponents.Requests;
using CottGroup.Mission.Management.System.Services.CompanyComponents.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Services.Company
{
    public interface ICompanyService
    {
        Task<BaseResponse<List<ResponseCompany>>> GetAllAsync();
        Task<BaseResponse<List<ResponseCompany>>> GetAllActiveAsync();
        Task<BaseResponse<ResponseCompany>> InsertAsync(RequestInsertCompany request);
        Task<BaseResponse<ResponseCompany>> UpdateAsync(RequestUpdateCompany request);
        Task DeleteAsync(int id);
    }
}
