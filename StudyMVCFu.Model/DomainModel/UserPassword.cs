using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model
{
    /// <summary>
    /// 用户密码表
    /// </summary>
    [Table("UserPassword")]
    public class UserPassword
    {
        [Key]
        public Guid UserPasswordId { get; set; }

        [Required(ErrorMessage = "plaese input Password")]
        [StringLength(64, ErrorMessage = "It's too long ,please be less than 64")]
        public string NewPassword { get; set; }

        [StringLength(64, ErrorMessage = "It's too long ,please be less than 64")]
        public string LastPassword { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdateDateTime { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
