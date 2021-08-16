using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MvcStudyFu.Common;
using MvcStudyFu.Common.Enum;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.EFCore.SQLSever.DomainModel;
using MvcStudyFu.Interface;
using MvcStudyFu.Interface.DomainInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Services.DomainServices
{
    public class LoginDomain : BaseService, ILoginDomain
    {
        private readonly IDbContextFactory _contextFactory;
        StudyMVCDBContext _dbContext = null;
        public LoginDomain(IDbContextFactory contextFactory) : base(contextFactory)
        {

            this._contextFactory = contextFactory;
        }
        public async Task<(bool, Guid?)> GetUserasync(string name, string password)
        {
            _dbContext = _contextFactory.CreateDbContext(ReadWriteEnum.Read);
            Guid? id = Guid.Empty;
            bool iswater = false;
            User UserEntity = await _dbContext.User.Where(x => x.Name == name).Include("UserPassword").FirstOrDefaultAsync();
            if (UserEntity != null)
            {
                iswater = await _dbContext.UserPassword.Select(x => x.NewPassword == password.ToMD5() & x.UserId == UserEntity.Id).FirstOrDefaultAsync();
                if (iswater) id = UserEntity.Id;
            }
            await _dbContext.DisposeAsync();
            return new(iswater, id);
        }
    }
}