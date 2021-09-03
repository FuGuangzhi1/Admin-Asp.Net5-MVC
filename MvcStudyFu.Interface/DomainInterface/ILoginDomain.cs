using MvcStudyFu.EFCore;
using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Interface.DomainInterface
{
    public interface ILoginDomain
    {
        /// <summary>
        /// 账号密码判断用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<(bool, Guid?)> GetUserasync(string name, string password);
        /// <summary>
        /// 获得角色
        /// </summary>
        /// <returns></returns>
        public Task<List<string>> GetRole(Guid? id);
    }
}
