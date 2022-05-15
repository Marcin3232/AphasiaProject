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
        [Parameter]
        public bool ShowHelper { get; set; } = false;
        [Parameter]
        public EventCallback<bool> HelperCallback { get; set; }

        private string ListenCommandPatch => $"/{ListenCommandSrc}.mp3";
        private string idCommandSound = "commandSound";

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        private async Task<int> PlaySound(string sound)
        {
            await Task.Delay(10);
            return string.IsNullOrEmpty(sound) ? 10 : await Sound.PlayAsync(sound);
        }

        private async Task OnHelperClick() => await HelperCallback.InvokeAsync(true);
    }
}
