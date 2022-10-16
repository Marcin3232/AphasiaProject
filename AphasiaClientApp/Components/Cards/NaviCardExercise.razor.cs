using AphasiaClientApp.Extensions;
using AphasiaClientApp.Models.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Cards
{
    public partial class NaviCardExercise
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public bool IsVertical { get; set; }
        [Parameter]
        public NaviTypeImage NaviType { get; set; }
        [Parameter]
        public EventCallback ClickCallback { get; set; }
        [Parameter]
        public bool IsPulse { get; set; } = false;
        private string _imageUrl => Path.PathFile + NaviType.GetAttribute<DisplayAttribute>().Name;

        private string _pulseAnimation => IsPulse ? "pulse" : "";

    }
}
