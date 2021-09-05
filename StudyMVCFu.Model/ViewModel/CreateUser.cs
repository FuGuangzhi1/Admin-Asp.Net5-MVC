using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model.ViewModel
{
    public class CreateUser : User
    {
        public new Guid? Id { get; set; }
        public string Password { get; set; }

        public string Password1 { get; set; }

        public new int Sex { get; set; }
    }
}
