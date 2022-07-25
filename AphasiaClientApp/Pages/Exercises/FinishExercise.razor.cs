using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Exercises;

public partial class FinishExercise
{
    [Parameter]
    public string Id { get; set; }
    [Parameter]
    public string IdUser { get; set; }
    void Finish_callback() => UriHelper.NavigateTo("/");
}
