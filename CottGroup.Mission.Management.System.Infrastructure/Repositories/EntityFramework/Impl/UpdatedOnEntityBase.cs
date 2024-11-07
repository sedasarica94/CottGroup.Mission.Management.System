using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl
{
    public class UpdatedOnEntityBase :CreatedOnEntityBase
    {
        [Column("updatedon")]
        public virtual DateTime? UpdatedOn { get; set; }
        [Column("updatedby")]
        public virtual int? UpdatedBy { get; set; }

        public virtual void UpdatedOnAuditing(int updateBy)
        {
            UpdatedOn = DateTime.Now;
            if (updateBy.Equals(0))
                return;
            UpdatedBy = updateBy;
        }
    }
}
