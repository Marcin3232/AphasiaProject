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
        [Parameter]
        public EventCallback<bool> NextCallback { get; set; }
        private List<PanelOption1Model> ModelList { get; set; }
        private ExerciseType Type { get; set; }
        private PanelOption1Model Model => ModelList[Counter];
        private ExercisePhase _exercisePhase { get; set; }
        private bool show { get; set; } = false;
        private string textShow { get; set; } = string.Empty;
        private bool blocker = false;
        private bool isShowFrameText { get; set; }
        private int lastCount { get; set; } = -1;

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
            isShowFrameText = ShowFrameText();
            lastCount = -1;
            StateHasChanged();
            return ModelList.Count;
        }

        public Task Close()
        {
            show = false;
            PlaySound = false;
            StateHasChanged();
            return Task.CompletedTask;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (!show)
                    return;

                if (!firstRender && PlaySound && lastCount != Counter)
                {
                    PlaySound = false;
                    lastCount = Counter;

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
            if (blocker)
                return;

            blocker = true;
            await Task.Delay(10);
            var delay = await JsRuntime.InvokeAsync<int>("PlaySound", "descSound");
            await Task.Delay(delay);
            blocker = false;
        }

        private async Task OnPlaySound()
        {
            if (blocker)
                return;

            blocker = true;
            await Task.Delay(10);
            switch ((ExerciseType)_exercisePhase.Type)
            {
                case ExerciseType.SingleImageThreeSoundTextRepeat:
                    textShow = Model?.Word;
                    StateHasChanged();
                    await Task.Delay(await Sound.PlaySrc(Model?.WordSound));
                    await Task.Delay(await Sound.PlaySrc(Model?.QuestionSoundSrc));
                    textShow = Model?.Sentence;
                    StateHasChanged();
                    await Task.Delay(await Sound.PlaySrc(Model?.VerbSoundSrc));
                    await Task.Delay(1000);
                    await NextCallback.InvokeAsync(true);
                    break;
                case ExerciseType.SingleImageTwoSoundWithBreakTextRepeat:
                    textShow = Model?.Word;
                    StateHasChanged();
                    await Task.Delay(await Sound.PlaySrc(Model?.SentenceSoundSrc));
                    await Task.Delay(2000);
                    textShow = Model?.Sentence;
                    await Task.Delay(await Sound.PlaySrc(Model?.VerbSoundSrc));
                    StateHasChanged();
                    await Task.Delay(1000);
                    await NextCallback.InvokeAsync(true);
                    break;
                case ExerciseType.NamingWithSound:
                    isShowFrameText = false;
                    StateHasChanged();
                    await Task.Delay(3000);
                    textShow = Model?.Sentence;
                    isShowFrameText = true;
                    StateHasChanged();
                    await Task.Delay(await Sound.PlaySrc(Model?.VerbSoundSrc));
                    await Task.Delay(1000);
                    await NextCallback.InvokeAsync(true);
                    break;
                default:
                    textShow = Model?.Word;
                    StateHasChanged();
                    await Task.Delay(await Sound.PlaySrc(Model?.WordSound));
                    await Task.Delay(1000);
                    await NextCallback.InvokeAsync(true);
                    break;
            }
            blocker = false;
        }

        private async Task OnPlaySoundClick()
        {
            if (blocker)
                return;
            blocker = true;
            await Task.Delay(10);
            await Task.Delay(await Sound.Play(textShow));
            blocker = false;
        }

        private bool IsPlayDesc() => !string.IsNullOrEmpty(Model?.Description) && IsAccessDesc(_exercisePhase);

        private bool ShowFrameText()
        {
            switch (Type)
            {
                case ExerciseType.Naming:
                    return false;
                case ExerciseType.NamingWithSound:
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
