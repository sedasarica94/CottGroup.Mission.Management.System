using AutoMapper;
using CottGroup.Mission.Management.System.Services.CompanyComponents.Requests;
using CottGroup.Mission.Management.System.Services.CompanyComponents.Responses;
using CottGroup.Mission.Management.System.Services.MissionComponents.Requests;
using CottGroup.Mission.Management.System.Services.MissionComponents.Responses;
using CottGroup.Mission.Management.System.Services.ProjectComponents.Requests;
using CottGroup.Mission.Management.System.Services.ProjectComponents.Responses;
using CottGroup.Mission.Management.System.Services.UserComponents.Requests;
using CottGroup.Mission.Management.System.Services.UserComponents.Responses;

namespace CottGroup.Mission.Management.System.Services.Mapping
{
    public class RegisterMapping : Profile
    {
        public RegisterMapping()
        {
            CreateMap<RequestInsertCompany, Infrastructure.Data.Entities.Company>();
            CreateMap<Infrastructure.Data.Entities.Company, ResponseCompany>();
            CreateMap<RequestUpdateCompany, Infrastructure.Data.Entities.Company>();

            CreateMap<RequestUpdateProject, Infrastructure.Data.Entities.Project>();
            CreateMap<RequestInsertProject, Infrastructure.Data.Entities.Project>();
            CreateMap<Infrastructure.Data.Entities.Project,ResponseProject>();
           
            CreateMap<RequestUpdateMission, Infrastructure.Data.Entities.Mission>();
            CreateMap<RequestInsertMission, Infrastructure.Data.Entities.Mission>();
            CreateMap<Infrastructure.Data.Entities.Mission, ResponseMission>();
            
            CreateMap<RequestUpdateUser, Infrastructure.Data.Entities.User>();
            CreateMap<RequestInsertUser, Infrastructure.Data.Entities.User>();
            CreateMap<Infrastructure.Data.Entities.User, ResponseUser>();


        }

    }
}
