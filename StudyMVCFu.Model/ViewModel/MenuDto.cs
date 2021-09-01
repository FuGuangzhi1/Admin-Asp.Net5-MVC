using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMVCFu.Model.ViewModel
{
    public class MenuDto
    {
        public MenuDto() {
            Children = new List<MenuDto>();
        }
        public Guid MenuId { get; set; }
        public string MenuName { get; set; }
        public Nullable<Guid> ParentId { get; set; }
        public string Path { get; set; }
        public long Level { get; set; }   //层级
        public string Icon { get; set; }
        public int Sort { get; set; }
        public List<MenuDto> Children { get; set; }
    }
}
