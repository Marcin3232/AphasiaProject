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

            UriHelper.NavigateTo("/yourPersonalDataPanel");
        }
    }
}
