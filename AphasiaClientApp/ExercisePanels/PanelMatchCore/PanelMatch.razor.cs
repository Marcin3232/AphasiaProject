using AphasiaClientApp.ExercisePanels.BasePanelFunc;
using AphasiaClientApp.Models.Constant;
using AphasiaClientApp.Models.Enums;
using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models;
using CommonExercise.Utils;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AphasiaClientApp.ExercisePanels.PanelMatchCore
{
    public partial class PanelMatch
    {
        [Parameter]
        public int Counter { get; set; } = 0;
        [Parameter]
        public bool PlaySound { get; set; }
        [Parameter]
        public HistoryResultDetails HistoryDetails { get; set; }
        [Parameter]
        public EventCallback<bool> MatchCallback { get; set; }
        private List<PanelMatchModel> modelList { get; set; }
        private List<PanelMatchModel> panelMatchList { get; set; } = new List<PanelMatchModel>();
        private bool show { get; set; } = false;
        private bool isFinish { get; set; } = false;
        private int lastCount { get; set; } = -1;
        private string executePointerEvent { get; set; }
        private ExercisePhase exercisePhase;
        private int textCount => GetMatchItem();
        private bool blocker = false;

        public async Task<int> Show(Exercise exercise)
        {
            await Task.Delay(10);
            int repeat = exercise.Phases.FirstOrDefault(x => x.IsCurrent == true).Repeat;
            exercisePhase = exercise.Phases.FirstOrDefault(x => x.IsCurrent == true);
            modelList = PanelMatchNormalizer.Get(exercise.ExerciseInformation.ExerciseTaskId,
                exercise.ExerciseResource, repeat);
            show = true;
            lastCount = -1;
            StateHasChanged();
            return modelList.Count > 2 ? modelList.Count * repeat : repeat;
        }

        protected override Task OnInitializedAsync() => base.OnInitializedAsync();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                await Task.Delay(10);
                if (!show)
                    return;
                if (Counter != lastCount)
                {
                    Reset();
                    lastCount = Counter;

                    panelMatchList = InitMatchList();
                    RandomizeList();
                    await OnPlayTaskSound();
                    PlaySound = false;
                }
                await base.OnAfterRenderAsync(firstRender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task ShwoTip()
        {
            if (isFinish)
                return;

            var model = panelMatchList.FirstOrDefault(x => x.IsMatch);

            await Task.Delay(200);
            model.ColorIndicate = ColorHelper.GetBackgroundColors(ColorType.Green);
            model.IsCorrect = true;
            HistoryDetails.TipClicks++;
            StateHasChanged();
            await Task.Delay(3000);
            model.ColorIndicate = ColorHelper.GetBackgroundColors(ColorType.Normal);
            model.IsCorrect = null;
        }

        public Task Close()
        {
            show = false;
            StateHasChanged();
            return Task.CompletedTask;
        }

        private void Reset()
        {
            isFinish = false;
            executePointerEvent = string.Empty;
            panelMatchList.ForEach(x =>
            {
                x.IsCorrect = null;
                x.ColorIndicate = ColorHelper.GetBackgroundColors(ColorType.Normal);
            });
        }

        private int GetMatchItem()
        {
            if (!modelList.Any())
                return 0;
            var counter = modelList.Distinct().Count();
            return counter <= 4 ? counter : 3;
        }

        private List<PanelMatchModel> InitMatchList()
        {
            var list = new List<PanelMatchModel>();
            if (!modelList.Any() || modelList is null)
                return list;

            if (modelList.Count == 2)
                return modelList;

            for (int i = 0; i < textCount; i++)
            {
                var tempList = modelList.Except(list).ToList();
                if (tempList.Any())
                    list.Add(tempList[new Random().Next(0, tempList.Count)]);
                else
                    list.Add(modelList[new Random().Next(0, modelList.Count)]);
            }

            return list;
        }

        private void RandomizeList()
        {
            panelMatchList.ForEach(x => x.IsMatch = false);
            panelMatchList[new Random().Next(0, panelMatchList.Count)].IsMatch = true;
            StateHasChanged();
        }

        private async Task OnPlayTaskSound()
        {
            blocker = true;
            if (PanelTaskMode.WorkTask == PanelModeService.GetTask(exercisePhase))
            {
                await Task.Delay(10);
                var model = modelList.FirstOrDefault(x => x.IsMatch);
                await Task.Delay(await Sound.PlaySrcAsync(model?.DescriptionSound));
            }
            blocker = false;
        }

        private async Task OnPlaySound(PanelMatchModel model, bool playTask = false)
        {
            if (blocker)
                return;

            await Task.Delay(10);
            if (playTask)
                await Sound.PlaySrcAsync(model.DescriptionSound);
            else if (PanelExtension.IsPlayName(exercisePhase))
                await Sound.PlaySrcAsync(model.WordSound);
            else
                await Sound.PlaySrcAsync(model.DescriptionSound);
        }

        private async Task OnClickMatch(PanelMatchModel model)
        {
            await Task.Delay(10);

            if (isFinish || blocker)
                return;

            HistoryDetails.Answers++;

            isFinish = model.IsMatch;

            if (CorrectAgainAnswer.Result().TryGetValue(model.IsMatch, out var result))
                await Sound.PlaySrcAsync(result);

            model.ColorIndicate = model.IsMatch ? ColorHelper.GetBackgroundColors(ColorType.Green)
                : ColorHelper.GetBackgroundColors(ColorType.Red);
            model.IsCorrect = model.IsMatch;
            executePointerEvent = model.IsMatch ? "pointer-events:none;" : "";

            if (model.IsMatch)
            {
                isFinish = true;
                StateHasChanged();
                await Task.Delay(1000);
                HistoryDetails.CorrectAnswers++;
            }
            else
            {
                HistoryDetails.WrongClicks++;
                StateHasChanged();
                await Task.Delay(3000);
                model.ColorIndicate = ColorHelper.GetBackgroundColors(ColorType.Normal);
                model.IsCorrect = null;
            }

            await MatchCallback.InvokeAsync(model.IsCorrect is true ? true : false);
        }
    }
}
