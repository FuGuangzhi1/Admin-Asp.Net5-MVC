using StudyMVCFu.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Interface.DomainInterface
{
    public interface IHomePage
    {
        public Task<List<MenuDto>> GetmenuList();
    }
}
