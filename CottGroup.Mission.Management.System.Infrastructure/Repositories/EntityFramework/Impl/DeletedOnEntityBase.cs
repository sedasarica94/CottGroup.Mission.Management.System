
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl
{
    public class DeletedOnEntityBase : UpdatedOnEntityBase  
    {
        [Column("isdeleted")]
        public virtual bool IsDeleted { get; set; }

        public virtual void DeletionAuditing() => this.IsDeleted = true;

    
    }
     
}
