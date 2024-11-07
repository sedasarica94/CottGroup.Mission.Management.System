using CottGroup.Mission.Management.System.Infrastructure.Enums;
using CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl;
using System.ComponentModel.DataAnnotations.Schema;

namespace CottGroup.Mission.Management.System.Infrastructure.Data.Entities
{
    [Table("missions")]
    public class Mission : ActiveOnEntityBase
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("details")]
        public string Details { get; set; }

        [Column("estimatedhourscost")]
        public int EstimatedHoursCost { get; set; }

        [Column("efforthourscost")]
        public int EffortHoursCost { get; set; }

        [Column("priority")]
        public int Priority { get; set; }

        [Column("status")]
        public MissionStatusType Status { get; set; }

        [Column("comment")]
        public string Comment { get; set; }

        [Column("projectid")]
        public int ProjectId { get; set; }

        [Column("userid")]
        public int UserId { get; set; }


        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}
