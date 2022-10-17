using CommonExercise.Models.User;
using DataBaseQuery.ModelHelper;
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


        public static string QuerryGetExercisesForUser()=>
         $"SELECT " +
        $"ue.\"{nameof(UserExerciseModel.Id)}\", " +
        $"ue.\"{nameof(UserExerciseModel.ExerciseId)}\" " +
        $"FROM \"UserExercise\" as ue JOIN \"UserAphasia\" as ua on ue.\"{nameof(UserExerciseModel.UserAphasiaId)}\" = ua.\"{nameof(UserAphasiaModel.Id)}\"" +
           $"WHERE " +
           $"ua.\"IdUser\" = @Key ";



        public static string QueryInsertUserExercises() =>
        $"INSERT INTO \"UserExercise\" (" +
        $"\"{nameof(UserExerciseModel.ExerciseId)}\", " +
        $"\"{nameof(UserExerciseModel.UserAphasiaId)}\", " +
        $"\"{nameof(UserExerciseModel.IsActive)}\") " +
        $"VALUES (" +
        $"@{nameof(UserExerciseModel.ExerciseId)}, " +
        $"@{nameof(UserExerciseModel.UserAphasiaId)}, " +
        $"@{nameof(UserExerciseModel.IsActive)}); ";



        public static string QuerryGetPhaseData() =>
$"SELECT " +
$"\"{nameof(ExercisePhaseModel.Id)}\", " +
$"\"{nameof(ExercisePhaseModel.ExerciseId)}\" " +
$"FROM \"ExercisePhase\"";



        public static string QueryInsertUserPhases() =>
      $"INSERT INTO \"UserPhaseExercise\" (" +
      $"\"{nameof(UserPhaseModel.ExercisePhaseId)}\", " +
      $"\"{nameof(UserPhaseModel.UserExerciseId)}\", " +
      $"\"{nameof(UserPhaseModel.IsActive)}\") " +
      $"VALUES (" +
      $"@{nameof(UserPhaseModel.ExercisePhaseId)}, " +
      $"@{nameof(UserPhaseModel.UserExerciseId)}, " +
      $"@{nameof(UserPhaseModel.IsActive)}); ";


        public static string QuerryGetPersonalDetails() =>
     $"SELECT " +
     $"\"{nameof(UserPersonalDetailModel.Email)}\", " +
     $"\"{nameof(UserPersonalDetailModel.PhoneNumber)}\", " +
     $"\"{nameof(UserPersonalDetailModel.Street)}\", " +
     $"\"{nameof(UserPersonalDetailModel.HouseNbr)}\", " +
     $"\"{nameof(UserPersonalDetailModel.PostalCode)}\", " +
     $"\"{nameof(UserPersonalDetailModel.City)}\"" +
     $"FROM \"AspNetUsers\"";


        public static string QuerryGetExcercises() =>
   $"SELECT " +
   $"\"{nameof(ExerciseModelHelper.Id)}\", " +
   $"\"{nameof(ExerciseModelHelper.ExerciseNameId)}\", " +
   $"\"{nameof(ExerciseModelHelper.Id)}\", " +
   $"\"{nameof(ExerciseModelHelper.IsActive)}\", " +
   $"\"{nameof(ExerciseModelHelper.AphasiaId)}\", " +
   $"\"{nameof(ExerciseModelHelper.Order)}\"" +
   $"FROM \"Exercise\"";



        public static string QueryGetUserAphasia() =>
$"SELECT " +
$"\"{nameof(UserAphasiaModel.Id)}\", " +
$"\"{nameof(UserAphasiaModel.IdUser)}\", " +
$"\"{nameof(UserAphasiaModel.AphasiaId)}\", " +
$"\"{nameof(UserAphasiaModel.IsActive)}\" " +
$"FROM \"UserAphasia\"" + $"WHERE " +
           $"\"IdUser\" = @Key ";

        public static string QuerryGetUserPersonalDetails() =>
       $"{QuerryGetPersonalDetails()} " +
       $"WHERE " +
       $"\"{nameof(UserPersonalDetailModel.Id)}\" = @Key " +
       $"LIMIT 1;";




        public static string QueryInsertAphasiaTypes() =>
        $"INSERT INTO \"UserAphasia\" (" +
        $"\"{nameof(UserCreateAphasiaModel.IdUser)}\", " +
        $"\"{nameof(UserCreateAphasiaModel.AphasiaId)}\", " +
        $"\"{nameof(UserCreateAphasiaModel.IsActive)}\") " +
        $"VALUES (" +
        $"@{nameof(UserCreateAphasiaModel.IdUser)}, " +
        $"@{nameof(UserCreateAphasiaModel.AphasiaId)}, " +
        $"@{nameof(UserCreateAphasiaModel.IsActive)}); ";



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
