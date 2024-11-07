
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl
{
    public class CreatedOnEntityBase : EntityBase
    {
        [Column("createdon")]
        public virtual DateTime? CreatedOn { get; set; }
        [Column("createdby")]
        public virtual int? CreatedBy { get; set; }

        public virtual void CreatedOnAuditing(int createdBy)
        {
            CreatedOn = DateTime.Now;
            if (createdBy.Equals(0))
                return;
            CreatedBy = createdBy;
        }
    }
}
