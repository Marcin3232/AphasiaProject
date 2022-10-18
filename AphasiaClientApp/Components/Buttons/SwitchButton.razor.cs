using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Buttons
{



    public partial class SwitchButton
    {
        [Parameter]
        public string PhaseName { get; set; }

        [Parameter]
        public int PhaseId{get; set; }

        [Parameter]
        public string IsActivated{get; set; }

        [Parameter]
        public string Description { get; set; }
        [Parameter]
        public bool Checked { get; set; }
        public void change()
        {
            string activated = IsActivated;
            if(IsActivated == "False")
            {
                Checked= true;
            }
            if (activated == "False")
            {
                IsActivated = "True";

            }
            if (activated == "True")
            {
                IsActivated = "False";

            }
        }

    }
}
