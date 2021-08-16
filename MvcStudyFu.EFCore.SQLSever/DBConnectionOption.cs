using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.EFCore.SQLSever
{
    public class DBConnectionOption
    {
        public string MainConnectionString { get; set; }
        public List<string> SlaveConnectionStringList { get; set; }
    }
}
