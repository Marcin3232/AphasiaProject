using AphasiaClientApp.Components.Cards;
using AphasiaClientApp.Components.Modals;
using AphasiaClientApp.Components.Modals.LoadModals;
using AphasiaClientApp.ExercisePanels;
using AphasiaClientApp.Extensions;
using AphasiaClientApp.Services;
using CommonExercise.Enums;
using CommonExercise.ExercisePanel;
using CommonExercise.Models;
using CommonExercise.Models.ExerciseResource;
using CommonExercise.Utils;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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

        private int maxCounter;
        private int counter = 0;
        private bool playSound = false;

        private bool panelPresentation = true;

        #region componenty

        private LoadingDialogModel dialogLoad = new LoadingDialogModel();
        private CloseExercisesModal dialogExit = new CloseExercisesModal();
        private CenterNaviCardModel centerNavi = new CenterNaviCardModel();
        private PanelOption1 panelOption1 = new PanelOption1();

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
            NumericPhase(Exercise);
            await dialogLoad.Close();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender && panelPresentation)
            {
                await StartNewPanel();
            }
        }

        private bool HasValue(object item) => item != null;

        private async Task ShowPanel(ExercisePhase phase)
        {
            if (!Enum.IsDefined(typeof(ExerciseType), phase.Type))
            {
                // TODO: dokonczyc błąd => notification i do menu glownego
            }

            var type = (ExerciseType)phase.Type;
            Clear();
            switch (GetExercisePanel(type))
            {
                case ExercisePanelOption.PanelOption1:

                    var tempList = PanelOption1Normalizer
                        .Get(Exercise.ExerciseInformation.ExerciseTaskId,
                        Exercise.ExerciseResource, Exercise.Phases.FirstOrDefault(x => x.IsCurrent == true).Repeat);
                    maxCounter = tempList.Count;
                    await panelOption1.Show(tempList);
                    break;
                case ExercisePanelOption.PanelIndicate:

                    break;
                case ExercisePanelOption.Default:
                    // TODO: dokonczyć blad notification i do menu glownego
                    break;
            }
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
               StartNewPanel();
            }
        }

        private async Task Next()
        {
            if (counter == maxCounter - 1)
            {
                if (NextPhase(true))
                    return; //TODO zamykanie cwiczenia

                await StartNewPanel();
                return;
            }
            playSound = true;
            counter++;
        }

        private async Task Back()
        {
            if (Exercise.Phases.FirstOrDefault(x => x.Order == 1).Order == 1 && counter == 0)
                return;

            if (counter == 0)
            {
                await StartNewPanel();
                return;
            }
            playSound = true;
            counter--;
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
            counter = 0;
            maxCounter = 0;
            playSound = false;
        }

        private async Task StartNewPanel()
        {
            await Task.Delay(10);
            var delayTime = await centerNavi.Initialize();
            await Task.Delay(delayTime);
            playSound = true;
            await ShowPanel(Exercise.Phases.FirstOrDefault(x => x.IsCurrent));
            panelPresentation = false;
        }

        private async Task SetMaxCounter(int max) => maxCounter = max;
        private async Task SetSoundPlay(bool play) => playSound = play;
    }
}
