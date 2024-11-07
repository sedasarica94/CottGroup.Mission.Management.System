using CottGroup.Mission.Management.System.Infrastructure.Models.Enums;
using CottGroup.Mission.Management.System.Infrastructure.Repositories.EntityFramework.Impl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CottGroup.Mission.Management.System.Infrastructure.Data.Entities
{
    [Table("users")]
    public class User : ActiveOnEntityBase
    {
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("role")]
        public UserRoleTypes Role { get; set; }
        [Column("companyid")]
        public int? CompanyId { get; set; }

        public virtual List<Data.Entities.Mission> Missions { get; set; }
        public virtual Company Company { get; set; }
    }
}
