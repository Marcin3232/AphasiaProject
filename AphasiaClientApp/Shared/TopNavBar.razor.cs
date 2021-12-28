using AphasiaClientApp.Pages.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Shared
{
    public partial class TopNavBar
    {
        private ReportError reportErrorModal = new ReportError();

        void Navigation_Login() => UriHelper.NavigateTo("/login");

    }
}
