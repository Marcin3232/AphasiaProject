using AphasiaProject.Services.Dapper;
using CommonExercise.Models;
using DataBaseQuery.Exercise;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaProject.Services.Exercise;

public class ExerciseResultHistoryService : IExerciseResultHistoryService
{
    private readonly IDbRepository _repository;

    public ExerciseResultHistoryService(IDbRepository repository)
    {
        _repository = repository;
    }

    public List<ExerciseResultHistory> GetAll() =>
        Task.FromResult(_repository.Get<ExerciseResultHistory>(
            ExerciseResultHistoryQuery.QueryGetExerciseResultHistory(), null)).Result;

    public ExerciseResultHistory GetLast(string key) =>
        Task.FromResult(_repository.Get<ExerciseResultHistory>(
            ExerciseResultHistoryQuery.QueryGetLastExerciseResultHistory(),
            new { Key = key })).Result.FirstOrDefault();

    public async Task<int> Insert(ExerciseResultHistory model) =>
        await _repository.ExecuteAsync(ExerciseResultHistoryQuery.QueryInsertExerciseResultHistory(), model);

    public async Task<int> Update(ExerciseResultHistory model) =>
        await _repository.ExecuteAsync(ExerciseResultHistoryQuery.QueryUpdateExerciseResultHistory(), model);

    public async Task<int> Delete(string key) =>
        await _repository.ExecuteAsync(ExerciseResultHistoryQuery.QueryDeleteExerciseResultHisotry(),
            new { Key = key });
}
