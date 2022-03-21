using AphasiaClientApp.Models.Enums;
using Microsoft.AspNetCore.Components;

namespace AphasiaClientApp.Components.Texts
{
    public partial class TextFrame
    {
        [Parameter]
        public string Text { get; set; } = "Test";
        [Parameter]
        public ColorType Color { get; set; } = ColorType.Normal;

        private string SetBackgroundColors(ColorType color) => color switch
        {
            ColorType.Normal => " bcn ",
            ColorType.Green => " bcg ",
            ColorType.Red => " bcr "
        };

    }
}
