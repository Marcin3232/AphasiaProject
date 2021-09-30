using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Cards
{
    public partial class TaskCardModel
    {
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public string Url { get; set; }
        [Parameter]
        public string ImageUrl { get; set; }
    }
}
