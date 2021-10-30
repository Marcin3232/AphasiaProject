using Microsoft.AspNetCore.Components;

namespace AphasiaClientApp.Components.Cards
{
    public partial class CenterNaviCardModel
    {
        [Parameter]
        public string TitleExercise { get; set; }
        [Parameter]
        public string TypeTitleExercise { get; set; }

    }
}
