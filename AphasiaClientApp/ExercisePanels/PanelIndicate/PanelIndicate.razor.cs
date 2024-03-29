﻿using AphasiaClientApp.ExercisePanels.BasePanelFunc;
using AphasiaClientApp.Models.Constant;
using AphasiaClientApp.Models.Enums;
using AphasiaClientApp.Pages.Exercises;
using CommonExercise.Enums;
using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models;
using CommonExercise.Utils;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AphasiaClientApp.ExercisePanels.PanelIndicate
{
    public partial class PanelIndicate : ComponentBase
    {
        [CascadingParameter]
        public MainPanel MainPanel { get; set; }
        [Parameter]
        public int Counter { get; set; } = 0;
        [Parameter]
        public bool PlaySound { get; set; }
        [Parameter]
        public HistoryResultDetails HistoryDetails { get; set; }
        [Parameter]
        public EventCallback<bool> IndicateCallback { get; set; }

        private List<PanelIndicateModel> ModelList { get; set; }
        private List<PanelIndicateModel> IndicateList { get; set; } = new List<PanelIndicateModel>();
        private ExercisePhase _exercisePhase { get; set; }
        private int lastCount { get; set; } = -1;
        private bool isFinish { get; set; } = false;
        private bool show { get; set; } = false;
        private string ExecutePointerEvent { get; set; }
        private int imageCount = 2;

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        public async Task<int> Show(Exercise exercise)
        {
            await Task.Delay(10);
            int repeat = exercise.Phases.FirstOrDefault(x => x.IsCurrent == true).Repeat;
            _exercisePhase = exercise.Phases.FirstOrDefault(x => x.IsCurrent == true);
            ModelList = PnaleIndicateNormalizer
                .Get(exercise.ExerciseInformation.ExerciseTaskId,
                exercise.ExerciseResource);
            MainPanel.cts = new CancellationTokenSource();
            show = true;
            lastCount = -1;
         //   StateHasChanged();
            return ModelList.Count > 2 ? ModelList.Count * repeat : repeat;
        }

        public async Task ShowTip()
        {
            var model = IndicateList.FirstOrDefault(x => x.IsIndicate);
            if (isFinish)
                return;
            await Task.Delay(200);
            model.ColorIndicate = ColorHelper.GetBackgroundColors(ColorType.Green);
            HistoryDetails.TipClicks++;
            StateHasChanged();
            await Task.Delay(3000);
            model.ColorIndicate = ColorHelper.GetBackgroundColors(ColorType.Normal);
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
                await Task.Delay(10);

                if (!show)
                    return;

                if (Counter != lastCount)
                {
                    Reset();
                    lastCount = Counter;
                    ExecutePointerEvent = "";

                    IndicateList = InitIndicateList();
                    RandomizeList();
                    PlaySound = false;

                    if (IsPlayDesc())
                        await OnPlayDescSound();

                    await Sound.PlayAsync(IndicateList.FirstOrDefault(x => x.IsIndicate)?.Word);
                }
                await base.OnAfterRenderAsync(firstRender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Reset()
        {
            isFinish = false;
            IndicateList.ForEach(x =>
            {
                x.ColorIndicate = ColorHelper.GetBackgroundColors(ColorType.Normal);
                ExecutePointerEvent = "";
            });
        }

        private List<PanelIndicateModel> InitIndicateList()
        {
            var list = new List<PanelIndicateModel>();
            if (!ModelList.Any() || ModelList is null)
                return new List<PanelIndicateModel>();

            if (ModelList.Count == 2)
                return ModelList;

            for (int i = 0; i < imageCount; i++)
            {
                var tempList = ModelList.Where(x => list.Any(y => y.Word != x.Word)).ToList();
                if (tempList.Any())
                    list.Add(tempList[new Random().Next(0, tempList.Count)]);
                else
                    list.Add(ModelList[new Random().Next(0, ModelList.Count)]);
            }

            return list;
        }

        private void RandomizeList()
        {
            IndicateList.ForEach(x => x.IsIndicate = false);
            IndicateList[new Random().Next(0, IndicateList.Count)].IsIndicate = true;
            StateHasChanged();
        }

        private async Task OnClickIndicate(PanelIndicateModel model)
        {
            await Task.Delay(10);
            HistoryDetails.Answers++;

            isFinish = model.IsIndicate;

            if (CorrectAgainAnswer.Result().TryGetValue(model.IsIndicate, out var result))
                await Sound.PlaySrcAsync(result);
            model.ColorIndicate = model.IsIndicate ? ColorHelper.GetBackgroundColors(ColorType.Green)
                : ColorHelper.GetBackgroundColors(ColorType.Red);
            ExecutePointerEvent = model.IsIndicate ? "pointer-events: none; " : "";

            if (model.IsIndicate)
            {
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
            }

            await IndicateCallback.InvokeAsync(model.IsIndicate);
        }

        private async Task OnPlaySound(PanelIndicateModel model)
        {
            await Task.Delay(10);
            await Sound.PlayAsync(model.Word);
        }

        private async Task OnPlayDescSound()
        {
            await Task.Delay(10);
            MainPanel.cts = new CancellationTokenSource();
            var delay = await Sound.PlayAsync(IndicateList.FirstOrDefault(x => x.IsIndicate)?.Desctiption);
            await Task.Delay(delay, MainPanel.cts.Token);
        }

        private bool IsPlayDesc() => !string.IsNullOrEmpty(ModelList.FirstOrDefault()?.Desctiption)
            && IsAccessDesc(_exercisePhase);

        private bool IsAccessDesc(ExercisePhase exercise) => exercise.Kind switch
        {
            (int)ExerciseKind.Indicate => true,
            _ => false
        };
    }
}
