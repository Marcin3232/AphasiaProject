using AphasiaClientApp.Components.Modals.Management;

namespace AphasiaClientApp.Pages.Management
{
    public partial class YourPatients
    {
        public RemovePatientModal removePatientModal = new RemovePatientModal();



        void ButtonNavigationToPatientsDetails()
        {

            UriHelper.NavigateTo("/yourPatients/patientDetails");
        }
    }
}
