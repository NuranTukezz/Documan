using Documan.Server.Helpers;
using Documan.Server.Repositories;
using Documan.Server.Services;
using Documan.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Documan.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController: ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private AuthorizationService _getService { get; set; }

        public AuthorizationController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this._getService = _serviceProvider.GetRequiredService<AuthorizationService>();
        }

        [HttpGet]
        [Route("CheckAuth")]
        public IActionResult CheckAuth()
        {
            var user = _getService.getUser();
            if (user == null || !user.isValid)
            {
                return Ok(new ResponseModel { data = "Yetkili Değilsiniz..!", success = false });
            }
            else
            {
                return Ok(new ResponseModel { success = true });
            }
        }

    }
}
