using CottGroup.Mission.Management.System.Core.Base;
using CottGroup.Mission.Management.System.Services.UserComponents.Requests;
using CottGroup.Mission.Management.System.Services.UserComponents.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Services.UserComponents
{
    public interface IUserService
    {
        Task<BaseResponse<List<ResponseUser>>> GetAllAsync();
        Task<BaseResponse<List<ResponseUser>>> GetAllActiveAsync();
        Task<BaseResponse<ResponseUser>> InsertAsync(RequestInsertUser request);
        Task<BaseResponse<ResponseUser>> UpdateAsync(RequestUpdateUser request);
        Task DeleteAsync(int id);
        Task<BaseResponse<ResponseUser>> GetUserInfoAsync(string username, string password);
    }
}
