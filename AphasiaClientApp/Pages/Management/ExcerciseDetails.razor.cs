using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Management
{
    public partial class ExcerciseDetails
    {
        [Inject]
        IJSRuntime JsRuntime { get; set; }

        protected override void OnInitialized()
        {

        }
        async Task SaveAsync()
        {
            string name = await JsRuntime.InvokeAsync<string>("prompt", "What is your name?");
            await JsRuntime.InvokeVoidAsync("alert", $"Hello {name}!");
        }

        void RedirectToResults()
        {
            UriHelper.NavigateTo("/results");
        }

        void RedirectToExcercisePreview()
        {
            UriHelper.NavigateTo("/excercisePreview");
        }
    }
}
