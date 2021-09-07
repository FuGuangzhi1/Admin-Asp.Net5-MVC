using StudyMVCFu.Model;
using StudyMVCFu.Model.DomainModel;
using StudyMVCFu.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Interface.DomainInterface
{
    public interface IStudy
    {
        /// <summary>
        /// 学习知识获取
        /// </summary>
        /// <param name="StudyKnowledgeName">知识·名称</param>
        /// <param name="stydyTypeId">知识类型ID</param>
        /// <param name="pageSize">显示页数</param>
        /// <param name="pageIndex">当前页</param>
        /// <returns></returns>
        public Task<PageResult<StudyKnowledgeView>>
            GetStudyKnowledgeAsync(String StudyKnowledgeName,int stydyTypeId, int pageSize, int pageIndex);
        /// <summary>
        /// 学习类型获取
        /// </summary>
        /// <returns></returns>
        public Task<List<StudyType>> GetStudyTypeAsync();
        /// <summary>
        /// 添加或者修改
        /// </summary>
        /// <param name="studyknowledge"></param>
        /// <returns></returns>
        public Task<AjaxResult> UpdateOrInsertStudyTypeDataAsync(Studyknowledge studyknowledge);
        /// <summary>
        ///  批量添加或者批量修改
        /// </summary>
        /// <param name="studyknowledge"></param>
        /// <returns></returns>
        public Task<AjaxResult> UpdateOrInsertStudyTypeDataAsync(IList<Studyknowledge> studyknowledge);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<AjaxResult> DeleteStudyTypeDataAsync(Guid id);
        /// <summary>
        /// 批量 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<AjaxResult> DeleteStudyTypeDataAsync(IList<Guid> id);

    }
}
