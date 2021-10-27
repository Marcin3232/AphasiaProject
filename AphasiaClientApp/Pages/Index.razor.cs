
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
            UriHelper.NavigateTo("/exercises/main_panel");
        }
    }
}
