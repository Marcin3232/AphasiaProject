using Microsoft.AspNetCore.Components;

namespace AphasiaClientApp.Components.Progressbars
{
    public partial class ExerciseProgressbar
    {
        [Parameter]
        public int CurrentTask { get; set; }
        [Parameter]
        public int MaxTask { get; set; }
    }
}
