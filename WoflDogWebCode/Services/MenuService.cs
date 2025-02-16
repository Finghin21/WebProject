using System.Collections.Generic;
using WoflDogWebCode.Models;
using System.Linq;

namespace WoflDogWebCode.Services
{
    public class MenuService : IMenuService
    {
        private readonly WoflDogWebCode.Models.ApplicationDbContext _context;

        public MenuService(WoflDogWebCode.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Menu> GetMenus()
        {
            return _context.Menus.ToList();
        }

        public Menu GetMenu()
        {
            // TODO: Implement the method to get a specific menu
            return null;
        }

        public void AddMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
        }

        public void UpdateMenu(Menu menu)
        {
            _context.Menus.Update(menu);
            _context.SaveChanges();
        }

        public void DeleteMenu(int id)
        {
            var menuToRemove = _context.Menus.Find(id);
            if (menuToRemove != null)
            {
                _context.Menus.Remove(menuToRemove);
                _context.SaveChanges();
            }
        }
    }
}
