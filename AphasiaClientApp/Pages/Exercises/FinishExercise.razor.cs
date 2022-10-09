using AphasiaClientApp.Services.ExerciseResultHistoryServices;
using CommonExercise.Enums.Keys;
using Extensions.Base64;
using Extensions.Exercise;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages.Exercises;

public partial class FinishExercise
{
    [Parameter]
    public int Id { get; set; }
    [Parameter]
    public int IdUser { get; set; } = 0;

    [Inject]
    private IExerciseResultHistoryService _exerciseResultHistoryService { get; set; }

    async Task Finish_callback()
    {
        await ClearHistory();
        Navigation.NavigateTo("/choiceTypeAphasia");

    }

    async Task Repeat_callback()
    {
        await ClearHistory();
        Navigation.NavigateTo($"/exercises/main_panel/{Id}/{IdUser}");
    }

    void GoBack_callback() => Navigation.NavigateTo($"/exercises/main_panel/{Id}/{IdUser}");

    async Task ClearHistory()
    {
        await _exerciseResultHistoryService
             .Delete(Base64.Encode(KeyExtension.Generate(Id, IdUser, ExerciseKey.History)));
        await _exerciseResultHistoryService
            .Delete(Base64.Encode(KeyExtension.Generate(Id, IdUser, ExerciseKey.HistoryResult)));
    }
}
