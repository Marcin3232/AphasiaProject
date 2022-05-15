using AphasiaClientApp.Pages.Exercises;
using CommonExercise.ExerciseResourceProjection;
using CommonExercise.Models;
using CommonExercise.Utils;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AphasiaClientApp.ExercisePanels.PanelOption2Core
{
    public partial class PanelOption2
    {
        [CascadingParameter]
        public MainPanel MainPanel { get; set; }
        [Parameter]
        public EventCallback<bool> NextCallback { get; set; }
        private PanelOption2Model Model { get; set; }
        private bool show { get; set; } = false;
        private ExercisePhase exercisePhase;
        private bool isShowDesc = false;
        private bool isBlocked = false;

        public async Task<int> Show(Exercise exercise)
        {
            await Task.Delay(10);

            exercisePhase = exercise.Phases.FirstOrDefault(x => x.IsCurrent);
            List<PanelOption2Model> panelList = PanelOption2Normalizer.Get(exercise.ExerciseInformation.ExerciseTaskId,
                exercise.ExerciseResource, exercisePhase.Repeat);
            MainPanel.cts = new System.Threading.CancellationTokenSource();
            Model = panelList.Shuffle().FirstOrDefault();
            show = true;
            StateHasChanged();
            await PlayTask();
            StateHasChanged();

            return panelList.Count;
        }
        public Task Close()
        {
            show = false;
            StateHasChanged();
            return Task.CompletedTask;
        }

        private async Task PlayTask()
        {
            await Task.Delay(10);

            if (!PanelOption2Extension.OnShowDesc(exercisePhase))
            {
                await PlayNaviTask();
                await TimerCallback();
                return;
            }

            _ = Task.Factory.StartNew(async () =>
              {
                  await Task.Delay(100);

                  isShowDesc = true;
                  StateHasChanged();

                  foreach (var item in Model.DescModels)
                  {
                      if (MainPanel.cts.Token.IsCancellationRequested)
                          return;

                      item.IsShowBorder = true;
                      StateHasChanged();

                      await Task.Delay(await Sound.PlaySrcAsync(item.TextSoundSrc));

                      for (int i = 0; i < 1000; i++)
                      {
                          await Task.Delay(1);
                          if (MainPanel.cts.Token.IsCancellationRequested)
                              return;
                      }

                      item.IsShowBorder = false;
                      StateHasChanged();
                  }

                  await TimerCallback();
              }, MainPanel.cts.Token);
        }

        private async Task PlayNaviTask()
        {
            await Task.Delay(10);

            _ = Task.Factory.StartNew(async () =>
             {
                 isBlocked = true;
                 await Task.Delay(100);

                 await Task.Delay(await Sound.PlaySrcAsync(Model.MainInstructionSoundSrc));

                 isBlocked = false;

             }, MainPanel.cts.Token);
        }

        private async Task TimerCallback()
        {
            var time = PanelOption2Extension.OnShowDesc(exercisePhase) ? 300 : 3000;

            _ = Task.Factory.StartNew(async () =>
            {

                for (int i = 0; i < time; i++)
                {
                    await Task.Delay(1);

                    if (MainPanel.cts.Token.IsCancellationRequested)
                        return;
                }

                await NextCallback.InvokeAsync(true);

            }, MainPanel.cts.Token);
        }

        private string DescMainImage()
        {
            var desc = "";
            Model.DescModels.ForEach(model => desc += $"{model.Text}, ");
            return desc;
        }

        private async Task PlayButtonSound(string soundSrc)
        {
            if (isBlocked)
                return;

            isBlocked = true;
            await Task.Delay(await Sound.PlaySrcAsync(soundSrc));
            isBlocked = false;
        }
    }
}
