using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Exercises
{
    public partial class FinishExercise
    {
        void Finish_callback() => UriHelper.NavigateTo("/");
    }
}
