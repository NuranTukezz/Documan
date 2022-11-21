using Documan.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Documan.Shared.Models;
using Documan.Server.Services;
using System.Net;

namespace Documan.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuOperationsController : ControllerBase
    {
        //içerik dosyalarını içeren dizinin mutlak yolunu alır veya ayarlar.
        private readonly IWebHostEnvironment _env; //file 

        private readonly IServiceProvider _serviceProvider;
        private  MenuOperationsService _getService { get; set; } //db

        public MenuOperationsController(IServiceProvider serviceProvider , IWebHostEnvironment env)
        {
            _env = env;
            _serviceProvider = serviceProvider;
            this._getService = _serviceProvider.GetRequiredService<MenuOperationsService>();   
        }

        [HttpGet]
        [Route("getUpLevelsLookUp")]
        public IActionResult getUpLevelsLookUp()
        {
            return Ok(new ResponseModel { data = _getService.getUpLevelsLookUp(), success = true});
        }

        [HttpGet]
        [Route("getSubLevelsLookUp/{upLevelValue}")]
        public IActionResult getSubLevelsLookUp(string upLevelValue)
        {
            return Ok(new ResponseModel { data = _getService.getSubLevelsLookUp(upLevelValue), success = true });
        }

        [HttpGet]
        [Route("addMenuItem/{levelValue}/{upLevelValue}/{desc}/{menuOrder}/{auth}")]
        public IActionResult addMenuItem(string levelValue, string upLevelValue, string desc, string menuOrder, string auth)
        {
            try
            {               
                string res = _getService.addMenuItem(levelValue, upLevelValue, desc, menuOrder, auth);

                if (res == "")
                {
                    return Ok(new ResponseModel { data = "", success = true });
                }
                else
                {
                    return Ok(new ResponseModel { data = res, success = false });
                }

            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { data = ex.Data, success = false });
            }
        }
    }







}
