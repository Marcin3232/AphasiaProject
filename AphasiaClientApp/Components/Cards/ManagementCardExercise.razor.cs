﻿using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Cards
{
    public partial class ManagementCardExercise
    {
        [Parameter]
        public string ImageUrl { get; set; }
        [Parameter]
        public int Order { get; set; }
        [Parameter]
        public int UserExId { get; set; }
        [Parameter]
        public string ExName { get; set; }
        [Parameter]
        public string Disabled { get; set; } = "false";

        [Parameter]
        public string Style { get; set; } = "background:white;";


        [Parameter]
        public EventCallback ButtonCallback { get; set; }
        [Parameter]
        public double Mark { get; set; } = 3.56;
        
        protected override Task OnInitializedAsync()
        {
            Task.Delay(1);
            StateHasChanged();
            return base.OnInitializedAsync();
        }

        public void change()
        {
            string disabled = Disabled;
            if (disabled == "False")
            {
                Disabled = "True";
                Style = "background:#d3d3d3;";
            }
            if (disabled == "True")
            {
                Disabled = "False";
                Style = "background:white;";
            }
        }

        private int maxMark => 5;
        private int roundMark => (int)Math.Ceiling(Mark);
        private string isChecked(int i) => i < roundMark ? "checked" : string.Empty;
        private string isFirstElement(int i) => i == 0 ? "margin-left:55px;" : string.Empty;
    }
}
