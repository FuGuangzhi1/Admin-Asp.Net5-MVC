using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model.DomainModel
{
    public class Studyknowledge
    {
        public Guid StudyknowledgeId { get; set; }
        [StringLength(50, ErrorMessage = "It's too long ,please be less than 50")]
        public string StudyknowledgeName { get; set; }
        [StringLength(500, ErrorMessage = "It's too long ,please be less than 500")]
        public string StudyknowledgeContent { get; set; }
        public StudyType StudyType { get; set; }
        public int StudyTypeId { get; set; }
    }
}
