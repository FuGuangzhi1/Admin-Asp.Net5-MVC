using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model
{
    public class PageResult<T> : AjaxResult
    {
        public PageResult()
        {
            Rows = new List<T>();
        }
        public int Total { get; set; }
        public List<T> Rows { get; set; }
    }
}
