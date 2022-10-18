using AphasiaClientApp.Features.AuthService;
using AphasiaClientApp.Models.Management;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Management
{
    public partial class ManagementExercise
    {

        [Parameter]
        public string PatientId { get; set; } = "0";

        [Parameter]
        public string AphasiaType { get; set; } = "1";
        //lista pobirana z bazy;
        //[Inject]
        //IJSRuntime JsRuntime { get; set; }
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        public int index;
        List<PatientExerciseModel> patientExerciseModel = new List<PatientExerciseModel>();

        protected override async Task<Task> OnInitializedAsync()
        { 
            patientExerciseModel = await AuthenticationService.GetPatientsExercises(PatientId, AphasiaType);
            index = patientExerciseModel.Count;
            return base.OnInitializedAsync();  
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Delay(1);
            await base.OnAfterRenderAsync(firstRender);
        }


        public void RedirectMoto()
        {
            UriHelper.NavigateTo("/management/" + PatientId + "/management_exercise/"+1,true);
        }
        public void RedirectSenso()
        {
            UriHelper.NavigateTo("/management/" + PatientId + "/management_exercise/" + 2, true);
        }
        public void RedirectMix()
        {
            UriHelper.NavigateTo("/management/" + PatientId + "/management_exercise/" + 3, true);
        }
    }
}
