using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model
{
    public class DBConnectionOption
    {
        public string MainConnectionString { get; set; }
        public List<string> SlaveConnectionStringList { get; set; }
    }
}
