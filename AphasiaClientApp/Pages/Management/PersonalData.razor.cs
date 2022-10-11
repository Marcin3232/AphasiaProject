using AphasiaClientApp.Models.MainPanel;
using AphasiaClientApp.Pages.Other;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Management
{
    public partial class PersonalData
    {

        [Inject]
        IJSRuntime JsRuntime { get; set; }

        public PersonalDataModel personalDataModel = new PersonalDataModel();
        private ReportError reportErrorModal = new ReportError();
      
        protected override Task OnInitializedAsync()
        {
            Task.Delay(1);
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
