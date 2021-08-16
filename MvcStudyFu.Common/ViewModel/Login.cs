using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Common
{
   public class Login
    {
        [Required(ErrorMessage = "plaese input UserName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "plaese input Password")]
        [StringLength(64, ErrorMessage = "It's too long ,please be less than 64")]
        public string Password { get; set; }
        [Required(ErrorMessage = "plaese input CheckCode")]
        public string CheckCode { get; set; }
    }
}
