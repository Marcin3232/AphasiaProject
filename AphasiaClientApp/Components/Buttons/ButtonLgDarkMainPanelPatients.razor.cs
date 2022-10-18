using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Buttons
{
    public partial class ButtonLgDarkMainPanelPatients
    {
        [Parameter]
        public EventCallback ButtonCallback { get; set; }
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public string Id { get; set; }
    }
}
