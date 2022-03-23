
namespace AphasiaClientApp.Pages
{
    public partial class Index
    {
        protected override void OnInitialized()
        {

        }

        void ButtonNavigationToAphasiaType()
        {

            UriHelper.NavigateTo("/choiceTypeAphasia");
        }

        void Navigation()
        {
            UriHelper.NavigateTo("/management/mainPanel");
        }
    }
}
