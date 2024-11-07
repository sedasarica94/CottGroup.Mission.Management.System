using System.Collections.Generic;

namespace CottGroup.Mission.Management.System.AuthService.Models.Responses
{
    public class ResponseUserInfo
    {
        public int UserId { get; set; }
        public int Username { get; set; }
        public int Password { get; set; }
        public List<string> Claims { get; set; }
    }
}
