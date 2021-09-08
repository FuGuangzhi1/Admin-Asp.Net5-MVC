using StudyMVCFu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Interface.DomainInterface
{
    public interface IPersonalInfo
    {
        /// <summary>
        /// 更具id查用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  Task<User> FindIdUser(string id);
    }
}
