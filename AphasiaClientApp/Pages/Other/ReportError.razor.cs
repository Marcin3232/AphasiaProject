using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Other
{
    public partial class ReportError
    {
        private bool showDialog { get; set; } = false;

        public async Task Show()=> await DialogEvent(true);
        public async Task Close()=>await DialogEvent(false);

        private async Task DialogEvent(bool isActive)
        {
            await Task.Delay(1);
            showDialog = isActive;
            StateHasChanged();
        }
    }
}
