namespace AphasiaClientApp.Models.Helpers
{
    public class WindowDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public WindowDimension()
        {

        }

        public WindowDimension(int width,int height)
        {
            Width = width;
            Height = height;
        }
    }
}
