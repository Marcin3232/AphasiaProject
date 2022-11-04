using System.Collections.Generic;
using System.Threading.Tasks;
using CommonExercise.Models;

namespace AphasiaClientApp.Services
{
    public interface IDbExerciseService
    {
        Task<List<ExerciseName>> GetExerciseNameFromAphasiaType(int type);
        Task<List<ExerciseNameWithUEID>> GetExerciseNameFromAphasiaTypePreview(int id,int type);
        Task<Exercise> GetExercise(int id);
        Task<Exercise> GetExerciseByExId(int id);
    }
}
