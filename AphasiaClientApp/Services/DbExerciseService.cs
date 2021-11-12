using AphasiaClientApp.Extensions.RequestMethod;
using CommonExercise.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AphasiaClientApp.Services
{
    public class DbExerciseService:IDbExerciseService
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestMethod _requestMethod;

        public DbExerciseService(HttpClient httpClient, IRequestMethod requestMethod)
        {
            _httpClient = httpClient;
            _requestMethod = requestMethod;
        }

        public async Task<List<ExerciseName>> GetExerciseNameFromAphasiaType(int type) =>
            await _requestMethod.Get<List<ExerciseName>>($"/api/exercises/avaibleExerciseFromTypes/{type}", _httpClient);
    }
}
