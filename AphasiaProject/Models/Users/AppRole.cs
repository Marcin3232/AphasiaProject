using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AphasiaProject.Models.Users
{
    public class AppRole : IdentityRole<int>
    {
        [Column(TypeName="varchar")]
        public string Description { get; set; }

        public AppRole()
        {
        }

        public AppRole(string roleName):this()
        {
            Name = roleName;
        }
    }
}
