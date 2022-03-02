using CommonExercise.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Footers
{
    public partial class ExerciseFooter
    {
        [Parameter]
        public Exercise  Exercise { get; set; }
        [Parameter]
        public EventCallback<bool> EventCallback { get; set; }

        private Task OnClick(ExercisePhase phase)
        {
            Exercise.Phases.ForEach(x => x.IsCurrent = x == phase ? true : false);
            FillDone();
            StateHasChanged();
            return EventCallback.InvokeAsync(true);
        }

        private void FillDone()
        {
            var currentPosition = Exercise.Phases.FirstOrDefault(x => x.IsCurrent).Order;
            Exercise.Phases.ForEach(x =>
            {
                if (x.Order <= currentPosition)
                    x.IsDone = true;
                else
                    x.IsDone = false;
            });
        }
    }
}
