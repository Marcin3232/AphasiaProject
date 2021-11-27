using AphasiaClientApp.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Modals.LoadModals
{
    public partial class LoadingDialogModel
    {
        private bool showDialog { get; set; } = false;
        public  async Task Show() => await DialogEvent(true);

        public async Task Close() => await DialogEvent(false);

        private async Task DialogEvent(bool isActive)
        {
            await Task.Delay(1);
            showDialog = isActive;
            StateHasChanged();
        }
    }
}
