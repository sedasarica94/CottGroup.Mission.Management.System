using CottGroup.Mission.Management.System.Core.Base;
using CottGroup.Mission.Management.System.Services.MissionComponents.Requests;
using CottGroup.Mission.Management.System.Services.MissionComponents.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Services.MissionComponents
{
    public interface IMissionService
    {
        Task<BaseResponse<List<ResponseMission>>> GetAllAsync();
        Task<BaseResponse<List<ResponseMission>>> GetAllActiveAsync();
        Task<BaseResponse<ResponseMission>> InsertAsync(RequestInsertMission request);
        Task<BaseResponse<ResponseMission>> UpdateAsync(RequestUpdateMission request);
        Task DeleteAsync(int id);
    }
}
