using AphasiaClientApp.Models.Auth;
using AphasiaClientApp.Models.Management;
using CommonExercise.Models.User.Management;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AphasiaClientApp.Features.AuthService
{
    public interface IAuthenticationService
    {
        Task<AuthResponseDto> Login(UserLoginModel userForAuthentication);
        Task<RegisterResponseDto> Register(UserRegistrationModel userRegistrationModel);

        Task<EditPersonalDataDto> GetPersonalData(string id);

        Task<List<PatientModel>> GetPatients();

        Task<List<PatientExerciseModel>> GetPatientsExercises(string id, string aKey);
        Task<List<UserExercisePhaseModel>> GetPatientPhases(int Key);
        Task Logout();
    }
}
