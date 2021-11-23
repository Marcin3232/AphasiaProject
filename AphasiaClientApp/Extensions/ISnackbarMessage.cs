using AphasiaClientApp.Models.Base;
using AphasiaClientApp.Models.Enums;
using MudBlazor;
using System;

namespace AphasiaClientApp.Extensions
{
    public interface ISnackbarMessage
    {
        void Show(string title,string message,StatusType statusType, bool isButton, Action<SnackbarOptions> options);
        void ShowErrorMode(ReportErrorModel errorModel, bool isButton);
        void Remove(Snackbar snackbar);
        void Clear();
        void Dispose();
    }
}
