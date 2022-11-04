using AphasiaProject.Models.ResponseExercise;
using CommonExercise.Models;
using CommonExercise.Models.User.Management;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AphasiaProject.Services.Exercise
{
    public interface IExerciseService
    {
        Task<List<ResponseExerciseModel>> GetAll();
        Task<ResponseExerciseModel> GetById(int id);
        Task<ResponseExerciseModel> GetByIdExercise(int id);
        List<ExerciseNameWithUEID> GetExerciseName(int id,int type);
        public  Task<int> UpdateUserExercies(List<ExcerciseCartManagementModel> model);
        public List<UserExercisePhaseModel> GetExercisePhases(int key);

        public Task<int> UpdateUserPhase(List<UserPhaseSaveModel> model);

    }
}