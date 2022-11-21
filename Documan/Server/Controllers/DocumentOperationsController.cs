using Documan.Server.Services;
using Documan.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;

namespace Documan.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentOperationsController : ControllerBase
    {
        //içerik dosyalarını içeren dizinin mutlak yolunu alır veya ayarlar.
        private readonly IWebHostEnvironment _env; //file 

        private readonly IServiceProvider _serviceProvider;
        private DocumentService _getService { get; set; } //db

        public DocumentOperationsController(IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            _env = env;
            _serviceProvider = serviceProvider;
            this._getService = _serviceProvider.GetRequiredService<DocumentService>();
        }

        //----------------------------------------------------------------------//


        [HttpGet]
        [Route("getDownloadFile/{name}/{file_path}/{info}")]
        public IActionResult getDownloadFile(string name, string file_path, string info) //, string file_path, string info
        {

            _getService.getDownloadFile(name, file_path, info);//, file_path, info

            var path = Path.Combine(_env.ContentRootPath, "uploads"); //veri tabanına kayıt atıyor

            var memory = new MemoryStream();
            using (FileStream stream = new FileStream(path, FileMode.Open))//burada hata alıyorum indirilmek dosyanın adını arıyor bulamadığı için hata veriyor
            {
                stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return Ok(new ResponseModel { data = "Başarılı", success = true });

        }


        //[HttpGet]
        //[Route("getDownloadFile/{name}/{file_path}/{info}")]
        //public IActionResult getDownloadFile(string name, string file_path, string info)
        //{

        //    try
        //    {
        //        string res = _getService.getDownloadFile(name, file_path, info).ToString();

        //        if (res == "")
        //        {
        //            return Ok(new ResponseModel { data = "", success = true });
        //        }
        //        else
        //        {
        //            return Ok(new ResponseModel { data = res, success = false });
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new ResponseModel { data = ex.Data, success = false });
        //    }
        //}

        [HttpPost]
        [Route("setUploadFile/{name}/{file_path}/{info}")]
        //dökümanı dosyaya indirme işlemi
        public async Task<ActionResult<List<DocMenuSysModel>>> setUploadFile(List<IFormFile> files)
        {
            List<DocMenuSysModel> menuResults = new List<DocMenuSysModel>();

            foreach (var file in files) //files=> kaç dosya seçili
            {
                var docMenuResult = new DocMenuSysModel();

                string trustedFileNameForFileStorage;

                var untrustedFileName = file.FileName; //file.FileName; => IFormFile içinden geliyor SEÇİLEN DOSYANIN ADI GELİYOR

                docMenuResult.FileName = untrustedFileName; //BUNU FİLE_PATH YAP
               // var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

                untrustedFileName = Path.GetRandomFileName();

                var path = Path.Combine(_env.ContentRootPath, "uploads");

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);

                //docMenuResult.name = trustedFileNameForFileStorage;
                docMenuResult.file_path = file.ContentType;//içerik türü bu IFormFile içinden gelir sadece get yapılır

                menuResults.Add(docMenuResult);


                _getService.setUploadFile(docMenuResult. name, docMenuResult. file_path, docMenuResult. info);
            }

             return Ok(menuResults);
           // return Ok(new ResponseModel { data = "Başarılı", success = true });

        }

        //public async Task<ActionResult<List<SideMenuListModel>>> getDownloadFile(string name, string file_path, string info, string lang)
        //string res = _getService.getDownloadFile(name, file_path, info, lang, load_user).ToString();

        //var path = Path.Combine(_env.ContentRootPath, "uploads", name, file_path, info, lang, load_user);

        //var memory = new MemoryStream();
        //using (var stream = new FileStream(path, FileMode.Open))
        //{
        //    await stream.CopyToAsync(memory);
        //}
        //memory.Position = 0;
        //return File(memory, res.ContentType, Path.GetFileName(path));

        //----------------------------------------------------------------------//



    }
}
