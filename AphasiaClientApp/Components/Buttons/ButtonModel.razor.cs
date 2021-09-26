using AphasiaClientApp.Models.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Buttons
{
    public partial class ButtonModel
    {
        [Parameter]
        public ButtonTypes ButtonTypes { get; set; }
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public EventCallback ButtonCallback { get; set; }
    }
}
