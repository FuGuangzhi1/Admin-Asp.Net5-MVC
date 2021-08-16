using MvcStudyFu.EFCore.SQLSever.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Interface.DomainInterface
{
   public interface ILoginDomain
    {
        public Task<(bool,User)> GetUserasync(string name, string password); 
    }
}
