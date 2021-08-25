using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Common;
using MvcStudyFu.Common.ConvertTpye;
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
        public async Task<(bool, Guid?)> GetUserasync(string name, string password)
        {
            int account = name.ToInt32();
            Guid? id = Guid.Empty;
            bool iswater = false;
            User UserEntity;
            if (account == 0)
            {
                UserEntity = await base._DBContext?.User.Where(x => x.Name == name).Include("UserPassword").FirstOrDefaultAsync();
            }
            else
            {
                UserEntity = await base._DBContext?.User.Where(x => x.Account == (ulong)account).Include("UserPassword").FirstOrDefaultAsync();
            }
            if (UserEntity != null)
            {
                iswater = await base._DBContext?.UserPassword.Select(x => x.NewPassword == password.ToMD5() & x.UserId == UserEntity.Id).FirstOrDefaultAsync();
                if (iswater) id = UserEntity.Id;
            }
            await base._DBContext.DisposeAsync();
            return new(iswater, id);
        }
    }
}