using CottGroup.Mission.Management.System.Infrastructure.Data.Entities;
using CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    { 
    }
}
