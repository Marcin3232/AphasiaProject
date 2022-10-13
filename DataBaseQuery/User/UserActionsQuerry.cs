using CommonExercise.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseQuery.User
{
    public class UserActionsQuerry
    {


        public static string QuerryGetPatients() =>
        $"SELECT " +
        $"\"{nameof(PatientModel.Id)}\", " +
        $"\"{nameof(PatientModel.UserName)}\", " +
        $"\"{nameof(PatientModel.IsActive)}\" " +
        $"FROM \"AspNetUsers\"" +
           $"WHERE " +
           $"\"TherapistId\" = @Key ";




        public static string QuerryGetPersonalDetails() =>
     $"SELECT " +
     $"\"{nameof(UserPersonalDetailModel.Email)}\", " +
     $"\"{nameof(UserPersonalDetailModel.PhoneNumber)}\", " +
     $"\"{nameof(UserPersonalDetailModel.Street)}\", " +
     $"\"{nameof(UserPersonalDetailModel.HouseNbr)}\", " +
     $"\"{nameof(UserPersonalDetailModel.PostalCode)}\", " +
     $"\"{nameof(UserPersonalDetailModel.City)}\"" +
     $"FROM \"AspNetUsers\"" ;



    public static string QuerryGetUserPersonalDetails() =>
       $"{QuerryGetPersonalDetails()} " +
       $"WHERE " +
       $"\"{nameof(UserPersonalDetailModel.Id)}\" = @Key "+
       $"LIMIT 1;";


        public static string QuerryUpdateUserPersonalDetails() =>
            $"UPDATE \"AspNetUsers\" " +
            $"SET " +
            $"\"{nameof(UserPersonalDetailModel.Email)}\" = @{nameof(UserPersonalDetailModel.Email)}, " +
             $"\"{nameof(UserPersonalDetailModel.PhoneNumber)}\" = @{nameof(UserPersonalDetailModel.PhoneNumber)}, " +
             $"\"{nameof(UserPersonalDetailModel.Street)}\" = @{nameof(UserPersonalDetailModel.Street)}, " +
             $"\"{nameof(UserPersonalDetailModel.HouseNbr)}\" = @{nameof(UserPersonalDetailModel.HouseNbr)}, " +
             $"\"{nameof(UserPersonalDetailModel.PostalCode)}\" = @{nameof(UserPersonalDetailModel.PostalCode)}, " +
             $"\"{nameof(UserPersonalDetailModel.City)}\" = @{nameof(UserPersonalDetailModel.City)} " +
            $"WHERE  " +
            $"\"{nameof(UserPersonalDetailModel.Id)}\" = @{nameof(UserPersonalDetailModel.Id)} ";




    }
}
