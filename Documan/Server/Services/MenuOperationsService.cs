using Documan.Server.Repositories;
using Documan.Shared.Models;
using System.Xml.Linq;

namespace Documan.Server.Services
{
    public class MenuOperationsService
    {
        // Üst Seviyeleri Ayarla
        public List<SideMenuListModel> getUpLevelsLookUp()
        {
            MenuOperationsRepository rep = new MenuOperationsRepository();

            List<SideMenuListModel> res = rep.getUpLevelsLookUp();
            return res;
        }


       // Alt Seviyeleri Ayarla
        public List<SideMenuListModel> getSubLevelsLookUp(string upLevelValue)
        {
            MenuOperationsRepository rep = new MenuOperationsRepository();

            List<SideMenuListModel> res = rep.getSubLevelsLookUp(upLevelValue);
            return res;
        }

        // Menu Ekleme 
        public string addMenuItem(string levelValue, string upLevelValue, string desc, string menuOrder, string auth)
        {
            MenuOperationsRepository rep = new MenuOperationsRepository();

            string res = rep.addMenuItem(levelValue, upLevelValue, desc, menuOrder, auth);
            return res;
        }

    }




}

