using AphasiaClientApp.Models.Management;

namespace AphasiaClientApp.Pages.Management.Patients
{
    public partial class PatientDetails
    {
        PatientDetailsModel patientDetailsModel = new PatientDetailsModel();


        public void ExecutePersonalDataChange()
        {

        }

        public void ButtonNavigationToChangePassword()
        {
            UriHelper.NavigateTo("/ChangePassword");
        }
    }
}
