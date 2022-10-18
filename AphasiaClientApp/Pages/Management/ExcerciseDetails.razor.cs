using AphasiaClientApp.Features.AuthService;
using CommonExercise.Models.User.Management;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Management
{
    public partial class ExcerciseDetails
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        List<UserExercisePhaseModel> userExercisePhaseModels = new List<UserExercisePhaseModel>();


        [Parameter]
        public string Id { get; set; }
        public int index { get; set; }  
        protected override async Task<Task> OnInitializedAsync()
        {
            userExercisePhaseModels = await AuthenticationService.GetPatientPhases(Int16.Parse(Id));
                ;
            index = userExercisePhaseModels.Count;
            return base.OnInitializedAsync();
        }

        void RedirectToResults()
        {
            UriHelper.NavigateTo("/results");
        }

        void RedirectToExcercisePreview()
        {
            UriHelper.NavigateTo("/excercisePreview");
        }
    }
}
