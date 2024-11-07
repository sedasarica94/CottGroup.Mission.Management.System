using CottGroup.Mission.Management.System.Infrastructure.Data;
using CottGroup.Mission.Management.System.Infrastructure.Data.Entities;
using CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.Impl
{
    public class UserRepository : EntityFrameworkRepository<User>, IUserRepository
    {

        public UserRepository(DataContext dbContext) : base(dbContext)
        {

        }
         
    }
}
