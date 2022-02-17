using AphasiaProject.Models.Exercises;
using AphasiaProject.Models.ResponseExercise;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AphasiaProject.Services.Exercise
{
    public interface IExerciseService
    {
        Task<List<ExerciseModel>> GetAll();
        Task<ResponseExerciseModel> GetById(int id);
    }
}