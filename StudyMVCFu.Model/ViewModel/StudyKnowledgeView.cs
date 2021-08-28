using StudyMVCFu.Model.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model.ViewModel
{

/// <summary>
/// 学习表视图
/// </summary>
   
       public class StudyKnowledgeView: Studyknowledge
    {
        public new Guid? StudyknowledgeViewId { get; set; }
        public string StudyknowledgeNameType { get; set; }
    }
}
