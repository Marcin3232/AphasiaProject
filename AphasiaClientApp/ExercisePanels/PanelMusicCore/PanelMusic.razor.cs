using AphasiaClientApp.ExercisePanels.BasePanelFunc;
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

namespace AphasiaClientApp.ExercisePanels.PanelMusicCore
{
    public partial class PanelMusic : ComponentBase
    {
        [Parameter]
        public int Counter { get; set; } = 0;
        [Parameter]
        public HistoryResultDetails HistoryDetails { get; set; }
        [Parameter]
        public CancellationTokenSource Cts { get; set; }
        [Parameter]
        public EventCallback<bool> NextCallback { get; set; }
        [Parameter]
        public EventCallback<bool> CancelCallback { get; set; }
        private ExercisePhase exercisePhase { get; set; }
        private List<PanelMusicModel> modelList { get; set; }
        private PanelMusicModel model { get; set; }
        private bool show { get; set; } = false;
        private int lastCount { get; set; } = -1;
        private bool blocker { get; set; } = false;

        private readonly double factorRepeat = 0.6;

        public async Task<int> Show(Exercise exercise)
        {
            await Task.Delay(10);
            exercisePhase = exercise.Phases.FirstOrDefault(x => x.IsCurrent);
            int repeat = exercisePhase.Repeat;
            modelList = PanelMusicNormalizer
                .Get(exercise.ExerciseInformation.ExerciseTaskId, exercise.ExerciseResource, repeat);

            lastCount = -1;
            model = modelList.FirstOrDefault();

            show = true;
            StateHasChanged();
            return repeat;
        }

        public Task Close()
        {
            show = false;
            StateHasChanged();
            return Task.CompletedTask;
        }

        public async Task ShowTip()
        {
            if (!PanelMusicOption.IsRepeatMode(exercisePhase))
                return;

            HistoryDetails.TipClicks++;

            ClearAnswer();
            await OnPlayExerciseMode();
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
                    Reset();

                    if (PanelMusicOption.IsRepeatMode(exercisePhase))
                        SetRepeatElements();

                    lastCount = Counter;
                    await OnPlayExerciseMode();

                    if (PanelMusicOption.IsRepeatMode(exercisePhase))
                        SetRepeatModeKey();

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
            modelList.ForEach(model =>
            {
                model.SoundSrcList.ForEach(x =>
                {
                    x.IsCorrect = false;
                    x.ColorBg = " m-bcw ";
                    x.Order = 0;
                });
            });
        }

        private void SetRepeatElements()
        {
            int repeatCount = (int)Math.Round(model.SoundSrcList.Count * factorRepeat);

            for (int i = 1; i <= repeatCount; i++)
            {
                var tempList = model.SoundSrcList.Where(x => x.Order == 0).ToList();
                var getItem = tempList[new Random().Next(0, tempList.Count)];
                model.SoundSrcList.FirstOrDefault(x => x.Equals(getItem)).Order = i;
            }
            StateHasChanged();
        }

        private async Task OnPlayExerciseMode()
        {
            switch ((ExerciseType)exercisePhase.Type)
            {
                case ExerciseType.MusicListen:
                    await OnPlayListenMode();
                    break;
                case ExerciseType.MusicReapeat:
                    await OnPlayRepeatMode();
                    break;
                default:
                    break;
            }
        }

        private async Task OnPlayListenMode()
        {
            await Task.Delay(10);

            foreach (var item in model.SoundSrcList)
            {
                if (await IsCancellation())
                    return;

                await OnPlaySound(item);
            }

            await Task.Delay(1000);

            if (await IsCancellation())
                return;

            await NextCallback.InvokeAsync(true);
        }

        private async Task OnPlayRepeatMode()
        {
            await Task.Delay(10);
            blocker = true;

            foreach (var item in model.SoundSrcList.Where(x => x.Order != 0).OrderBy(x => x.Order))
            {
                if (await IsCancellation())
                    return;

                await OnPlaySound(item);
            }

            if (await IsCancellation())
                return;

            blocker = false;
        }

        private async Task OnPlaySound(SoundSrcExtension item)
        {
            item.ColorBg = ColorHelper.GetColor(ColorType.Light);
            await Task.Delay(100);
            StateHasChanged();
            var timer = await Sound.PlaySrc(item.SoundSrc);
            await Task.Delay(timer);
            item.ColorBg = ColorHelper.GetColor(ColorType.Normal);
            StateHasChanged();
        }

        private async Task OnClickKey(int id)
        {
            await Task.Delay(10);

            if (!PanelMusicOption.IsRepeatMode(exercisePhase) || blocker)
                return;

            blocker = true;
            var clickItem = model.SoundSrcList[id];

            if (clickItem.Order == 0)
            {
                await ShowBad(clickItem);
                blocker = false;
                return;
            }

            var firstFalseItem = model.SoundSrcList.Where(x => x.IsCorrect == false && x.Order != 0)
                .OrderBy(x => x.Order).FirstOrDefault();

            if (firstFalseItem.Order < clickItem.Order)
            {
                await ShowBad(clickItem);
                blocker = false;
                return;
            }
            else
                await ShowGood(clickItem);

            await CheckAllCorrect();
            blocker = false;
        }

        private void ClearAnswer() =>
            model.SoundSrcList.ForEach(x =>
            {
                x.IsCorrect = false;
                x.ColorBg = ColorHelper.GetColor(ColorType.LightEmpty);
            });

        private void SetRepeatModeKey() =>
            model.SoundSrcList.ForEach(x =>
            {
                x.ColorBg = ColorHelper.GetColor(ColorType.LightEmpty); ;
            });

        private async Task ShowBad(SoundSrcExtension model)
        {

            model.ColorBg = ColorHelper.GetColor(ColorType.Red);
            StateHasChanged();
            await Task.Delay(await Sound.PlaySrc(model.SoundSrc));
            await Sound.PlaySrc(SoundTaskHelper.GetSoundSrc(SoundSrc.TryAgain));
            await Task.Delay(2000);
            model.ColorBg = ColorHelper.GetColor(ColorType.LightEmpty);
            ClearAnswer();
            StateHasChanged();
        }

        private async Task ShowGood(SoundSrcExtension model)
        {
            model.ColorBg = ColorHelper.GetColor(ColorType.Green);
            model.IsCorrect = true;
            StateHasChanged();
            await Task.Delay(await Sound.PlaySrc(model.SoundSrc));
            await Sound.PlaySrc(SoundTaskHelper.GetSoundSrc(SoundSrc.Correct));
            await Task.Delay(500);
        }

        private async Task CheckAllCorrect()
        {
            var tempList = model.SoundSrcList.Where(x => x.Order != 0).ToList();
            if (!tempList.Any(x => x.IsCorrect == false))
            {
                blocker = true;
                await NextCallback.InvokeAsync(true);
            }
        }

        private async Task<bool> IsCancellation()
        {
            if (Cts.Token.IsCancellationRequested)
            {
                await CancelCallback.InvokeAsync(true);
                return true;
            }
            return false;
        }
    }
}
