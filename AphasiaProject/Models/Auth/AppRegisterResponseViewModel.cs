using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AphasiaProject.Models.Users;

namespace AphasiaProject.Models.Auth
{
    public class AppRegisterResponseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public AppRegisterResponseViewModel(AppUser user)
        {
            Id = user.Id;
            Name = user.UserName;
            Email = user.Email;
        }
    }
}
