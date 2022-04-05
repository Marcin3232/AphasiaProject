using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Banners
{
    public partial class BannerPanel
    {
        private string currentUrl { get; set; } = "test";
        private string currentUser { get; set; }  

        [Inject]
        private ILocalStorageService localStorage { get; set; }
      
        protected override async void OnInitialized()
        {
            await getUserEmail();
            currentUrl = navigationManager.ToBaseRelativePath(navigationManager.Uri).ToString();
            StateHasChanged();
        }
        public async Task getUserEmail()
        {
            currentUser = await localStorage.GetItemAsync<string>("therapistEmail");
        }
   
    }
}
