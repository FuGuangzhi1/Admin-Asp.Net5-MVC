using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using StudyMVCFu.Model.DomainModel;
using System.Collections.Generic;

namespace StudyMVCFu.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("User")]
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "plaese input UserName")]
        [StringLength(20, ErrorMessage = "It's too long ,please be less than 20")]
        public string Name { get; set; }
        [Required(ErrorMessage = "plaese input Account")]
        [StringLength(20, ErrorMessage = "It's too long ,please be less than 20")]
        public ulong? Account { get; set; }
        [StringLength(20)]
        public string Moblie { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public ulong? QQ { get; set; }
        [StringLength(400)]
        public string Hobby { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDateTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdateDateTime { get; set; }
        public UserPassword UserPassword { get; set; }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        public Nullable<bool> IsDel { get; set; }
        public List<LogRecord> LogRecord { get; set; }
    }
}
