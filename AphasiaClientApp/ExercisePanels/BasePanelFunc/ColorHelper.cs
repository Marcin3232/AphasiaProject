using AphasiaClientApp.Models.Enums;

namespace AphasiaClientApp.ExercisePanels.BasePanelFunc
{
    public static class ColorHelper
    {
        public static string GetBackgroundColors(ColorType color) => color switch
        {
            ColorType.Normal => " bcn ",
            ColorType.Green => " bcg ",
            ColorType.Red => " bcr ",
            ColorType.Light => " bcl ",
            _ => " "
        };

    }
}
