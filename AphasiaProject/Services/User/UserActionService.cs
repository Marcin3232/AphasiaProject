using AphasiaProject.Services.Dapper;
using CommonExercise.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseQuery.User;
using System.Threading.Tasks;
using DataBaseProject.Models.UserExercise;
using DataBaseQuery.ModelHelper;

namespace AphasiaProject.Services.User
{
    public class UserActionService : IUserActionService
    {


        private readonly IDbRepository _repository;

        public UserActionService(IDbRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> createUserExcercises(int key)
        {
            List<UserCreateAphasiaModel> userAphasiaModels = new List<UserCreateAphasiaModel>();
            for(int i = 1;i < 4; i++)
            {
                UserCreateAphasiaModel userAphasiaModel = new UserCreateAphasiaModel();
                userAphasiaModel.IdUser = key;
                userAphasiaModel.AphasiaId = i;
                userAphasiaModel.IsActive = false;
                userAphasiaModels.Add(userAphasiaModel);
            }

            await _repository.ExecuteAsync(UserActionsQuerry.QueryInsertAphasiaTypes(), userAphasiaModels);

            
            var exerciseTemplate = Task.FromResult(_repository.Get<ExerciseModelHelper>(
            UserActionsQuerry.QuerryGetExcercises(),null)).Result;

            var userAphasiaTemplate = Task.FromResult(_repository.Get<CommonExercise.Models.User.UserAphasiaModel>(
            UserActionsQuerry.QueryGetUserAphasia(), new { Key = key })).Result;
            
            

            List<CommonExercise.Models.User.UserExerciseModel> userExerciseModels = new List<CommonExercise.Models.User.UserExerciseModel>();

            exerciseTemplate.ForEach(x =>
            {
                userAphasiaTemplate.ForEach(y =>
                {
                    CommonExercise.Models.User.UserExerciseModel model = new CommonExercise.Models.User.UserExerciseModel();
                    model.IsActive = true;
                    model.ExerciseId = x.Id;
                    model.UserAphasiaId = y.Id;
                    userExerciseModels.Add(model);
                });
            });

            await _repository.ExecuteAsync(UserActionsQuerry.QueryInsertUserExercises(), userExerciseModels);

            var phaseTemplate = Task.FromResult(_repository.Get<ExercisePhaseModel>(
            UserActionsQuerry.QuerryGetPhaseData(), new { Key = key })).Result;


            var getUserExercises = Task.FromResult(_repository.Get<CommonExercise.Models.User.UserExerciseModel>(
            UserActionsQuerry.QuerryGetExercisesForUser(), new { Key = key })).Result;



            List<UserPhaseModel> phaseModelList = new List<UserPhaseModel>();


            getUserExercises.ForEach(x =>
            {
                var phasesForExercises = phaseTemplate.FindAll(y => y.ExerciseId == x.ExerciseId);
                phasesForExercises.ForEach(z =>
                {
                    UserPhaseModel model = new UserPhaseModel();
                    model.UserExerciseId = x.Id;
                    model.ExercisePhaseId = z.Id;
                    model.IsActive = true;
                    phaseModelList.Add(model);
                });
            });

            await _repository.ExecuteAsync(UserActionsQuerry.QueryInsertUserPhases(), phaseModelList);



            throw new NotImplementedException();
        }

        public List<PatientModel> GetPatients(int key) =>
        Task.FromResult(_repository.Get<PatientModel>(
            UserActionsQuerry.QuerryGetPatients(), new { Key = key })).Result;


        public UserPersonalDetailModel GetUserData(int key)
        {
            return Task.FromResult(_repository.Get<UserPersonalDetailModel>(
            UserActionsQuerry.QuerryGetUserPersonalDetails(), new { Key = key })).Result.FirstOrDefault();
        }

        public async Task<int> UpdateUserPersonalData(UserPersonalDetailModel model)
        {
        return await _repository.ExecuteAsync(UserActionsQuerry.QuerryUpdateUserPersonalDetails(), model);
          
        }
    }
}
