using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using IdentityUserRole = Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole;

namespace AphasiaProject.Models.Users
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole()
        {
           
        }

        public AppRole(string roleName):this()
        {
            Name = roleName;
        }
    }
}
