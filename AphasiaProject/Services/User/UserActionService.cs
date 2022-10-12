using AphasiaProject.Services.Dapper;
using CommonExercise.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBaseQuery.User;
using System.Threading.Tasks;

namespace AphasiaProject.Services.User
{
    public class UserActionService : IUserActionService
    {


        private readonly IDbRepository _repository;

        public UserActionService(IDbRepository repository)
        {
            _repository = repository;
        }
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
