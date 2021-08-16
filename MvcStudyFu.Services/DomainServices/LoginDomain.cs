using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MvcStudyFu.Common;
using MvcStudyFu.Common.Enum;
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

        public LoginDomain(IDbContextFactory contextFactory) : base(contextFactory)
        {

            this._contextFactory = contextFactory;
        }
        public async Task<(bool,User)> GetUserasync(string name, string password)
        {
            User UserEntity = new User() {Id=Guid.Empty};
            bool Iswater=false;
             UserEntity =await _contextFactory.CreateDbContext(ReadWriteEnum.Read).User.Where(x=>x.Name==name).FirstOrDefaultAsync();
            if (UserEntity != null)
            {
                 Iswater = UserEntity.UserPassword.NewPassword == password;
            }
            return new (Iswater,UserEntity);
        }
    }
}