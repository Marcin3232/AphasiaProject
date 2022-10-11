using AphasiaClientApp.Components.Modals.Management;
using AphasiaClientApp.Models.MainPanel;
using AphasiaClientApp.Pages.Other;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Management
{
    public partial class MainPanel
    {
        public string currentEmail;
        public string currentRole; 

        protected override void OnInitialized()
        {

        }
        void ButtonNavigateToYourPatientsPanels()
        {

            UriHelper.NavigateTo("/yourPatients");
        }
        void ButtonNavigateToYourDataChangePanel()
        {

            UriHelper.NavigateTo("/yourPersonalDataPanel",true);
        }
    }
}
