using AphasiaClientApp.Models.MainPanel;
using AphasiaClientApp.Pages.Other;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Management
{
    public partial class PersonalData
    {
        public PersonalDataModel personalDataModel = new PersonalDataModel();
        public RemoveAccount removeAccount = new RemoveAccount();
        private ReportError reportErrorModal = new ReportError();
        public async Task ExecutePersonalDataChange()
        {

        }


        void ButtonNavigationToChangePassword()
        {

            UriHelper.NavigateTo("/ChangePassword");
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
