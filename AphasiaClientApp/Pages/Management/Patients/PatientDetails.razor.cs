using AphasiaClientApp.Models.Management;
using Microsoft.AspNetCore.Components;

namespace AphasiaClientApp.Pages.Management.Patients
{
    public partial class PatientDetails
    {
        PatientDetailsModel patientDetailsModel = new PatientDetailsModel();

        [Parameter]
        public string PatientId { get; set; } = "0";

        public void ExecutePersonalDataChange()
        {

        }

        public void ButtonNavigationToChangePassword()
        {
            UriHelper.NavigateTo("/ChangePassword");
        }
    }
}
