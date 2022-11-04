using AphasiaProject.Models.Helpers;
using AphasiaProject.Models.ResponseExercise;
using AphasiaProject.Services.Dapper;
using CommonExercise.Models;
using CommonExercise.Models.User.Management;
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

        public async Task<ResponseExerciseModel> GetByIdExercise(int id)
        {
            var information = GetExerciseInformationTest(id);

            if (information == null)
                return null;

            var phase = GetExercisePhaseTest(id);

            if (!phase.Any())
                return null;

            var resource = GetExerciseResource(information.ExerciseTaskId);

            if (resource == null)
                return null;

            return CreateExercise(information, phase, resource);
        }




        private List<ResponseExercisePhase> GetExercisePhaseTest(int id)
        {
            var query = $"{ExerciseQuery.QuerySelectPhaseExerciseResponseExercise()} WHERE ue.\"Id\" = @{nameof(SingleValue<int>.Value)} and upe.\"IsActive\" is true;";
            return Task.FromResult(_repository.Get<ResponseExercisePhase>(query, new SingleValue<int>() { Value = id })).Result;
        }


        private ResponseExerciseInformation GetExerciseInformationTest(int id)
        {
            var query = $"{ExerciseQuery.QuerySelectExerciseInformationResponseExercise()} WHERE ue.\"Id\" = @{nameof(SingleValue<int>.Value)};";
            return Task.FromResult(_repository.Get<ResponseExerciseInformation>(query, new SingleValue<int>() { Value = id })).Result.FirstOrDefault();
        }



        private List<ResponseExercisePhase> GetExercisePhase(int id)
        {
            var query = $"{ExerciseQuery.QuerySelectPhaseExerciseResponse()} WHERE ep.\"ExerciseId\" = @{nameof(SingleValue<int>.Value)} and ep.\"IsActive\" is true;";
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

        public async Task<int> UpdateUserExercies(List<ExcerciseCartManagementModel> model)
        {
            return await _repository.ExecuteAsync(ExerciseQuery.UserExerciseInsert(), model);
        }

        public List<UserExercisePhaseModel> GetExercisePhases(int key) =>
            Task.FromResult(_repository.Get<UserExercisePhaseModel>(
            ExerciseQuery.GetUserExercisePhases(), new { Key = key })).Result;

        public async Task<int> UpdateUserPhase(List<UserPhaseSaveModel> model)
        {
            return await _repository.ExecuteAsync(ExerciseQuery.UserPhaseUpdate(), model);
        }

        public List<ExerciseNameWithUEID> GetExerciseName(int id, int type) =>
            Task.FromResult(_repository.Get<ExerciseNameWithUEID>(
            ExerciseQuery.QuerySelectExNames(), new { Key = id ,Key2 = type})).Result;
        
    }
}
