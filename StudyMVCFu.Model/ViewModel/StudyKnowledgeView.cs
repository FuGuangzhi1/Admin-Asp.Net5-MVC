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
   
       public class StudyKnowledgeView
    {
        public int StudyTypeId { get; set; }
        public Guid StudyknowledgeId { get; set; }
        public string StudyknowledgeName { get; set; }
        public string StudyknowledgeContent { get; set; }
        public string StudyknowledgeNameType { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
