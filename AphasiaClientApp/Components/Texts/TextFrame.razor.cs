using AphasiaClientApp.Models.Enums;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Texts
{
    public partial class TextFrame
    {
        [Parameter]
        public string Text { get; set; } = "Test";
        [Parameter]
        public ColorType Color { get; set; } = ColorType.Normal;

        [Parameter]
        public bool IsResponsive { get; set; } = false;
        [Parameter]
        public bool IsClickable { get; set; } = false;
        [Parameter]
        public EventCallback ClickCallback { get; set; }

        private string SetBackgroundColors(ColorType color) => color switch
        {
            ColorType.Normal => " bcn ",
            ColorType.Green => " bcg ",
            ColorType.Red => " bcr ",
            ColorType.Light => " bcl ",
            ColorType.LightEmpty => " bcle ",
            ColorType.NormalEmpty => " bcne ",
            _ => " ",
        };

        private string SetResponsive(bool isResponsive) => isResponsive ? "auto-size" : "state-size";
        private string SetPointer => IsClickable ? "cursor:pointer" : " ";

        private string SetAction(ColorType color)
        {
            if (IsClickable)
            {
                switch (color)
                {
                    case ColorType.Normal:
                        return " bcn-action ";
                    case ColorType.NormalEmpty:
                        return " bcn-action ";
                    default:
                        return " ";
                }
            }
            return " ";
        }
    }
}
