using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Components.Modals
{
    public partial class CloseExercisesModal
    {

        [Parameter]
        public EventCallback<bool> OnClose { get; set; }
        
        private Task ModalCancel() =>
             OnClose.InvokeAsync(false);

        private Task ModalOk() =>
           OnClose.InvokeAsync(true);

    }
}
