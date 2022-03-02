using CommonExercise.ExerciseResourceProjection;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.ExercisePanels
{
    public partial class PanelOption1
    {
        [Parameter]
        public int Counter { get; set; } = 1;
        [Parameter]
        public bool PlaySound { get; set; }
        private List<PanelOption1Model> ModelList { get; set; }
        private bool show { get; set; } = false;

        protected override Task OnInitializedAsync() => base.OnInitializedAsync();

        public async Task Show(List<PanelOption1Model> list)
        {
            await Task.Delay(1);
            ModelList = list;         
            show = true;
            PlaySound = true;
            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (!firstRender && PlaySound)
                {
                    PlaySound = false;
                    await OnPlaySound();
                    StateHasChanged();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task OnPlaySound()
        {
            await Task.Delay(10);
            await JsRuntime.InvokeAsync<int>("PlaySound", "sound");
        }
    }
}
