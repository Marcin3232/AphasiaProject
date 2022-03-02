using AphasiaProject.Models.ResponseExercise;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AphasiaProject.Services.Exercise
{
    public interface IExerciseService
    {
        Task<List<ResponseExerciseModel>> GetAll();
        Task<ResponseExerciseModel> GetById(int id);
    }
}