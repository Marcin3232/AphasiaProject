using Microsoft.AspNetCore.Components;

namespace AphasiaClientApp.Components.Texts
{
    public partial class TextFrame
    {
        [Parameter]
        public string Text { get; set; } = "Test";
    }
}
