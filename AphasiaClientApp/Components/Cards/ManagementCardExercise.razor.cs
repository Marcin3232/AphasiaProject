using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Cards
{
    public partial class ManagementCardExercise
    {
        [Parameter]
        public string ImageUrl { get; set; }
        [Parameter]
        public int CardId { get; set; } = 1;
        [Parameter]
        public string ExName { get; set; }
 
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

        private int maxMark => 5;
        private int roundMark => (int)Math.Ceiling(Mark);
        private string isChecked(int i) => i < roundMark ? "checked" : string.Empty;
        private string isFirstElement(int i) => i == 0 ? "margin-left:55px;" : string.Empty;
    }
}
