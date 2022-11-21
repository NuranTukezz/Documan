using Documan.Server.Repositories;
using Documan.Shared.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Documan.Server.Services
{
    public class DocumentService
    {
        public DocMenuSysModel GetDoc(int docId)
        {
            DocumentRepository rep = new DocumentRepository();

            DocMenuSysModel res = rep.GetDoc(docId);
            return res;
        }

        //----------------------------------------------------------------------//

        public void getDownloadFile(string name, string file_path, string info)////dosya yükleme işlemi string name, string file_path, string info
        {
            DocumentRepository rep = new DocumentRepository();

            rep.getDownloadFile(name, file_path, info);
        }

        public List<DocMenuSysModel> setUploadFile(string name, string file_path, string info)//UploadFile dosya indirme işlemi
        {
            DocumentRepository rep = new DocumentRepository();

            List<DocMenuSysModel> res = rep.setUploadFile(name, file_path, info);
            return res;
        }

        //----------------------------------------------------------------------//

    }
}
