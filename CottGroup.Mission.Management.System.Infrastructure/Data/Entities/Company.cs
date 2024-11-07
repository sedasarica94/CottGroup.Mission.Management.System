using CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CottGroup.Mission.Management.System.Infrastructure.Data.Entities
{
    [Table("company")]
    public class Company : ActiveOnEntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("projectlimit")]
        public int ProjectLimit { get; set; }

        [Column("userlimit")]
        public int UserLimit { get; set; }

         
        public virtual List<Project> Projects { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
