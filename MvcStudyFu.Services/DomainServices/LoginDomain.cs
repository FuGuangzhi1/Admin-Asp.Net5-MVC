using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Common;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStudyFu.Services.DomainServices
{
    public class LoginDomain : BaseService, ILoginDomain
    {
        public LoginDomain(IDbContextFactory contextFactory) : base(contextFactory)
        {
            this._contextFactory = contextFactory;
        }
        public async Task<(bool, Guid?)> GetUserasync(string name, string password)
        {
            Guid? id = Guid.Empty;
            bool iswater = false;
            //User UserEntity1 =  base.Query<User>(x=>x.Name==name).FirstOrDefault();
            User UserEntity = await base._readDbContext?.User.Where(x => x.Name == name).Include("UserPassword").FirstOrDefaultAsync();
            if (UserEntity != null)
            {
                iswater = await base._readDbContext?.UserPassword.Select(x => x.NewPassword == password.ToMD5() & x.UserId == UserEntity.Id).FirstOrDefaultAsync();
                if (iswater) id = UserEntity.Id;
            }
            await base._readDbContext.DisposeAsync();
            await base._writeDbContext.DisposeAsync();
            return new(iswater, id);
        }
    }
}