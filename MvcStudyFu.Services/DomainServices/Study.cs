using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model;
using StudyMVCFu.Model.DomainModel;
using StudyMVCFu.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LinqToDB.Reflection.Methods.LinqToDB.Insert;

namespace MvcStudyFu.Services.DomainServices
{
    public class Study : BaseService, IStudy
    {
        private readonly IDBContextFactory _dBContextFactory;

        public Study(IDBContextFactory dBContextFactory) : base(dBContextFactory)
        {
            this._dBContextFactory = dBContextFactory;
        }
        public async Task<PageResult<StudyKnowledgeView>> GetStudyKnowledge
            (String StudyKnowledgeName, int stydyTypeId, int pageSize, int pageIndex)
        {
            var DBCotent = _dBContextFactory.CreateDbContext(ReadWriteEnum.Read);
            PageResult<StudyKnowledgeView> pageResult = new();       
            IQueryable<StudyKnowledgeView> noPage = from a in DBCotent.Set<Studyknowledge>()
                                                    join b in DBCotent.Set<StudyType>()
                                                    on a.StudyTypeId equals b.StudyTypeId
                                                    select new StudyKnowledgeView()
                                                    {
                                                        StudyknowledgeContent = a.StudyknowledgeContent,
                                                        StudyknowledgeName = a.StudyknowledgeName,
                                                        StudyknowledgeId = a.StudyknowledgeId,
                                                        CreateDateTime = a.CreateDateTime,
                                                        UpdateDateTime = a.UpdateDateTime,
                                                        StudyTypeId = b.StudyTypeId,
                                                        StudyknowledgeNameType = b.StudyTypeName,
                                                    };
            if (!string.IsNullOrEmpty(StudyKnowledgeName))
            {
                noPage = noPage.Where(x => x.StudyknowledgeName == StudyKnowledgeName);
            }
            if (stydyTypeId != 0)
            {
                noPage = noPage.Where(x => x.StudyTypeId == stydyTypeId);
            }
            if (noPage != null)
            {
                pageResult.Total = noPage.Count();
                int offset = (pageIndex - 1) * pageSize; //当前页面
                pageResult.Rows = await noPage.OrderByDescending(x => x.CreateDateTime).Skip(offset).Take(pageSize).ToListAsync();
            }
            return pageResult;
        }

        public async Task<List<StudyType>> GetStudyType()
        {
            List<StudyType> data = new();
            IQueryable<StudyType> StudyType = base.Set<StudyType>();
            if (StudyType != null)
                data = await StudyType.ToListAsync();
            return data;
        }
    }
}
