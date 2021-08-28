using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model.ViewModel
{
    public class StudyKnowledgeForm
    {
        public Guid studyknowledgeId { get; set; } = Guid.Empty;
        public int studyTypeId { get; set; }
        public string studyknowledgeName { get; set; }
        public string studyknowledgeContent { get; set; }
        public DateTime? CreateDateTime { get; set; }
    }
}
