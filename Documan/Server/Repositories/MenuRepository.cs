using Documan.Server.Helpers;
using Documan.Shared.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Documan.Server.Repositories
{
    public class MenuRepository
    {
        SqlConnection rep;
        public MenuRepository()
        {
            rep = new SqlConnection(Common.getConnStr());
        }

        public List<SideMenuListModel> SideMenuGetList()
        {
            string sql = $@"
                             SELECT * FROM tbl_sys_menu With (nolock)
                             Order By menu_level, menu_order						
                          ";
            List<SideMenuListModel> res = rep.Query<SideMenuListModel>(sql).ToList();
            return res;
        }


    }
}
