namespace AphasiaClientApp.Pages.Management
{
    public partial class MainPanel
    {

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
