using CottGroup.Mission.Management.System.Services.UserComponents.Responses;

namespace CottGroup.Mission.Management.System.Services.TokenComponents
{
    public interface ITokenService
    {
        string GenerateToken(ResponseUser user);
    }
}
