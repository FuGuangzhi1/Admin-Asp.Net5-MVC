using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model.DomainModel
{
    /// <summary>
    /// 角色资源关系表
    /// </summary>
    [Table("RoleResouce")]
    public class RoleResouce
    {
        [Key]
        public Guid RoleResouceId { get; set; }
        public Guid RoleId { get; set; }
        public Guid ResourceId { get; set; }
        public Role Role { get; set; }
        public Resource Resource { get; set; }
    }
}
