using Documan.Server.Helpers;
using Documan.Shared.Models;
using Dapper;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;

namespace Documan.Server.Repositories
{
    public class MenuOperationsRepository
    {
        SqlConnection rep;

        public MenuOperationsRepository()
        {
            rep = new SqlConnection(Common.getConnStr());
        }

        public List<SideMenuListModel> getUpLevelsLookUp()
        {
            string newSql = $@"   SELECT * FROM tbl_sys_menu With (nolock)
                                  WHERE menu_level = '0'
                                  Order By menu_level, menu_order	
                                ";
            List<SideMenuListModel> newRes = rep.Query<SideMenuListModel>(newSql).ToList();

            return newRes;
        }

        public List<SideMenuListModel> getSubLevelsLookUp(string upLevelValue)
        {
            string newSql = $@"   SELECT * FROM tbl_sys_menu With (nolock)
                                  WHERE up_level = '{upLevelValue}'
                                  Order By menu_level, menu_order	
                                ";
            List<SideMenuListModel> newRes = rep.Query<SideMenuListModel>(newSql).ToList();

            return newRes;
        }

        public string addMenuItem(string levelValue, string upLevelValue, string desc, string menuOrder, string auth)
        {
            string newSql = "";

            if (string.IsNullOrEmpty(upLevelValue) || upLevelValue == "null")
            { // Ana menüye ekleme yapmak
                newSql = $@"  
                   
                    INSERT INTO tbl_sys_menu(name, menu_level, up_level, menu_order, auth_level) VALUES('{desc}', '{levelValue}', '0', '{menuOrder}', {auth})
                ";
            }
            else
            { //Alt Menü
                newSql = $@"   
                   
                    INSERT INTO tbl_sys_menu(name, menu_level, up_level, menu_order) VALUES('{desc}', '{levelValue}', '{upLevelValue}', '{menuOrder}')
                ";
            }

            rep.Query<string>(newSql).FirstOrDefault();

            return "";
        }
    }
}
