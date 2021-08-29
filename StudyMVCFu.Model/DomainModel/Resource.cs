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
    /// 资源表
    /// </summary>
    [Table("Resource")]
    public class Resource
    {
        [Key]
        public Guid ResourceId { get; set; }
        [Required]
        public string ResourceName { get; set; }
        public Guid? ParentId { get; set; }
        public long Level { get; set; }
    }
}