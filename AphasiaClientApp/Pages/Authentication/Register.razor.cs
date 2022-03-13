using AphasiaClientApp.Features.AuthService;
using AphasiaClientApp.Models.Auth;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Authentication
{
    public partial class Register
    {
        private UserRegistrationModel model = new UserRegistrationModel();
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowAuthError { get; set; }
        public string Error { get; set; }

        public async Task ExecuteRegister()
        {
            ShowAuthError = false;
            var result = await AuthenticationService.Register(model);
            if (!result.IsSuccessful)
            {
                Error = result.ErrorMessage;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
