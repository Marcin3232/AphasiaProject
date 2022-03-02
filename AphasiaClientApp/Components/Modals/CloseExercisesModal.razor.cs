using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Modals
{
    public partial class CloseExercisesModal
    {
        private bool showDialog { get; set; } = false;
        [Parameter]
        public EventCallback<bool> OnClose { get; set; }

        public async Task Show()
        {
            await Task.Delay(1);
            showDialog = true;
            StateHasChanged();
        }

        private Task ModalCancel()
        {
            showDialog = false;
            return OnClose.InvokeAsync(false);
        }


        private Task ModalOk()
        {
            showDialog = false;
            return OnClose.InvokeAsync(true);
        }

    }
}
