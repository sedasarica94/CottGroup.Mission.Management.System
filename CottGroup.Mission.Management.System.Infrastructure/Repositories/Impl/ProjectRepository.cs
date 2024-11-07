using CottGroup.Mission.Management.System.Infrastructure.Data;
using CottGroup.Mission.Management.System.Infrastructure.Data.Entities;
using CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.Impl
{
    public class ProjectRepository : EntityFrameworkRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext dbContext):base(dbContext)
        {

        }
    }
}
