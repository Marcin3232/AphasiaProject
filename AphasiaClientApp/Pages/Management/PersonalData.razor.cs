using AphasiaClientApp.Features.AuthService;
using AphasiaClientApp.Models.Auth;
using AphasiaClientApp.Models.MainPanel;
using AphasiaClientApp.Pages.Other;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Management
{
    public partial class PersonalData
    {

        [Inject]
        IJSRuntime JsRuntime { get; set; }
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        private ILocalStorageService _localStorage { get; set; }

        public PersonalDataModel personalDataModel = new PersonalDataModel();
        private ReportError reportErrorModal = new ReportError();
        public EditPersonalDataDto PersonalDataDto = new EditPersonalDataDto();
        protected override async Task<Task> OnInitializedAsync()
        {
         
            var a = await _localStorage.GetItemAsync<string>("therapistId");

            PersonalDataDto  =await AuthenticationService.GetPersonalData(a);

           
            


            StateHasChanged();
            return base.OnInitializedAsync();

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Delay(1);

            await base.OnAfterRenderAsync(firstRender);

        }

        void ButtonNavigationToChangePassword()
        {

            UriHelper.NavigateTo("/ChangePassword",true);
        }
        void ButtonNavigationToResetPassword()
        {

            UriHelper.NavigateTo("/ResetPassword");
        }
        void ButtonNavigationToRemoveUser()
        {

            UriHelper.NavigateTo("/RemoveUser");
        }
    }
}
