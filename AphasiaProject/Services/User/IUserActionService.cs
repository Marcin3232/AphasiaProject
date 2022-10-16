using CommonExercise.Models.User;
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

        List<PatientModel> GetPatients(int key);
    }
}
