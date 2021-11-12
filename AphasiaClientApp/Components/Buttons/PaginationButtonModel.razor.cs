using Microsoft.AspNetCore.Components;

namespace AphasiaClientApp.Components.Buttons
{
    public partial class PaginationButtonModel
    {
        [Parameter]
        public int Value { get; set; }
        [Parameter]
        public bool IsActive { get; set; } = false;
        [Parameter]
        public EventCallback ButtonCallback { get; set; }
        [Parameter]
        public string SetStyle { get; set; } = "";

        private string SetStyleButton() => IsActive ? "ic-active" : "ic-light btn-ic-action";
        private string SetTextColor() => IsActive ? "white" : "#055961";
    }
}
