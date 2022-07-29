using AphasiaClientApp.Components.Modals.Management;
using AphasiaClientApp.Extensions;
using AphasiaClientApp.Models.Enums;
using AphasiaClientApp.Pages.Management;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Buttons
{
    public partial class ButtonModel
    {
        public RemoveAccount removeAccount = new RemoveAccount();
      

        [Parameter]
        public ButtonTypes ButtonTypes { get; set; }
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public ButtonEventType EventType { get; set; } = ButtonEventType.Button;
        [Parameter]
        public string UrlImage { get; set; }
        [Parameter]
        public EventCallback ButtonCallback { get; set; }

        public string Type => EventType.GetAttribute<DisplayAttribute>().Name;
    }
}
