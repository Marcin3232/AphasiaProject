using System.Collections.Generic;
using System.Threading.Tasks;
using AphasiaClientApp.Components.Modals.Management;
using AphasiaClientApp.Models.Management;

namespace AphasiaClientApp.Pages.Management
{
    public partial class YourPatients
    {
        public RemovePatientModal removePatientModal = new RemovePatientModal();

        public List<PatientModel> patientModelList = new List<PatientModel>();

        protected override void OnInitialized()
        {
            PatientModel patientModel = new PatientModel();
            patientModel.Id = "1";
            patientModel.Name = "Tomasz C";
            patientModelList.Add(patientModel);
            PatientModel patientModel1 = new PatientModel();
            patientModel1.Id = "2";
            patientModel1.Name = "Marcin O";
            patientModelList.Add(patientModel1);
        }

        void ButtonNavigationToPatientsDetails()
        {
            UriHelper.NavigateTo("/yourPatients/patientDetails",true);
        }
    }
}
