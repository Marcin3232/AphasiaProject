 using AphasiaClientApp.Extensions.RequestMethod;
using AphasiaClientApp.Features.AuthProviders;
using AphasiaClientApp.Models.Auth;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AphasiaClientApp.Features.AuthService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly IRequestMethod _requestMethod;
        public AuthenticationService(IRequestMethod requestMethod, HttpClient client, AuthenticationStateProvider authStateProvider, ILocalStorageService localStorage)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _requestMethod = requestMethod;
        }

      
    
        public async Task<RegisterResponseDto> Register(UserRegistrationModel model) 
        {
            //await _requestMethod.Post<UserRegistrationModel, RegisterResponseDto>($"/api/userControllers/register", _client,model);
            var content = JsonSerializer.Serialize(model);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var registerResult = await _client.PostAsync("/api/userControllers/register", bodyContent);
            var registerContent = await registerResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RegisterResponseDto>(registerContent, _options);
            if (!registerResult.IsSuccessStatusCode)
                return result;

            return new RegisterResponseDto { IsSuccessful = true };
        }
 

        public async Task<AuthResponseDto> Login(UserLoginModel userForAuthentication)
        {
            var content = JsonSerializer.Serialize(userForAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var authResult = await _client.PostAsync("/api/userControllers/login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AuthResponseDto>(authContent, _options);

            if (!authResult.IsSuccessStatusCode)
                return result;

            await _localStorage.SetItemAsync("authToken", result.Token);
            await _localStorage.SetItemAsync("therapistId", JwtParser.doctorId);
            await _localStorage.SetItemAsync("therapistEmail", JwtParser.doctorEmail);

            ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Token);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

            return new AuthResponseDto { IsAuthSuccessful = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<EditPersonalDataDto> GetPersonalData(string a)
        {
            
            var registerResult = await _client.GetAsync("/api/userControllers/edit/personalData/"+a);
            var registerContent = await registerResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<EditPersonalDataDto>(registerContent, _options);
            return result;
        }

    }
}