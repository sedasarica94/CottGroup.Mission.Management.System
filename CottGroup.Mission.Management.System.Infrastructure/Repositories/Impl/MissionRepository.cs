using CottGroup.Mission.Management.System.Infrastructure.Data;
using CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.Impl
{
    public class MissionRepository : EntityFrameworkRepository<Data.Entities.Mission>, IMissionRepository
    {
        public MissionRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
