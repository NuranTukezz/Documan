using Documan.Server.Repositories;
using Documan.Shared.Models;

namespace Documan.Server.Services
{
    public class MenuService
    {
        public List<SideMenuListModel> SideMenuGetList()
        {
            MenuRepository rep = new MenuRepository();

            List<SideMenuListModel> res = rep.SideMenuGetList();
            return res;
        }
    }
}
