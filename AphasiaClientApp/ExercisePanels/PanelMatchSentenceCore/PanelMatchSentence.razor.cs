using AphasiaClientApp.ExercisePanels.BasePanelFunc;
using AphasiaClientApp.Models.Enums;
using AphasiaClientApp.Pages.Exercises;
using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models;
using CommonExercise.Utils;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.ExercisePanels.PanelMatchSentenceCore
{
    public partial class PanelMatchSentence
    {
        [CascadingParameter]
        public MainPanel MainPanel { get; set; }
        [Parameter]
        public EventCallback<bool> NextCallback { get; set; }
        private List<PanelMatchSentenceModel> modelList { get; set; } = new List<PanelMatchSentenceModel>();
        private PanelMatchSentenceModel model => modelList?[MainPanel.Counter];
        private bool show { get; set; } = false;
        private bool isBlocker { get; set; } = false;

        private ExercisePhase exercisePhase;

        public async Task<int> Show(Exercise exercise)
        {
            await Task.Delay(10);
            int repeat = exercise.Phases.FirstOrDefault(x => x.IsCurrent == true).Repeat;
            exercisePhase = exercise.Phases.FirstOrDefault(x => x.IsCurrent == true);
            modelList = PanelMatchSentenceNormalizer.Get(exercise.ExerciseInformation.ExerciseTaskId,
                exercise.ExerciseResource, repeat);

            show = true;
            isBlocker = false;
            StateHasChanged();

            return modelList.Count;
        }

        public Task Close()
        {
            show = false;
            StateHasChanged();
            return Task.CompletedTask;
        }

        public async Task ShowTip()
        {
            if (isBlocker)
                return;

            MainPanel.HistoryResultDetails.TipClicks++;
            isBlocker = !isBlocker;

            if (model.Selected.Any(x => !x.IsShow))
            {
                model.Answer.ForEach(x => x.IsSelected = false);

                var answer = model.Answer.FirstOrDefault(x => x.IsShow);

                if (answer == null)
                {
                    isBlocker = !isBlocker;
                    return;
                }

                var selected = model.Selected.Where(x => x.Id == answer.Id).ToList().FirstOrDefault();

                selected.IsCorrect = true;
                answer.IsCorrect = true;
                StateHasChanged();
                await Task.Delay(3000);
                selected.IsCorrect = null;
                answer.IsCorrect = null;
                StateHasChanged();
            }

            isBlocker = !isBlocker;
        }

        private async Task OnMark(PanelMatchSentenceModel.Expression item)
        {
            await Task.Delay(10);

            if (isBlocker)
                return;

            if (item.IsCorrect is true || !item.IsShow)
                return;

            isBlocker = !isBlocker;

            model.Answer.ForEach(x =>
            {
                if (x.IsShow)
                    x.IsCorrect = null;

                x.IsSelected = false;
            });

            StateHasChanged();
            item.IsCorrect = true;
            item.IsSelected = true;
            StateHasChanged();
            isBlocker = !isBlocker;
        }

        private async Task OnSelect(PanelMatchSentenceModel.Expression item)
        {
            await Task.Delay(10);

            if (isBlocker)
                return;



            if (item.IsCorrect is true)
                return;

            var mark = model.Answer.FirstOrDefault(x => x.IsSelected);

            if (mark == null)
                return;

            isBlocker = !isBlocker;

            MainPanel.HistoryResultDetails.Answers++;

            if (mark.Id != item.Id)
            {
                MainPanel.HistoryResultDetails.WrongClicks++;
                item.IsCorrect = false;
                mark.IsCorrect = false;
                StateHasChanged();

                await Task.Delay(await Sound.PlaySrcAsync(SoundTaskHelper.GetSoundSrc(SoundSrc.Bu)), MainPanel.cts.Token);
                await Task.Delay(1000, MainPanel.cts.Token);

                item.IsCorrect = null;
                mark.IsCorrect = true;

            }
            else
            {
                MainPanel.HistoryResultDetails.CorrectAnswers++;
                item.IsCorrect = true;
                item.IsShow = true;
                mark.IsShow = false;
                mark.IsCorrect = null;
                mark.IsSelected = false;
                StateHasChanged();
                await Task.Delay(await Sound.PlaySrcAsync(SoundTaskHelper.GetSoundSrc(SoundSrc.Blik)), MainPanel.cts.Token);
                await Task.Delay(100, MainPanel.cts.Token);
            }

            if (!model.Selected.Any(x => !x.IsShow))
                await NextCallback.InvokeAsync(true);

            isBlocker = !isBlocker;
            StateHasChanged();
        }

        private async Task OnPlaySound(string src) =>
            await Sound.PlaySrcAsync(src);

        private string SetOnelineText() => "overflow:hidden; white-space:nowrap;text-overflow: ellipsis;" +
            " width:auto !important; padding-right: 0.6rem; padding-left: 0.6rem;";
    }
}
