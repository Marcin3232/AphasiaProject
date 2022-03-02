using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Cards
{
    public partial class CenterNaviCardModel
    {
        [Parameter]
        public string TitleExercise { get; set; }
        [Parameter]
        public string TypeTitleExercise { get; set; }
        [Parameter]
        public string ListenCommandSrc { get; set; }

        private string ListenCommandPatch => "/"+ListenCommandSrc +".mp3";
        private string idCommandSound = "commandSound";

        public async Task<int> Initialize()
        {
            return await PlaySound(idCommandSound);
        }

        private async Task<int> PlaySound(string sound)
        {
            await Task.Delay(10);
            return await JsRuntime.InvokeAsync<int>("PlaySound", sound);
        }
    }
}
