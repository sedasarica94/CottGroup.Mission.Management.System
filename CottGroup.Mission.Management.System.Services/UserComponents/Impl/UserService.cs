using AutoMapper;
using CottGroup.Mission.Management.System.Core.Base;
using CottGroup.Mission.Management.System.Infrastructure.Repositories;
using CottGroup.Mission.Management.System.Services.UserComponents.Requests;
using CottGroup.Mission.Management.System.Services.UserComponents.Responses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Services.UserComponents.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _autoMapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _autoMapper = mapper;
        }


        public async Task<BaseResponse<List<ResponseUser>>> GetAllActiveAsync()
        {
            try
            {
                var response = await _userRepository.GetAllAsync(x => !x.IsDeleted && x.IsActive);
                return new BaseResponse<List<ResponseUser>>(_autoMapper.Map<List<ResponseUser>>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<List<ResponseUser>>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<List<ResponseUser>>> GetAllAsync()
        {
            try
            {
                var response = await _userRepository.GetAllAsync(x => !x.IsDeleted);
                return new BaseResponse<List<ResponseUser>>(_autoMapper.Map<List<ResponseUser>>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<List<ResponseUser>>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<ResponseUser>> InsertAsync(RequestInsertUser request)
        {
            try
            {
                var ent = _autoMapper.Map<Infrastructure.Data.Entities.User>(request);
                ent.CreatedOnAuditing(request.CreatedBy);
                var returnModel = await _userRepository.InsertAsync(ent);
                return new BaseResponse<ResponseUser>(_autoMapper.Map<ResponseUser>(returnModel));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<ResponseUser>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<ResponseUser>> UpdateAsync(RequestUpdateUser request)
        {
            try
            {
                var ent = _autoMapper.Map<Infrastructure.Data.Entities.User>(request);
                ent.UpdatedOnAuditing(request.UpdatedBy);
                var response = await _userRepository.UpdateAsync(ent);
                return new BaseResponse<ResponseUser>(_autoMapper.Map<ResponseUser>(response));
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<ResponseUser>(string.Empty, ex.Message);
            }
        }

        public async Task<BaseResponse<ResponseUser>> GetUserInfoAsync(string username, string password)
        {
            try
            {
            var user =await _userRepository.Query(x => x.Username == username && x.Password == password).FirstOrDefaultAsync();
            if (user is not null)
                return new BaseResponse<ResponseUser>(_autoMapper.Map<ResponseUser>(user));

                return new BaseResponse<ResponseUser>(string.Empty,"Kullanıcı bulunamadı");
            }
            catch (global::System.Exception ex)
            {
                return new BaseResponse<ResponseUser>(string.Empty, ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.Delete(x => x.Id == id);
        }


    }
}
