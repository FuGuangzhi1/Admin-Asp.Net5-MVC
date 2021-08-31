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
    /// 角色表
    /// </summary>
    [Table("Role")]
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string RoleDescribe { get; set; }
    }
}
