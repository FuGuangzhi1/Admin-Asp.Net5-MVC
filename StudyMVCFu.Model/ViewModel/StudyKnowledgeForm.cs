using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model.ViewModel
{
    public class StudyKnowledgeForm
    {
        public Guid? StudyknowledgeId { get; set; } = Guid.Empty;
        public int StudyTypeId { get; set; }
        public string StudyknowledgeName { get; set; }
        public string StudyknowledgeContent { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
