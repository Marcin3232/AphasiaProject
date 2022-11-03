using AphasiaClientApp.Components.Modals.Management;
using AphasiaClientApp.Extensions;
using AphasiaClientApp.Models.Enums;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace AphasiaClientApp.Components.Buttons
{
    public partial class ImageButtonModel
    {

        public RemovePatientModal removePatientModal = new RemovePatientModal();

        [Parameter]
        public ImageButtonTypes ImageButtonType { get; set; } = ImageButtonTypes.ButtonFrame;
        [Parameter]
        public NaviTypeImage TypeImage { get; set; }
        [Parameter]
        public EventCallback ButtonCallback { get; set; }
        [Parameter]
        public ButtonEventType EventType { get; set; } = ButtonEventType.Button;
        [Parameter]
        public bool IsDisabled { get; set; } = true;
        [Parameter]
        public string SetStyle { get; set; } = "";
        [Parameter]
        public string SetType { get; set; } = "ic-light";

        [Parameter]
        public string SetClickType { get; set; }
        [Parameter]
        public string Id { get; set; }
        [Parameter]
        public int ExerciseId { get; set; }

        [Parameter]
        public string SetPatientID { get; set; }

        [Parameter]
        public string Tip { get; set; }

        [Parameter]
        public string Active { get; set; }

        private string Type => EventType.GetAttribute<DisplayAttribute>().Name;
        private string ImageSrc => Path.FullPathImage(TypeImage);

        public void RedirectToExPhase()
        {
            UriHelper.NavigateTo("/management/management_exercise/excerciseDetails/"+ExerciseId, true);
        }
        public void RedirectToPatientExcercisePage()
        {
            UriHelper.NavigateTo("/management/"+SetPatientID+"/management_exercise/1",true);
        }
        public void RedirectToPatientDetailsPage()
        {
            UriHelper.NavigateTo("/yourPatients/patientDetails/"+SetPatientID,true);
        }
    }
}
