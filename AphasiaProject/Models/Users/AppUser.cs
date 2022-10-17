using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AphasiaProject.Models.Users
{
    public class AppUser : IdentityUser<int>
    {
        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string Role { get; set; }
        public DateTime CreateDateTime { get; set; }
        public bool IsActive { get; set; }
        public int TherapistId { get; set; }

        public string Street { get; set; }
        public string HouseNbr { get; set; }    
        public string PostalCode { get; set; }
        public string City { get; set; }

       
    }
}
