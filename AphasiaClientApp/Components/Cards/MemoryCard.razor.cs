using Microsoft.AspNetCore.Components;

namespace AphasiaClientApp.Components.Cards
{
    public partial class MemoryCard
    {
        [Parameter]
        public bool IsFlipped { get; set; } = false;

        [Parameter]
        public string ImgSrc { get; set; } = string.Empty;

        [Parameter]
        public EventCallback ClickCallback { get; set; }

        private string SetPointer() => IsFlipped ? " " : "cursor: pointer; ";

        private string SetFlipp() => !IsFlipped ? "transform: rotateY(180deg);" : "";

        private string RemoveBackground() => IsFlipped ? "background:none;" : "";

        private string ActionCardActive() => !IsFlipped ? "act-opt" : "";
    }
}
