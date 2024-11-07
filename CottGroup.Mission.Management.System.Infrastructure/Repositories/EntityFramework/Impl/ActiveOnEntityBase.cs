
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl
{
    [Serializable]
    public class ActiveOnEntityBase : DeletedOnEntityBase
    {
        [Column("isactive")]
        public bool IsActive { get; set; }

        public virtual void ActiveAuditing(bool isActive = true) => this.IsActive = isActive;
    }
}
