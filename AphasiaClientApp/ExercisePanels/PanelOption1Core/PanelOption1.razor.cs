using CommonExercise.Enums;
using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models;
using CommonExercise.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.ExercisePanels.PanelOption1Core
{
    public partial class PanelOption1 : ComponentBase
    {
        [Parameter]
        public int Counter { get; set; } = 1;
        [Parameter]
        public bool PlaySound { get; set; }
        private List<PanelOption1Model> ModelList { get; set; }
        private ExerciseType Type { get; set; }
        private PanelOption1Model Model => ModelList[Counter];
        private ExercisePhase _exercisePhase { get; set; }
        private bool show { get; set; } = false;

        protected override Task OnInitializedAsync() => base.OnInitializedAsync();

        public async Task<int> Show(Exercise exercise)
        {
            await Task.Delay(10);
            _exercisePhase = exercise.Phases.FirstOrDefault(x => x.IsCurrent == true);
            ModelList = PanelOption1Normalizer
                        .Get(exercise.ExerciseInformation.ExerciseTaskId,
                        exercise.ExerciseResource, exercise.Phases.FirstOrDefault(x => x.IsCurrent == true).Repeat);
            Type = (ExerciseType)exercise.Phases.FirstOrDefault(x => x.IsCurrent == true).Type;
            show = true;
            PlaySound = true;
            StateHasChanged();
            return ModelList.Count;
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
                if (!firstRender && PlaySound)
                {
                    PlaySound = false;

                    if (IsPlayDesc())
                        await OnPlayDescSound();

                    await OnPlaySound();
                    StateHasChanged();
                }
                await base.OnAfterRenderAsync(firstRender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task OnPlayDescSound()
        {
            await Task.Delay(10);
            var delay = await JsRuntime.InvokeAsync<int>("PlaySound", "descSound");
            await Task.Delay(delay);
        }

        private async Task OnPlaySound()
        {
            await Task.Delay(10);
            await JsRuntime.InvokeAsync<int>("PlaySound", "sound");
        }

        private bool IsPlayDesc() => !string.IsNullOrEmpty(Model?.Desctiption) && IsAccessDesc(_exercisePhase);

        private bool ShowFrameText()
        {
            switch (Type)
            {
                case ExerciseType.Naming:
                    return false;
                default: return true;
            }
        }

        private bool IsAccessDesc(ExercisePhase exercise) => exercise.Kind switch
        {
            (int)ExerciseKind.ListenAndRemember => true,
            _ => false
        };
    }
}
