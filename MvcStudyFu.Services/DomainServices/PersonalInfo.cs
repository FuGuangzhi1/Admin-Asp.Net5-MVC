using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Common.ConvertTpye;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Services.DomainServices
{
    public class PersonalInfo : BaseService, IPersonalInfo
    {
        public PersonalInfo(IDBContextFactory dBContextFactory) : base(dBContextFactory)
        {
        }

        public async Task<User> FindIdUser(string id)
        {
            return await (await base.QueryAsync<User>(x => x.Id == id.ToGuid())).FirstOrDefaultAsync();
        }
    }
}
