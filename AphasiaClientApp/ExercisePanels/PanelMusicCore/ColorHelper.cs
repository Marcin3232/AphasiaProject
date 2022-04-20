using AphasiaClientApp.Models.Enums;

namespace AphasiaClientApp.ExercisePanels.PanelMusicCore
{
    public static class ColorHelper
    {
        public static string GetColor(ColorType color) => color switch
        {
            ColorType.Normal => " m-bcw ",
            ColorType.Green => " m-bcg ",
            ColorType.Red => " m-bcr ",
            ColorType.Light => " m-bcn ",
            ColorType.LightEmpty => " m-bcna ",
            _ => " m-bcw "
        };
    }
}
