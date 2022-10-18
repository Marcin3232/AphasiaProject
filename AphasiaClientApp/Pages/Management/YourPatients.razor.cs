using System.Collections.Generic;
using System.Threading.Tasks;
using AphasiaClientApp.Components.Modals.Management;
using AphasiaClientApp.Features.AuthService;
using AphasiaClientApp.Models.Management;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace AphasiaClientApp.Pages.Management
{
    public partial class YourPatients
    {
        public RemovePatientModal removePatientModal = new RemovePatientModal();

        public List<PatientModel> patientModelList = new List<PatientModel>();
       
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        protected override async Task<Task> OnInitializedAsync()
        {

            patientModelList = await AuthenticationService.GetPatients();
            StateHasChanged();
            return base.OnInitializedAsync();
        }

        void ButtonNavigationToPatientsDetails()
        {
            UriHelper.NavigateTo("/yourPatients/patientDetails",true);
        }
    }
}
