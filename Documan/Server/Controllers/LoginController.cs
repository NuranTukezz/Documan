using Documan.Server.Repositories;
using Documan.Server.Services;
using Documan.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Data.SqlClient;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Documan.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private LoginService _getService { get; set; }
        private AuthorizationService _getAuthService { get; set; }

        public LoginController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this._getService = _serviceProvider.GetRequiredService<LoginService>();
            this._getAuthService = _serviceProvider.GetRequiredService<AuthorizationService>();
        }

        [HttpGet]
        [Route("LoginCheck/{userName}/{password}")]
        public IActionResult LoginCheck(string username, string password)
        {
            ResponseModel resModel = new ResponseModel();

            try
            {
                LoginCheckModel res = _getService.checkUser(username, password);
                if (res != null) 
                {
                    if (res.username != username || res.password != password) //büyük küçük kontrolü
                    {
                        return Ok(new ResponseModel { data = "Kullanıcı Adı Veya Şifre Hatalı..!", success = false });
                    }

                    //Auth
                    _getAuthService.createUser(new LoginCheckModel { username = username, isValid = true });
                    //Auth

                    return Ok(new ResponseModel { data = res.auth_Level, success = true });
                }
                else
                {
                    return Ok(new ResponseModel { data = "Kullanıcı Adı Veya Şifre Hatalı..!", success = false });
                }
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { data = ex.Message, success = false });
            }
        }

        [HttpGet]
        [Route("RegisterCheck/{userName}/{password}")]
        public IActionResult RegisterCheck(string userName, string password)
        {

            try
            {
                ResponseModel res = _getService.RegisterUser(userName, password);

                if (res.success == true)
                {
                    return Ok(new ResponseModel { data = "Başarılı..!", success = true });
                }
                else
                {
                    return Ok(new ResponseModel { data = "Kullanıcı Adı Daha Önceden Alınmış..!", success = false });
                }
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { data = ex.Message, success = false });
            }
        }

        [HttpGet]
        [Route("ChangePass/{userName}/{password}")]
        public IActionResult ChangePass(string userName, string password)
        {
            try
            {
                ResponseModel res = _getService.ChangePass(userName, password);

                if (res.success == true)
                {
                    return Ok(new ResponseModel { data = "Başarılı..!", success = true });
                }
                else
                {
                    return Ok(new ResponseModel { data = "Kullanıcı Bulunamadı..!", success = false });
                }
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { data = ex.Message, success = false });
            }
        }
    }
}

