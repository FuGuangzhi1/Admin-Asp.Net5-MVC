using System.Text;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model.ViewModel;
using StudyMVCFu.Model.DomainModel;
using StudyMVCFu.Model;
using WebApplication.AOP;

namespace WebApplication.Controllers
{
    /// <summary>
    /// 学习知识记录
    /// </summary>
    public class StudyController : Controller
    {
        private readonly IStudy _study;

        public StudyController(IStudy study)
        {
            this._study = study;
        }

        public IActionResult Studyknowledge()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> StudyknowledgeData
            ([FromQuery] string name, [FromQuery] int stydyTypeId, [FromQuery] int pageSize, [FromQuery] int pageIndex)
        {
            PageResult<StudyKnowledgeView> data = new();
            data = await this._study.GetStudyKnowledgeAsync
                (StudyKnowledgeName: name, stydyTypeId: stydyTypeId, pageSize: pageSize, pageIndex: pageIndex);
            return Json(data: data);
        }
        [HttpGet]
        public async Task<IActionResult> StudyTypeData()
        {
            List<StudyType> data = new();
            data = await this._study.GetStudyTypeAsync();
            return Json(data: data);
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> UpdateOrInsertStudyTypeData
               ([FromForm] StudyKnowledgeForm studyKnowledgeForm)
        {
            AjaxResult result = new();
            if (studyKnowledgeForm == null) return Json(data: result);
            Studyknowledge studyknowledge = new()
            {
                StudyknowledgeContent = studyKnowledgeForm.StudyknowledgeContent,
                StudyTypeId = studyKnowledgeForm.StudyTypeId,
                StudyknowledgeName = studyKnowledgeForm.StudyknowledgeName,
                UpdateDateTime = DateTime.Now,
                CreateDateTime = studyKnowledgeForm.CreateDateTime
            };
            if (studyKnowledgeForm.StudyknowledgeId != null && studyKnowledgeForm.StudyknowledgeId != Guid.Empty)
                studyknowledge.StudyknowledgeId = (Guid)studyKnowledgeForm.StudyknowledgeId;
            result = await this._study.UpdateOrInsertStudyTypeDataAsync(studyknowledge);
            return Json(data: result);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStudyTypeData([FromForm] Guid id)
        {
            AjaxResult result = new();
            result = await _study.DeleteStudyTypeDataAsync(id);
            return Json(data: result);
        }
    }
}
