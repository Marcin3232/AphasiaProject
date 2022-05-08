using AphasiaClientApp.ExercisePanels.BasePanelFunc;
using AphasiaClientApp.Models.Enums;
using AphasiaClientApp.Pages.Exercises;
using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models;
using CommonExercise.Utils;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AphasiaClientApp.ExercisePanels.PanelFindPairGameCore
{
    public partial class PanelFindPairGame
    {
        [CascadingParameter]
        public MainPanel MainPanel { get; set; }
        [Parameter]
        public EventCallback<bool> NextCallback { get; set; }

        private List<PanelFindPairModel> cardList { get; set; }

        private ExercisePhase exercisePhase;
        private bool show { get; set; } = false;
        private int panelTileCount;
        private PanelFindPairModel flippedCard = null;
        private bool blocker = false;


        public PanelFindPairGame()
        {

        }

        public async Task<int> Show(Exercise exercise)
        {
            await Task.Delay(10);

            exercisePhase = exercise.Phases.FirstOrDefault(x => x.IsCurrent);
            var panelList = PanelFindPairGameNormalizer.Get(exercise.ExerciseInformation.ExerciseTaskId, exercise.ExerciseResource);
            panelTileCount = PanelTile.GetCount(exercisePhase);

            cardList = PanelExtension.GetCards(panelList, exercisePhase);
            show = true;
            StateHasChanged();
            await ShowCards();

            //Todo powtórzenia i zmiana listy, na przyszłość
            return 1;
        }

        public Task Close()
        {
            show = false;
            cardList = new List<PanelFindPairModel>();
            StateHasChanged();
            return Task.CompletedTask;
        }

        public async Task ShowTip()
        {
            await Task.Delay(10);

            if (blocker)
                return;

            if (flippedCard != null)
                flippedCard.Flipped = false;

            flippedCard = null;

            MainPanel.HistoryResultDetails.TipClicks++;
            blocker = true;
            var tempList = new List<int>();

            cardList.ForEach(x =>
            {
                if (x.Flipped)
                    tempList.Add(x.Id);
                x.Flipped = true;
            });

            StateHasChanged();
            await Task.Delay(3000);

            cardList.ForEach(x =>
            {
                if (!tempList.Any(y => y == x.Id))
                    x.Flipped = false;
            });

            StateHasChanged();

            blocker = false;
        }

        private async Task ShowCards()
        {
            if (blocker)
                return;

            blocker = true;
            cardList.ForEach(x => x.Flipped = true);
            StateHasChanged();

            await Task.Delay(5000);

            cardList.ForEach(x => x.Flipped = false);
            StateHasChanged();

            blocker = false;
        }

        private async Task Flip(PanelFindPairModel model)
        {
            await Task.Delay(10);

            if (blocker)
                return;

            if (model.Flipped)
                return;

            blocker = true;
            await Task.Delay(200);

            model.Flipped = true;
            StateHasChanged();
            if (flippedCard is null)
                flippedCard = model;
            else
            {
                MainPanel.HistoryResultDetails.Answers++;

                if (flippedCard.Id == model.Id)
                {
                    MainPanel.HistoryResultDetails.CorrectAnswers++;
                    flippedCard = null;
                    await Sound.PlaySrcAsync(SoundTaskHelper.GetSoundSrc(SoundSrc.Correct));
                    StateHasChanged();
                    await Task.Delay(500);
                }
                else
                {
                    MainPanel.HistoryResultDetails.WrongClicks++;
                    await Task.Delay(500);
                    flippedCard.Flipped = false;
                    StateHasChanged();
                    await Task.Delay(100);
                    flippedCard = null;
                    model.Flipped = false;
                    await Sound.PlaySrcAsync(SoundTaskHelper.GetSoundSrc(SoundSrc.TryAgain));
                    StateHasChanged();
                    await Task.Delay(500);
                }
            }

            if (!cardList.Any(x => !x.Flipped))
                await NextCallback.InvokeAsync(true);

            blocker = false;
        }

        private string SetColInLine() => PanelTile.SetTileInRow(cardList.Count);
    }
}
