using AphasiaClientApp.Models.Enums;

namespace AphasiaClientApp.Models.Constant
{
    public class ColorTypeIsCorrect
    {
        public static ColorType Set(bool? isCorrect) => isCorrect switch
        {
            true => ColorType.Green,
            false => ColorType.Red,
            null => ColorType.Light
        };

        public static ColorType SetWithDotted(bool? isCorrect) => isCorrect switch
        {
            true => ColorType.Green,
            false => ColorType.Red,
            null => ColorType.LightEmpty
        };

        public static ColorType SetWhiteWithDotted(bool? isCorrect) => isCorrect switch
        {
            true => ColorType.Green,
            false => ColorType.Red,
            null => ColorType.NormalEmpty
        };
    }
}
