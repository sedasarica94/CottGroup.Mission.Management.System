using AutoMapper;
using CottGroup.Mission.Management.System.Core.Base;
using CottGroup.Mission.Management.System.Infrastructure.Repositories;
using CottGroup.Mission.Management.System.Services.MissionComponents.Requests;
using CottGroup.Mission.Management.System.Services.MissionComponents.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Services.MissionComponents.Impl
{
    public class MissionService : IMissionService
    {
        private readonly IMissionRepository _missionRepository;
        private readonly IMapper _mapper;

        public MissionService(IMissionRepository missionRepository, IMapper mapper)
        {
            _missionRepository = missionRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<ResponseMission>>> GetAllActiveAsync()
        {
            try
            {
                var response = await _missionRepository.GetAllAsync(x => !x.IsDeleted && x.IsActive);
                return new BaseResponse<List<ResponseMission>>(_mapper.Map<List<ResponseMission>>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<List<ResponseMission>>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<List<ResponseMission>>> GetAllAsync()
        {
            try
            {
                var response = await _missionRepository.GetAllAsync(x => !x.IsDeleted);
                return new BaseResponse<List<ResponseMission>>(_mapper.Map<List<ResponseMission>>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<List<ResponseMission>>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<ResponseMission>> InsertAsync(RequestInsertMission request)
        {
            try
            {
                var ent = _mapper.Map<Infrastructure.Data.Entities.Mission>(request);
                ent.CreatedOnAuditing(request.CreatedBy);
                var returnModel = await _missionRepository.InsertAsync(ent);
                return new BaseResponse<ResponseMission>(_mapper.Map<ResponseMission>(returnModel));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<ResponseMission>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<ResponseMission>> UpdateAsync(RequestUpdateMission request)
        {
            try
            {
                var ent = _mapper.Map<Infrastructure.Data.Entities.Mission>(request);
                ent.UpdatedOnAuditing(request.UpdatedBy);
                var response = await _missionRepository.UpdateAsync(ent);
                return new BaseResponse<ResponseMission>(_mapper.Map<ResponseMission>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<ResponseMission>(string.Empty, ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _missionRepository.Delete(x => x.Id == id);
        }

    }
}
 