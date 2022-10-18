using CommonExercise.Models.User;
using CommonExercise.Models.User.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AphasiaProject.Services.User
{
    public interface IUserActionService
    {
        UserPersonalDetailModel GetUserData(int key);
        Task<int> UpdateUserPersonalData(UserPersonalDetailModel model);

        Task<int> createUserExcercises(int key);
        List<PatientModel> GetPatients(int key);

        List<AphasiaExerciseModel> GetPacientsExercises(int key, int aphasia);
    } 
}
