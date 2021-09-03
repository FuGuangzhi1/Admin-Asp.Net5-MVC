using Microsoft.EntityFrameworkCore;
using MvcStudyFu.Common;
using MvcStudyFu.Common.ConvertTpye;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model;
using StudyMVCFu.Model.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStudyFu.Services.DomainServices
{
    public class LoginDomain : BaseService, ILoginDomain
    {
        public LoginDomain(IDBContextFactory dBContextFactory) : base(dBContextFactory) { }

        public async Task<List<string>> GetRole(Guid? id)
        {
            List<Guid> roleIds = await (await base.QueryAsync<UserRole>(x=>x.UserId==id)).Select(x=>x.RoleId).ToListAsync();
            List<string> roleNames =await (await base.QueryAsync<Role>(x => roleIds.Contains(x.RoleId))).Select(x => x.RoleName).ToListAsync();
            return roleNames;
        }

        public async Task<(bool, Guid?)> GetUserasync(string name, string password)
        {
            int account = name.ToInt32();
            Guid? id = Guid.Empty;
            bool iswater = false;
            User UserEntity;
            if (account == 0)
            {
                UserEntity = await base.Query<User>(x => x.Name == name)
                    .FirstOrDefaultAsync();
            }
            else
            {
                UserEntity = await base.Query<User>(x => x.Account == (ulong)account)
                    .FirstOrDefaultAsync();
            }
            if (UserEntity != null)
            {
                iswater = await base.Set<UserPassword>().Select(x => x.NewPassword == password.ToMD5() & x.UserId == UserEntity.Id).FirstOrDefaultAsync();
                if (iswater) id = UserEntity.Id;
            }
            await base.DisposeAsync();
            return new(iswater, id);
        }
    }
}