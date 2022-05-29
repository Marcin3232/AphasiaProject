using AphasiaClientApp.Components.Modals;
using AphasiaClientApp.Components.Modals.LoadModals;
using AphasiaClientApp.ExercisePanels.PanelEnumeration;
using AphasiaClientApp.ExercisePanels.PanelFilm;
using AphasiaClientApp.ExercisePanels.PanelFindPairGameCore;
using AphasiaClientApp.ExercisePanels.PanelIndicate;
using AphasiaClientApp.ExercisePanels.PanelMatchCore;
using AphasiaClientApp.ExercisePanels.PanelMatchSentenceCore;
using AphasiaClientApp.ExercisePanels.PanelMusicCore;
using AphasiaClientApp.ExercisePanels.PanelOption1Core;
using AphasiaClientApp.ExercisePanels.PanelOption2Core;
using AphasiaClientApp.Extensions;
using AphasiaClientApp.Models.Constant;
using AphasiaClientApp.Services;
using CommonExercise.Enums;
using CommonExercise.ExerciseHistoryManager;
using CommonExercise.ExercisePanel;
using CommonExercise.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Exercises
{
    public partial class MainPanel
    {
        [Parameter]
        public int? Id { get; set; }
        [Inject]
        public IDbExerciseService dBExerciseService { get; set; }
        [Inject]
        private ISnackbarMessage snackbarMessage { get; set; }
        private Exercise Exercise { get; set; }
        public List<ExerciseHistory> ExerciseHistory { get; set; }
        private ExercisePhase ExercisePhaseCurrent => Exercise?.Phases.FirstOrDefault(x => x.IsCurrent);
        public HistoryResultDetails HistoryResultDetails => ExerciseHistory?
            .FirstOrDefault(x => x.ExercisePhaseId == ExercisePhaseCurrent.Id)?.HistoryResultDetails;

        public CancellationTokenSource cts = new CancellationTokenSource();
        private int maxCounter;
        public int Counter { get; set; } = 0;
        private bool playSound = false;
        private bool goNext = false;
        private bool panelPresentation = true;

        #region componenty

        private LoadingDialogModel dialogLoad = new LoadingDialogModel();
        private CloseExercisesModal dialogExit = new CloseExercisesModal();
        private PanelOption1 panelOption1 = new PanelOption1();
        private PanelIndicate panelIndicate = new PanelIndicate();
        private PanelFilm panelFilm = new PanelFilm();
        private PanelEnumeration panelEnumeration = new PanelEnumeration();
        private PanelMatch panelMatch = new PanelMatch();
        private PanelMusic panelMusic = new PanelMusic();
        private PanelFindPairGame panelFindPairGame = new PanelFindPairGame();
        private PanelOption2 panelOption2 = new PanelOption2();
        private PanelMatchSentence panelMatchSentence = new PanelMatchSentence();

        #endregion

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(10);
            await dialogLoad.Show();
            // TODO: dokonczyć
            //if (HasValue(Id))
            //{
            //    return;
            //}

            Exercise = await dBExerciseService.GetExercise((int)Id);

            if (Exercise == null)
            {
                snackbarMessage.Show("Ostrzeżenie", "Ćwiczenie chwilowo niedostępne.", Models.Enums.StatusType.Warning, false, null);
                await Task.Delay(1000);
                Navigation.NavigateBack();
                return;
            }

            ExerciseHistory = HistoryManager.Initialize(Exercise);
            NumericPhase(Exercise);
            await dialogLoad.Close();
            panelPresentation = true;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender && panelPresentation)
            {
                await Task.Delay(100);
                await StartNewPanel();
            }
        }

        private bool HasValue(object item) => item != null;

        private async Task ShowPanel(bool show = true)
        {
            if (!Enum.IsDefined(typeof(ExerciseType), ExercisePhaseCurrent?.Type))
            {
                // TODO: dokonczyc błąd => notification i do menu glownego
            }

            var type = (ExerciseType)ExercisePhaseCurrent?.Type;

            switch (GetExercisePanel(type))
            {
                case ExercisePanelOption.PanelOption1:
                    maxCounter = await panelOption1.Show(Exercise);
                    break;
                case ExercisePanelOption.PanelIndicate:
                    maxCounter = await panelIndicate.Show(Exercise);
                    break;
                case ExercisePanelOption.PanelFilm:
                    maxCounter = await panelFilm.Show(Exercise);
                    break;
                case ExercisePanelOption.PanelEnumeration:
                    maxCounter = await panelEnumeration.Show(Exercise);
                    break;
                case ExercisePanelOption.PanelMatch:
                    maxCounter = await panelMatch.Show(Exercise);
                    break;
                case ExercisePanelOption.PanelMusic:
                    maxCounter = await panelMusic.Show(Exercise);
                    break;
                case ExercisePanelOption.PanelFindPairGame:
                    maxCounter = await panelFindPairGame.Show(Exercise);
                    break;
                case ExercisePanelOption.PanelOption2:
                    maxCounter = await panelOption2.Show(Exercise);
                    break;
                case ExercisePanelOption.PanelMatchSentence:
                    maxCounter = await panelMatchSentence.Show(Exercise);
                    break;
                case ExercisePanelOption.Default:
                    // TODO: dokonczyć blad notification i do menu glownego
                    break;
            }
        }

        private async Task ClearPage()
        {
            Clear();
            await panelOption1.Close();
            await panelIndicate.Close();
            await panelFilm.Close();
            await panelEnumeration.Close();
            await panelMatch.Close();
            await panelFindPairGame.Close();
            await panelOption2.Close();
            await panelMusic.Close();
            await panelMatchSentence.Close();
        }

        private ExercisePanelOption GetExercisePanel(ExerciseType type) =>
            ExercisePanelManager.GetPanel(type);

        private void OnCloseExerciseDialog(bool result)
        {
            if (result)
            {
                // TODO zapisywanie settingsow
                Navigation.NavigateBack();
            }
        }

        private void NumericPhase(Exercise exercise)
        {
            int i = 1;
            exercise.Phases.OrderBy(x => x.PhaseNameId).ToList().ForEach(p =>
            {
                p.IsDone = i == 1 ? true : false;
                p.IsCurrent = i == 1 ? true : false;
                p.Order = i;
                i++;
            });
        }

        private async Task OnFooterAction(bool action)
        {
            if (action)
            {
                cts.Cancel();
                await Task.Delay(10);
                await StartNewPanel();
            }
        }

        private async Task Next()
        {
            cts.Cancel(true);
            await Task.Delay(10);
            goNext = false;
            if (Counter == maxCounter - 1)
            {
                if (NextPhase(true))
                {
                    return; //TODO zamykanie cwiczenia
                }

                await StartNewPanel();
                return;
            }
            await IsPlayTitle();
            playSound = true;
            Counter++;
        }

        private async Task Back()
        {
            cts.Cancel();
            await Task.Delay(10);
            goNext = false;
            if (Exercise.Phases.FirstOrDefault(x => x.IsCurrent).Order == 1 && Counter == 0)
                return;

            if (Counter == 0)
            {
                if (NextPhase())
                    return;
                await StartNewPanel();
                return;
            }
            await IsPlayTitle();
            playSound = true;
            Counter--;
        }

        private Task Refresh()
        {
            return Task.CompletedTask;
        }

        private bool NextPhase(bool isUp = false)
        {
            var currentPosition = Exercise.Phases.FirstOrDefault(x => x.IsCurrent).Order;

            var newPosition = isUp ? currentPosition + 1 : currentPosition - 1;
            var maxOrder = Exercise.Phases.Max(x => x.Order);

            if (maxOrder < newPosition)
                return true;

            Exercise.Phases.ForEach(x =>
            {
                if (x.Order == newPosition)
                    x.IsCurrent = true;
                else
                    x.IsCurrent = false;

                if (x.Order <= newPosition)
                    x.IsDone = true;
                else
                    x.IsDone = false;
            });

            StateHasChanged();
            return false;
        }

        private void Clear()
        {
            Counter = 0;
            maxCounter = 0;
            playSound = false;
        }

        private void TimerHistory()
        {
            Exercise.Phases.ForEach(item =>
            {
                if (item.IsCurrent)
                    HistoryManager.Start(ExerciseHistory, item);
                else
                    HistoryManager.End(ExerciseHistory, item);
            });
        }

        private async Task StartNewPanel()
        {
            await Task.Delay(10);
            await ClearPage();
            await PlayTitle();
            playSound = true;
            await ShowPanel();
            TimerHistory();
            panelPresentation = false;
        }

        private async Task PlayTitle()
        {
            var src = $"/{Exercise.Phases.FirstOrDefault(x => x.IsCurrent)?.SoundSrc}.mp3";
            var delayTime = await SoundService.PlaySrcAsync(src);
            await Task.Delay(delayTime);
        }

        private async Task IsPlayTitle()
        {
            if (ExercisePhaseCurrent.IsSoundEveryStep)
                await PlayTitle();
        }

        private async Task OnHelperClick()
        {
            var type = (ExerciseType)ExercisePhaseCurrent?.Type;

            switch (GetExercisePanel(type))
            {
                case ExercisePanelOption.PanelIndicate:
                    await panelIndicate.ShowTip();
                    break;
                case ExercisePanelOption.PanelEnumeration:
                    await panelEnumeration.ShowTip();
                    break;
                case ExercisePanelOption.PanelMatch:
                    await panelMatch.ShowTip();
                    break;
                case ExercisePanelOption.PanelFindPairGame:
                    await panelFindPairGame.ShowTip();
                    break;
                case ExercisePanelOption.PanelMatchSentence:
                    await panelMatchSentence.ShowTip();
                    break;
                case ExercisePanelOption.Default:
                    break;
            }
            StateHasChanged();
        }

        private async Task OnGoNext(bool action)
        {

            goNext = action;
            if (goNext)
                await SoundService.PlaySrcAsync(GoNext.GoNextSrc());

        }

        private void OnCancel(bool action) =>
            cts = new CancellationTokenSource();

    }
}
