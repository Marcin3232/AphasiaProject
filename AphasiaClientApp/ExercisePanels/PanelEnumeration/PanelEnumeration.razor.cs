using AphasiaClientApp.Models.Constant;
using AphasiaClientApp.Models.Enums;
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


namespace AphasiaClientApp.ExercisePanels.PanelEnumeration
{
    public partial class PanelEnumeration
    {
        [Parameter]
        public int Counter { get; set; }
        [Parameter]
        public EventCallback<bool> EnumerationCallback { get; set; }
        [Parameter]
        public EventCallback<bool> CancelCallback { get; set; }
        [Parameter]
        public CancellationTokenSource Cts { get; set; }
        [Parameter]
        public HistoryResultDetails HistoryDetails { get; set; }
        private bool show { get; set; } = false;
        private Dictionary<int, List<PanelEnumerationModel>> ModelDict { get; set; }
        private List<PanelEnumerationModel> ModelList { get; set; }
        private List<PanelEnumerationModel> ModelEnumerationList { get; set; }
        private ExercisePhase Phase { get; set; }
        private int lastCount { get; set; } = -1;
        private readonly int timeBreak = 2000;

        public async Task<int> Show(Exercise exercise)
        {
            await Task.Delay(10);
            Phase = exercise.Phases.FirstOrDefault(x => x.IsCurrent == true);
            ModelDict = PanelEnumerationNormalizer
                .Get(exercise.ExerciseInformation.ExerciseTaskId,
                exercise.ExerciseResource, Phase.Repeat);
            lastCount = -1;
            ModelList = GetModel();
            if (IsArrangeInTurn())
            {
                ModelEnumerationList = GetModel().OrderBy(x => x.Number).ToList();
                ModelEnumerationList.ForEach(x => x.IsShow = false);
            }

            show = true;
            StateHasChanged();
            return ModelDict.Count;
        }

        public Task Close()
        {
            show = false;
            StateHasChanged();
            return Task.CompletedTask;
        }

        public async Task ShowTip()
        {
            if (!IsArrangeInTurn())
                return;

            HistoryDetails.TipClicks++;

            if (!ModelList.Any(x => x.IsActive))
            {
                foreach (var x in ModelEnumerationList)
                {
                    var temp = ModelList.First(y => y.Number == x.Number);
                    if (temp.IsShow)
                    {
                        temp.IsCorrect = true;
                        temp.IsActive = true;
                        x.IsCorrect = true;
                        StateHasChanged();
                        await Task.Delay(timeBreak);
                        temp.IsActive = false;
                        temp.IsCorrect = null;
                        x.IsCorrect = null;
                        break;
                    }
                }
            }
            else
            {
                var model = ModelList.FirstOrDefault(x => x.IsActive);
                var modelEnum = ModelEnumerationList.FirstOrDefault(x => x.Number == model.Number);
                model.IsCorrect = true;
                modelEnum.IsCorrect = true;
                StateHasChanged();
                await Task.Delay(timeBreak);
                model.IsCorrect = null;
                modelEnum.IsCorrect = null;
            }
            StateHasChanged();
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
                    Cts = new CancellationTokenSource();
                    lastCount = Counter;
                    if (IsArrangeInTurn())
                    {
                        ModelList.ForEach(x => x.IsShow = true);
                        StateHasChanged();
                    }
                    else
                        await EnumerationList();
                }
                await base.OnAfterRenderAsync(firstRender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private bool IsClickableEnumeration(PanelEnumerationModel model)
        {
            if (model.IsCorrect == null && model.IsShow)
                return true;
            if (model.IsCorrect == false && !model.IsShow)
                return true;
            else
                return false;
        }

        private async Task OnPlaySound(PanelEnumerationModel model)
        {
            await Task.Delay(10);
            await Sound.Play(model.Text);
        }

        private List<PanelEnumerationModel> GetModel()
        {
            if (ModelDict.TryGetValue(Counter + 1, out var model))
                return IsArrangeInTurn() ? model.Shuffle() : model;
            return new List<PanelEnumerationModel>();
        }

        private bool IsArrangeInTurn() =>
            Phase.TypeId == (int)ExerciseType.ArrangeInTurn;

        private async Task EnumerationList()
        {
            if (!ModelList.Any())
                return;

            if (Phase.Type == (int)ExerciseType.EnumerationRepeat)
                ModelList.ForEach(x => x.IsShow = true);

            foreach (var item in ModelList)
            {
                if (Cts.Token.IsCancellationRequested)
                {
                    await CancelCallback.InvokeAsync(true);
                    return;
                }

                item.IsShow = true;

                if (Phase.Type == (int)ExerciseType.EnumerationRepeat)
                {
                    ModelList.ForEach((x) => x.IsActive = false);
                    item.IsActive = true;
                }

                StateHasChanged();
                await OnPlaySound(item);
                await Task.Delay(timeBreak);
            }

            await EnumerationCallback.InvokeAsync(true);
        }

        private void OnSelected(PanelEnumerationModel model)
        {
            var clickSame = ModelList.Any(x => x == model && model.IsActive);
            ModelList.ForEach(x => x.IsActive = false);
            model.IsActive = !clickSame;
            StateHasChanged();
        }

        private async Task OnChoice(PanelEnumerationModel model)
        {
            var selected = ModelList.FirstOrDefault(x => x.IsActive);
            if (selected == null)
                return;

            HistoryDetails.Answers++;

            if (selected.Number == model.Number)
            {
                model.IsShow = true;
                model.IsCorrect = true;
                selected.IsShow = false;
                selected.IsActive = false;
                HistoryDetails.CorrectAnswers++;
                await Sound.PlaySrc(BaseInstruction.CorrectSrc());
                StateHasChanged();
            }
            else
            {
                model.IsShow = true;
                model.IsCorrect = false;
                await Sound.PlaySrc(BaseInstruction.TryAgainSrc());
                HistoryDetails.WrongClicks++;
                StateHasChanged();
                await Task.Delay(timeBreak);
                model.IsCorrect = null;
            }

            if (!ModelList.Any(x => x.IsShow))
                await EnumerationCallback.InvokeAsync(true);

            StateHasChanged();
        }

        private ColorType SetColor(PanelEnumerationModel model)
        {
            if (model.IsActive)
                return SetColorWhenCorrect(model);
            else
                return ColorType.Normal;
        }

        private ColorType SetColorWhenCorrect(PanelEnumerationModel model) => model.IsCorrect switch
        {
            true => ColorType.Green,
            false => ColorType.Red,
            null => ColorType.Light
        };

        private string SetText(PanelEnumerationModel model) =>
            model.IsCorrect == true ? model.Text : "";

        private ColorType SetEmptyColor(PanelEnumerationModel model) => model.IsCorrect switch
        {
            true => ColorType.Green,
            false => ColorType.Red,
            null => ColorType.LightEmpty
        };
    }
}
