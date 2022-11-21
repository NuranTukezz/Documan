using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documan.Shared.Models
{
    public class SideMenuListModel
    {
        public int id { get; set; }
        //public string code { get; set; }
        public string name { get; set; } //EX100003 href'e vereceğimiz
        public string lang { get; set; }
        public int menu_level { get; set; } // Ana veya alt menu ayrımı    0,1,2
        public int? up_level { get; set; } // hangi Ana menuye ait. id ile sağlanıyor
        //public int? tree_level { get; set; } //  ve hangi 2. katmana bağlı.  
        public int? menu_order { get; set; } //Alt menuler arasında sıralama 
        public int? auth_level { get; set; } //Hangi seviye kullanıcılar görebilir 
        public DateTime cr_date { get; set; }

       
    
        

    }
}
