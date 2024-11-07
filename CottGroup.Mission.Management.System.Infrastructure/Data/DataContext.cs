using CottGroup.Mission.Management.System.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CottGroup.Mission.Management.System.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Entities.Mission> Missions { get; set; }  
    }
}
