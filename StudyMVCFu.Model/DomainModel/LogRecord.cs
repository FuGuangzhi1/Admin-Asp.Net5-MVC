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
    /// 日志记录表
    /// </summary>
    [Table("LogRecord")]
    public class LogRecord
    {
        [Key]
        public Guid LogRecordId { get; set; }
        public string LogRecordContent { get; set; }
        public string Weather { get; set; }
        public string Mood { get; set; }

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
