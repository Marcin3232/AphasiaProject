using System.Collections.Generic;
using System.Threading.Tasks;
using CommonExercise.Models;

namespace AphasiaClientApp.Services
{
    public interface IDbExerciseService
    {
        Task<List<ExerciseName>> GetExerciseNameFromAphasiaType(int type);
    }
}
