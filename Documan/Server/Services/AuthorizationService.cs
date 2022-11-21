using Documan.Shared.Models;

namespace Documan.Server.Services
{
    public class AuthorizationService
    {
        private List<LoginCheckModel> _userAccountList;
        private LoginCheckModel user;

        public void createUser(LoginCheckModel _user)
        {
            user = _user;
        }

        public LoginCheckModel getUser()
        {
            return user;
        }
    }

}
