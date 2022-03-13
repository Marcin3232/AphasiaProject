using AphasiaProject.Models.Helpers;
using AphasiaProject.Models.ResponseExercise;
using AphasiaProject.Services.Dapper;
using DataBaseQuery.Exercise;
using ExerciseResource.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaProject.Services.Exercise
{
    public class ExerciseService : IExerciseService
    {
        private readonly IDbRepository _repository;
        private readonly IExerciseResourcesFactory _exerciseResourceFactory;

        public ExerciseService(IDbRepository repository, IExerciseResourcesFactory exerciseResourceFactory)
        {
            _repository = repository;
            _exerciseResourceFactory = exerciseResourceFactory;
        }

        public Task<List<ResponseExerciseModel>> GetAll()
        {
            throw new Exception();
        }

        public async Task<ResponseExerciseModel> GetById(int id)
        {
            var information = GetExerciseInformation(id);

            if (information == null)
                return null;

            var phase = GetExercisePhase(information.ExerciseId);

            if (!phase.Any())
                return null;

            var resource = GetExerciseResource(information.ExerciseTaskId);

            if (resource == null)
                return null;

            return CreateExercise(information, phase, resource);
        }

        private List<ResponseExercisePhase> GetExercisePhase(int id)
        {
            var query = $"{ExerciseQuery.QuerySelectPhaseExerciseResponse()} WHERE ep.\"ExerciseId\" = @{nameof(SingleValue<int>.Value)};";
            return Task.FromResult(_repository.Get<ResponseExercisePhase>(query, new SingleValue<int>() { Value = id })).Result;
        }

        private ResponseExerciseInformation GetExerciseInformation(int id)
        {
            var query = $"{ExerciseQuery.QuerySelectExerciseInformationResponse()} WHERE e.\"ExerciseNameId\" = @{nameof(SingleValue<int>.Value)};";
            return Task.FromResult(_repository.Get<ResponseExerciseInformation>(query, new SingleValue<int>() { Value = id })).Result.FirstOrDefault();
        }

        private object GetExerciseResource(string idExerciseTask) => _exerciseResourceFactory.ExerciseResourceList(idExerciseTask);

        private ResponseExerciseModel CreateExercise(ResponseExerciseInformation information,
            List<ResponseExercisePhase> phases, object resources) => new ResponseExerciseModel()
            {
                ExerciseInformation = information,
                Phases = phases,
                ExerciseResource = resources
            };
    }
}
