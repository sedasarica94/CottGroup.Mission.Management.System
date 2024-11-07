
using CottGroup.Mission.Management.System.Infrastructure.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl
{
    [Serializable]
    public class EntityBase : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
    }
}
