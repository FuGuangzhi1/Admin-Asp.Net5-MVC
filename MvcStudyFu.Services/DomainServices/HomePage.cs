using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MvcStudyFu.EFCore.SQLSever;
using MvcStudyFu.Interface.DomainInterface;
using StudyMVCFu.Model.DomainModel;
using StudyMVCFu.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStudyFu.Services.DomainServices
{
    public class HomePage : BaseService, IHomePage
    {
        public HomePage(IDBContextFactory dBContextFactory) : base(dBContextFactory) { }
        public async Task<List<MenuDto>> GetmenuList()
        {
            IQueryable<Resource> resourceable = await base.SetAsync<Resource>();
            List<Resource> resourcesList =await resourceable.ToListAsync();
            List<MenuDto> menuDtos=new();
            return GetMenuDto(resourcesList, null,menuDtos);
        }

        private List<MenuDto> GetMenuDto(IEnumerable<Resource> Resources, Guid? parentId, List<MenuDto> menuDtos)
        {
            var nextMenuList = Resources.Where(x => x.ParentId == parentId); //菜单

            foreach (var menu in nextMenuList)  //遍历给当前级菜单加子菜单
            {
                MenuDto currentMenuDto = new()
                {
                    MenuId = menu.ResourceId,
                    MenuName = menu.ResourceName,
                    Icon = menu.Icon,
                    Level = menu.Level,
                    Path = menu.Path,
                    ParentId = menu.ParentId,
                    Sort = menu.Sort
                };
                //当前的下一级菜单
                List<Resource> resources = Resources.Where(m => m.ParentId != parentId).ToList(); 
                GetMenuDto(resources, menu.ResourceId, currentMenuDto.Children);
                menuDtos.Add(currentMenuDto);
            }

            return menuDtos;
        }
    }
}
