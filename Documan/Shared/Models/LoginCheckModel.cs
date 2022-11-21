using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documan.Shared.Models
{
    public class LoginCheckModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public int auth_Level { get; set; }
        public DateTime cr_date { get; set; }
        public bool isValid { get; set; } = false;
    }
}
