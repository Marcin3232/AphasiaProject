using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models;
using CommonExercise.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AphasiaClientApp.ExercisePanels.PanelFilm
{
    public partial class PanelFilm
    {
        [Parameter]
        public int Counter { get; set; }
        [Parameter]
        public bool PlaySound { get; set; }
        private bool show { get; set; } = false;
        private PanelFilmModel ModelList { get; set; }
        private ExercisePhase Phase { get; set; }
        private string VideoSrc => $"https://www.youtube.com/embed/{GetVideo()}?playlist={GetVideo()}&loop=1&autoplay=1&controls=0&rel=0";

        protected override Task OnInitializedAsync() => base.OnInitializedAsync();

        public async Task<int> Show(Exercise exercise)
        {
            Phase = exercise.Phases.FirstOrDefault(x => x.IsCurrent == true);
            int repeat = Phase.Repeat;
            ModelList = PanelFilmNormalizer
                .Get(exercise.ExerciseInformation.ExerciseTaskId,
                exercise.ExerciseResource, repeat);
            show = true;
            var srcList = ModelList.VideosSrc[Phase.PhaseNameId];
            StateHasChanged();
            return srcList.Count;
        }

        public Task Close()
        {
            show = false;
            StateHasChanged();
            return Task.CompletedTask;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (!show)
                    return;
                await base.OnAfterRenderAsync(firstRender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private string GetVideo() =>
            ModelList.VideosSrc.TryGetValue(Phase.PhaseNameId, out var video) ? video[Counter] : "";
    }
}
