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

namespace WebApplication.Controllers
{
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
        public async Task<IActionResult> StudyknowledgeData(String name,int stydyTypeId, int pageSize, int pageIndex)
        {
            PageResult<StudyKnowledgeView> data = new();
            data = await _study.GetStudyKnowledge
                (StudyKnowledgeName: name,stydyTypeId: stydyTypeId, pageSize: pageSize, pageIndex:pageIndex);
            return Json(data: data);
        }
        [HttpGet]
        public async Task<IActionResult> StudyTypeData()
        {
            List<StudyType> data = new();
            data = await _study.GetStudyType();
            return Json(data: data);
        }
    }
}
