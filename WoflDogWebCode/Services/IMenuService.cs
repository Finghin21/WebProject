using System.Collections.Generic;
using WoflDogWebCode.Models;

namespace WoflDogWebCode.Services
{
    public interface IMenuService
    {
        List<Menu> GetMenus();
    }
}
