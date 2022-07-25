using CommonExercise.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AphasiaProject.Services.Exercise
{
    public interface IExerciseResultHistoryService
    {
        List<ExerciseResultHistory> GetAll();
        ExerciseResultHistory GetLast(string key);
        Task<int> Insert(ExerciseResultHistory model);
    }
}