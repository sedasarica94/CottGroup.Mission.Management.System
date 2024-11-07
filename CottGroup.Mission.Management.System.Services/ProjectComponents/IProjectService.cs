using CottGroup.Mission.Management.System.Core.Base;
using CottGroup.Mission.Management.System.Services.ProjectComponents.Requests;
using CottGroup.Mission.Management.System.Services.ProjectComponents.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Services.ProjectComponents
{
    public interface IProjectService
    {
          Task<BaseResponse<List<ResponseProject>>> GetAllAsync();
          Task<BaseResponse<List<ResponseProject>>> GetAllActiveAsync();
          Task<BaseResponse<ResponseProject>> InsertAsync(RequestInsertProject request);
          Task<BaseResponse<ResponseProject>> UpdateAsync(RequestUpdateProject request);
          Task DeleteAsync(int id);
    }
}
