using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages
{
    public partial class Index
    {
        void ButtonNavigationToAphasiaType()
        {
            UriHelper.NavigateTo("/choiceTypeAphasia");
        }

        void Navigation()
        {
            UriHelper.NavigateTo("/login");
        }
    }
}
