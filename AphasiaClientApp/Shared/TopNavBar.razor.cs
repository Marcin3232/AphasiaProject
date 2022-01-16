using AphasiaClientApp.Pages.Other;
using AphasiaClientApp.Pages.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Shared
{
    public partial class TopNavBar
    {
        private ReportError reportErrorModal = new ReportError();
        private LanguageSettings languageSettings = new LanguageSettings();

        void Navigation_Login() => UriHelper.NavigateTo("/login");

    }
}
