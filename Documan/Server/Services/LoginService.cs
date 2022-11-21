using Documan.Server.Repositories;
using Documan.Shared.Models;

namespace Documan.Server.Services
{
    public class LoginService
    {
        public ResponseModel RegisterUser(string userName, string password)
        {
            LoginRepository rep = new LoginRepository();

            ResponseModel res = rep.RegisterUser(userName, password);
            return res;
        }

        public ResponseModel ChangePass(string userName, string password)
        {
            LoginRepository rep = new LoginRepository();

            ResponseModel res = rep.ChangePass(userName, password);
            return res;
        }

        public LoginCheckModel checkUser(string userName, string password)
        {
            LoginRepository rep = new LoginRepository();

            LoginCheckModel res = rep.checkUser(userName, password);
            return res;
        }

    }
}
