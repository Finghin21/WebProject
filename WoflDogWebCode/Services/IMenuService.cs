using System.Collections.Generic;
using WoflDogWebCode.Models;

namespace WoflDogWebCode.Services
{
    public interface IMenuService
    {
        List<Menu> GetMenus();
        Menu GetMenu();
        void AddMenu(Menu menu);
        void UpdateMenu(Menu menu);
        void DeleteMenu(int id);
    }
}
