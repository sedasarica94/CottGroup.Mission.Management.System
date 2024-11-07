using AutoMapper;
using CottGroup.Mission.Management.System.Core.Base;
using CottGroup.Mission.Management.System.Infrastructure.Repositories;
using CottGroup.Mission.Management.System.Services.Company;
using CottGroup.Mission.Management.System.Services.CompanyComponents.Requests;
using CottGroup.Mission.Management.System.Services.CompanyComponents.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Services.CompanyComponents.Impl
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _autoMapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper autoMapper)
        {
            _companyRepository = companyRepository;
            _autoMapper = autoMapper;
        }

        public async Task<BaseResponse<List<ResponseCompany>>> GetAllAsync()
        {
            try
            {
                var response = await _companyRepository.GetAllAsync(x => !x.IsDeleted);
                return new BaseResponse<List<ResponseCompany>>(_autoMapper.Map<List<ResponseCompany>>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<List<ResponseCompany>>(string.Empty, ex.Message);
            }

        }

        public async Task<BaseResponse<List<ResponseCompany>>> GetAllActiveAsync()
        {
            try
            {
                var response = await _companyRepository.GetAllAsync(x => !x.IsDeleted && x.IsActive);
                return new BaseResponse<List<ResponseCompany>>(_autoMapper.Map<List<ResponseCompany>>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<List<ResponseCompany>>(string.Empty, ex.Message);
            }

        }

        public async Task<BaseResponse<ResponseCompany>> InsertAsync(RequestInsertCompany request)
        {
            try
            {
                var ent = _autoMapper.Map<Infrastructure.Data.Entities.Company>(request);
                ent.CreatedOnAuditing(request.CreatedBy);
                var returnModel = await _companyRepository.InsertAsync(ent);
                return new BaseResponse<ResponseCompany>(_autoMapper.Map<ResponseCompany>(returnModel));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<ResponseCompany>(string.Empty, ex.Message);
            }

        }
        public async Task<BaseResponse<ResponseCompany>> UpdateAsync(RequestUpdateCompany request)
        {
            try
            {
                var ent = _autoMapper.Map<Infrastructure.Data.Entities.Company>(request);
                ent.UpdatedOnAuditing(request.UpdatedBy);
               var response= await _companyRepository.UpdateAsync(ent);
                return new BaseResponse<ResponseCompany>(_autoMapper.Map<ResponseCompany>(response)); 
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<ResponseCompany>(string.Empty, ex.Message);
            } 
        }
        public async Task DeleteAsync(int id)
        {
            await _companyRepository.Delete(x => x.Id == id);
        }
    }
}
