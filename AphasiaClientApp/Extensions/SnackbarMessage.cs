using AphasiaClientApp.Models.Base;
using AphasiaClientApp.Models.Enums;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AphasiaClientApp.Extensions
{
    public class SnackbarMessage : ISnackbarMessage
    {
        [Inject]
        private ISnackbar snackbar { get; set; }
        private Variant variant { get; set; } = Variant.Filled;

        public SnackbarMessage(ISnackbar snackbar)
        {
            this.snackbar = snackbar;
        }

        public void Show(string title, string message, StatusType statustype, bool isButton = false, Action<SnackbarOptions> options = null)
        {
            snackbar.Configuration.SnackbarVariant = variant;
            snackbar.Add(TextFormatter(title, message), SetSeverity(statustype), SetOptions());
        }

        public void ShowErrorMode(ReportErrorModel errorModel, bool isButton)
        {
            snackbar.Configuration.SnackbarVariant = variant;
            snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            snackbar.Add(TextFormatter(ReportErrorModel.Error, ReportErrorModel.BaseMessage), SetSeverity(StatusType.Error), SetErrorOptions(isButton));
        }

        public void Clear() => snackbar.Clear();

        public void Remove(Snackbar snackbar) => this.snackbar.Remove(snackbar);

        public void Dispose() => snackbar.Dispose();

        private string TextFormatter(string title, string message) => $"<b>{title}</b><p>{message}</p>";

        private Severity SetSeverity(StatusType statusType)
        {
            switch (statusType)
            {
                case StatusType.Success:
                    return Severity.Success;
                case StatusType.Error:
                    return Severity.Error;
                case StatusType.Warning:
                    return Severity.Warning;
                case StatusType.Informational:
                    return Severity.Info;
                case StatusType.Critical:
                    return Severity.Error;
                default:
                    return Severity.Normal;
            }
        }

        private Action<SnackbarOptions> SetErrorOptions(bool isButton) => configuration =>
        {
            BaseConfiguration(configuration);
            if (isButton)
            {
                configuration.Action = ReportErrorModel.ReportError;
                configuration.ActionColor = Color.Warning;
                configuration.ActionVariant = Variant.Outlined;
                configuration.Onclick = snackbar =>
                {
                    ReportError();
                    return Task.CompletedTask;
                };
            }
        };

        private Action<SnackbarOptions> SetOptions() => configuration =>
         {
             configuration.SnackbarVariant = Variant.Outlined;
             BaseConfiguration(configuration);
         };

        private void BaseConfiguration(SnackbarOptions configuration)
        {
            configuration.ShowCloseIcon = true;
            configuration.VisibleStateDuration = 10000;
            configuration.HideTransitionDuration = 500;
            configuration.ShowTransitionDuration = 500;
        }

        // TODO do uzupełnienia pozniej 
        private void ReportError() { }
    }
}
