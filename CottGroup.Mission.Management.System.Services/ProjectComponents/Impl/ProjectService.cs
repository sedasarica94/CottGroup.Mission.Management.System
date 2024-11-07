using AutoMapper;
using CottGroup.Mission.Management.System.Core.Base;
using CottGroup.Mission.Management.System.Infrastructure.Repositories;
using CottGroup.Mission.Management.System.Services.ProjectComponents.Requests;
using CottGroup.Mission.Management.System.Services.ProjectComponents.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Services.ProjectComponents.Impl
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;

        }

        public async Task<BaseResponse<List<ResponseProject>>> GetAllActiveAsync()
        {
            try
            {
                var response = await _projectRepository.GetAllAsync(x => !x.IsDeleted && x.IsActive);
                return new BaseResponse<List<ResponseProject>>(_mapper.Map<List<ResponseProject>>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<List<ResponseProject>>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<List<ResponseProject>>> GetAllAsync()
        {
            try
            {
                var response = await _projectRepository.GetAllAsync(x => !x.IsDeleted);
                return new BaseResponse<List<ResponseProject>>(_mapper.Map<List<ResponseProject>>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<List<ResponseProject>>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<ResponseProject>> InsertAsync(RequestInsertProject request)
        {
            try
            {
                var ent = _mapper.Map<Infrastructure.Data.Entities.Project>(request);
                var response = await _projectRepository.InsertAsync(ent);
                return new BaseResponse<ResponseProject>(_mapper.Map<ResponseProject>(response));

            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<ResponseProject>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<ResponseProject>> UpdateAsync(RequestUpdateProject request)
        {
            try
            {
                var ent = _mapper.Map<Infrastructure.Data.Entities.Project>(request);
                ent.UpdatedOnAuditing(request.UpdatedBy);
                var response = await _projectRepository.UpdateAsync(ent);
                return new BaseResponse<ResponseProject>(_mapper.Map<ResponseProject>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<ResponseProject>(string.Empty, ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _projectRepository.Delete(x => x.Id == id);
        }

    }
}
