using Documan.Server.Helpers;
using Documan.Shared.Models;
using Dapper;
using System.Data.SqlClient;
using System.Reflection;

namespace Documan.Server.Repositories
{
    public class DocumentRepository
    {
        SqlConnection rep;

        public DocumentRepository()
        {
            rep = new SqlConnection(Common.getConnStr());
        }

        public DocMenuSysModel GetDoc(int docId)
        {
            string Sql = $@"   
                            SELECT * FROM tbl_docs With(nolock)
                            WHERE id = {docId}
                                ";
            DocMenuSysModel res = rep.Query<DocMenuSysModel>(Sql).FirstOrDefault();

            return res;
        }

        //----------------------------------------------------------------------//

        public void getDownloadFile(string name, string file_path, string info)//DownloadFile //dosya yükleme işlemi
        {
            string Sql = $@"  insert into tbl_docs( name , file_path , info ) values('{name}', '{file_path}','{info}')
                                
            ";

            rep.Query<string>(Sql).FirstOrDefault();

            //string newSql = $@"  

            //";

            //rep.Query<string>(newSql).FirstOrDefault();
        }

        public List<DocMenuSysModel> setUploadFile(string name, string file_path, string info)//UploadFile
        {
            string newSql = $@" insert into tbl_docs( name , file_path , info ) values('{name}', '{file_path}','{info}')
                              
            ";
            List<DocMenuSysModel> newRes = rep.Query<DocMenuSysModel>(newSql).ToList();

            return newRes;
        }

        //----------------------------------------------------------------------//

    }
}
