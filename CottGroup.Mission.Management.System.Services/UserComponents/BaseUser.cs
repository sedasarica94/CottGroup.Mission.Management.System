using CottGroup.Mission.Management.System.Infrastructure.Models.Enums;

namespace CottGroup.Mission.Management.System.Services.UserComponents
{
    public class BaseUser
    {
        public string Username { get; set; }
        public UserRoleTypes Role { get; set; }
        public int? CompanyId { get; set; }
    }
}
