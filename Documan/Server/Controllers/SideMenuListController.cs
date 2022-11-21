using Documan.Server.Repositories;
using Documan.Server.Services;
using Documan.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Documan.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SideMenuListController : ControllerBase
    {

        private readonly IServiceProvider _serviceProvider;
        private MenuService _getService { get; set; }

        public SideMenuListController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            this._getService = _serviceProvider.GetRequiredService<MenuService>();
        }

        [HttpGet]
        [Route("SideMenuGetList")]
        public IActionResult SideMenuGetList()
        {
            return Ok(new ResponseModel { data = _getService.SideMenuGetList(), success = true });
        }


    }
}
