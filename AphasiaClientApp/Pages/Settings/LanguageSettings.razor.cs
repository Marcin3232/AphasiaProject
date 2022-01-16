using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Settings
{
    public partial class LanguageSettings
    {
        private bool showDialog { get; set; } = false;

        public async Task Show() => await DialogEvent(true);
        public async Task Close() => await DialogEvent(false);

        private async Task DialogEvent(bool isActive)
        {
            await Task.Delay(1);
            showDialog = isActive;
            StateHasChanged();
        }
    }
}
