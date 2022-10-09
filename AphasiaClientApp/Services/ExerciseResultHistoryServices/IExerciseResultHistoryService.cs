using CommonExercise.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AphasiaClientApp.Services.ExerciseResultHistoryServices
{
    public interface IExerciseResultHistoryService
    {
        Task<List<ExerciseResultHistory>> GetAll();
        Task<ExerciseResultHistory> GetLast(string key);
        Task<int> Insert(ExerciseResultHistory model);
        Task<int> Delete(string key);
    }
}