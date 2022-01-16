using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Management
{
    public partial class ManagementExercise
    {
        //lista pobirana z bazy;
        [Inject]
        IJSRuntime JsRuntime { get; set; }

        protected override Task OnInitializedAsync()
        {
            Task.Delay(1);
            StateHasChanged();
            return base.OnInitializedAsync();
            
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Delay(1);
            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
