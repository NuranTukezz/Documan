using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documan.Shared.Models
{
    public class DocMenuSysModel
    {
        public int id { get; set; }
        public int up_level { get; set; }
        public string name { get; set; }
        public string file_path { get; set; }
        public string info { get; set; }
        public bool write { get; set; }

        // <!-- File Uploader HTML-->
        public string? FileName { get; set; } // dosya adını 
        public string? StoredFileName { get; set; } //saklanan dosya adı //bu iptal edildi ilerleyen zamanlarda silinebilir
        public List<string> ContentType { get; set; } //bu iptal edildi ilerleyen zamanlarda silinebilir

        // Bunlar sonradan silinecek geçici olarak eklendi
        public int? menu_order { get; set; } //Alt menuler arasında sıralama 
        public int? auth_level { get; set; } //Hangi seviye kullanıcılar görebilir 

    }
}
