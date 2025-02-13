using System.Collections.Generic;
using System.Linq;
using WoflDogWebCode.Models;

namespace WoflDogWebCode.Services
{
    public class MenuService : IMenuService
    {
        private readonly DataContext _context;

        public MenuService(DataContext context)
        {
            _context = context;
        }

        public List<Menu> GetMenus()
        {
            return _context.Menus.ToList();
        }

    }
}
