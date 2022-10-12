using AphasiaClientApp.Models.Auth;
using System.Threading.Tasks;

namespace AphasiaClientApp.Features.AuthService
{
    public interface IAuthenticationService
    {
        Task<AuthResponseDto> Login(UserLoginModel userForAuthentication);
        Task<RegisterResponseDto> Register(UserRegistrationModel userRegistrationModel);

        Task<EditPersonalDataDto> GetPersonalData(string id);

        Task Logout();
    }
}
