using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaProject.Models.Auth
{
    public class AppSettings
    {
        public string JWT_Secret { get; set; } = "21321312312";
        public string Client_URL { get; set; }
    }
}
