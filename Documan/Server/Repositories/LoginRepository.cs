using Documan.Server.Helpers;
using Documan.Shared.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Documan.Server.Repositories
{
    public class LoginRepository
    {
        SqlConnection rep;

        public LoginRepository()
        {
            rep = new SqlConnection(Common.getConnStr());
        }

        public LoginCheckModel checkUser(string userName, string password)
        {      
            string newSql = $@"    SELECT username, password, auth_level
                                   FROM tbl_sys_user with(nolock)    
                                   WHERE username = '{userName}' AND password = '{password}' 
                                ";
            LoginCheckModel res = rep.Query<LoginCheckModel>(newSql).FirstOrDefault();

            return res;
        }

        public ResponseModel RegisterUser(string userName, string password)
        {
            ResponseModel resModel = new ResponseModel();

            string Sql = $@"       SELECT username
                                   FROM tbl_sys_user with(nolock)    
                                   WHERE username = '{userName}' 
                                ";
            LoginCheckModel newRes = rep.Query<LoginCheckModel>(Sql).FirstOrDefault();

            if (newRes != null && newRes.username == userName) // yani böyle bir kullanıcı varsa hata verdirt
            {
                resModel.success = false;
                return resModel;    
            }

            else if(newRes == null) //böyle bir kullanıcı yoksa insert yapsın
            {
                string newSql = $@" INSERT INTO tbl_sys_user(username, password, auth_level) VALUES('{userName}', '{password}', '1')";                                
                rep.Query<dynamic>(newSql);

                resModel.success = true;
            }

            return resModel;
        }

        public ResponseModel ChangePass(string userName, string password)
        {
            ResponseModel resModel = new ResponseModel();

            string Sql = $@"       SELECT username
                                   FROM tbl_sys_user with(nolock)    
                                   WHERE username = '{userName}' 
                                ";
            LoginCheckModel newRes = rep.Query<LoginCheckModel>(Sql).FirstOrDefault();

            if (newRes != null)
            {
                if (newRes.username != userName) //Kullanıcı adı hatalı büyük küçük kontrolü
                {
                    resModel.success = false;
                    return resModel;
                }

                string NewSql = $@"UPDATE tbl_sys_user
                                   SET password = '{password}'  
                                   WHERE username = '{userName}'
                                ";
                rep.Query<string>(NewSql).FirstOrDefault();
                resModel.success = true;
            }
            else
            {
                resModel.success = false;
            }

            return resModel;
        }
    }
}
