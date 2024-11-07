using CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CottGroup.Mission.Management.System.Infrastructure.Data.Entities
{
    [Table("projects")]
    public class Project: ActiveOnEntityBase
    { 
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("companyid")]
        public int CompanyId { get; set; }


        public virtual Company Company { get; set; }
        public virtual List<Mission> Missions { get; set; } 
    }
}
