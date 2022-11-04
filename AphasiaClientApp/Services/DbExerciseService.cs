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

        public async Task<Exercise> GetExercise(int id) =>
            await _requestMethod.Get<Exercise>($"/api/Exercises/{id}", _httpClient);
        public async Task<Exercise> GetExerciseByExId(int id) =>
         await _requestMethod.Get<Exercise>($"/api/Exercises/preview/{id}", _httpClient);

        public  async Task<List<ExerciseNameWithUEID>> GetExerciseNameFromAphasiaTypePreview(int id, int type)=>
            await _requestMethod.Get<List<ExerciseNameWithUEID>>($"/api/Exercises/preview/list/{id}/{type}", _httpClient);

    }
}
