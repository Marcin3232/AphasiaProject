using AphasiaClientApp.Extensions.RequestMethod;
using CommonExercise.Models.Request;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AphasiaClientApp.Services.ExerciseResultHistoryServices;

public class ExerciseResultHistoryService : IExerciseResultHistoryService
{
    private readonly HttpClient _httpClient;
    private readonly IRequestMethod _requestMethod;

    public ExerciseResultHistoryService(HttpClient httpClient,
        IRequestMethod requestMethod)
    {
        _httpClient = httpClient;
        _requestMethod = requestMethod;
    }

    public async Task<List<ExerciseResultHistory>> GetAll() =>
        await _requestMethod.Get<List<ExerciseResultHistory>>("/api/ExerciseResultHistory", _httpClient);

    public async Task<ExerciseResultHistory> GetLast(string key) =>
        await _requestMethod.Get<ExerciseResultHistory>($"/api/ExerciseResultHistory/{key}", _httpClient);

    public async Task<int> Insert(ExerciseResultHistory model) =>
        await _requestMethod.Post<ExerciseResultHistory, int>("/api/ExerciseResultHistory", _httpClient, model);

    public async Task<int> Delete(string key) =>
        await _requestMethod.Post<RequestKey, int>("/api/ExerciseResultHistory/delete", _httpClient, new RequestKey() { Key=key} );
}

