
using CommonExercise.Models;
using CommonExercise.Models.User.Management;

namespace DataBaseQuery.Exercise
{
    public class ExerciseQuery
    {


        public static string QuerySelectExNames() =>
            "select ue.\"Id\" as ExerciseId,en.\"Description\" ,en.\"Id\" ,en.\"IdExerciseTask\" ,en.\"ImageSrc\" ,en.\"Name\" from \"UserAphasia\" ua " +
            "join \"UserExercise\" ue on ua.\"Id\" = ue.\"UserAphasiaId\" " +
            "join \"Exercise\" e on ue.\"ExerciseId\" = e.\"Id\" " +
            "join \"ExerciseName\" en on e.\"ExerciseNameId\" = en.\"Id\" " +
            "join \"Aphasia\" a2 on ua.\"AphasiaId\" = a2.\"Id\" " +
            "where ua.\"IdUser\" = @key and a2.\"Id\" = @key2 and ue.\"IsActive\" = false order by ue.\"Order\" asc";


        public static string QuerySelectPhaseExerciseResponse() =>
            $"SELECT " +
            $"ep.\"ExerciseId\" as ExerciseId, " +
            $"ep.\"Id\" as Id, " +
            $"ep.\"PhaseNameId\" as PhaseNameId, " +
            $"ep.\"IsActive\" as IsActive, " +
            $"epn.\"Name\" as Name, " +
            $"ek.\"Id\" as KindId, " +
            $"ekn.\"Name\" as KindName, " +
            $"ekn.\"Description\" as KindDescription, " +
            $"ekn.\"Kind\" as Kind, " +
            $"et.\"Id\" as TypeId, " +
            $"etn.\"Name\" as TypeName, " +
            $"etn.\"Description\" as TypeDescription, " +
            $"etn.\"Type\" as Type, " +
            $"epn.\"Description\" as PhaseDescription, " +
            $"ekn.\"SoundSrc\" as SoundSrc, " +
            $"ep.\"Repeat\" as Repeat, " +
            $"ep.\"IsSoundEveryStep\" as IsSoundEveryStep, " +
            $"ep.\"IsHelper\" as IsHelper  " +
            $"FROM \"ExercisePhase\" as ep " +
            $"JOIN \"ExercisePhaseName\" as epn on epn.\"Id\" = ep.\"PhaseNameId\" " +
            $"JOIN \"ExerciseKind\" as ek on  ek.\"Id\" = ep.\"ExerciseKindId\" " +
            $"JOIN \"ExerciseKindName\" as ekn on ekn.\"Id\" = ek.\"ExerciseKindNameId\" " +
            $"JOIN \"ExerciseType\" as et on et.\"Id\" = ep.\"ExerciseTypeId\" " +
            $"JOIN \"ExerciseTypeName\" as etn on etn.\"Id\" = et.\"ExerciseTypeNameId\" ";



        public static string QuerySelectPhaseExerciseResponseExercise() =>
            $"SELECT " +
            $"ep.\"ExerciseId\" as ExerciseId, " +
            $"ep.\"Id\" as Id, " +
            $"ep.\"PhaseNameId\" as PhaseNameId, " +
            $"upe.\"IsActive\" as IsActive, " +
            $"epn.\"Name\" as Name, " +
            $"ek.\"Id\" as KindId, " +
            $"ekn.\"Name\" as KindName, " +
            $"ekn.\"Description\" as KindDescription, " +
            $"ekn.\"Kind\" as Kind, " +
            $"et.\"Id\" as TypeId, " +
            $"etn.\"Name\" as TypeName, " +
            $"etn.\"Description\" as TypeDescription, " +
            $"etn.\"Type\" as Type, " +
            $"epn.\"Description\" as PhaseDescription, " +
            $"ekn.\"SoundSrc\" as SoundSrc, " +
            $"ep.\"Repeat\" as Repeat, " +
            $"ep.\"IsSoundEveryStep\" as IsSoundEveryStep, " +
            $"ep.\"IsHelper\" as IsHelper  " +
            $"FROM \"UserExercise\" as ue " +
            $"JOIN \"UserPhaseExercise\" as upe on ue.\"Id\" = upe.\"UserExerciseId\" " +
            $"JOIN \"ExercisePhase\" as ep on  upe.\"ExercisePhaseId\" = ep.\"Id\" " +
            $"JOIN \"ExercisePhaseName\" as epn on epn.\"Id\" = ep.\"PhaseNameId\" " +
            $"JOIN \"ExerciseKind\" as ek on  ek.\"Id\" = ep.\"ExerciseKindId\" " +
            $"JOIN \"ExerciseKindName\" as ekn on ekn.\"Id\" = ek.\"ExerciseKindNameId\" " +
            $"JOIN \"ExerciseType\" as et on et.\"Id\" = ep.\"ExerciseTypeId\" " +
            $"JOIN \"ExerciseTypeName\" as etn on etn.\"Id\" = et.\"ExerciseTypeNameId\" ";






        public static string QuerySelectExerciseInformationResponseExercise() =>
            $"SELECT " +
            $"ue.\"Id\" as ExerciseId, " +
            $"e.\"ExerciseNameId\" as ExerciseNameId, " +
            $"ua.\"IdUser\" as UserId, " +
            $"e.\"IsActive\" as IsActive, " +
            $"en.\"Name\" as Name, " +
            $"en.\"Description\" as Description, " +
            $"en.\"ImageSrc\" as ImageSrc, " +
            $"en.\"IdExerciseTask\" as ExerciseTaskId " +
            $"FROM \"Exercise\" as e " +
            $"JOIN \"ExerciseName\" as en on en.\"Id\" = e.\"ExerciseNameId\" " +
            $"JOIN \"UserExercise\" as ue on ue.\"ExerciseId\" = e.\"Id\" " + 
            $"JOIN \"UserAphasia\" as ua on ue.\"UserAphasiaId\" = ua.\"Id\" ";






















        public static string QuerySelectExerciseInformationResponse() =>
            $"SELECT " +
            $"e.\"Id\" as ExerciseId, " +
            $"e.\"ExerciseNameId\" as ExerciseNameId, " +
            $"e.\"IdUser\" as UserId, " +
            $"e.\"IsActive\" as IsActive, " +
            $"en.\"Name\" as Name, " +
            $"en.\"Description\" as Description, " +
            $"en.\"ImageSrc\" as ImageSrc, " +
            $"en.\"IdExerciseTask\" as ExerciseTaskId " +
            $"FROM \"Exercise\" as e " +
            $"JOIN \"ExerciseName\" as en on en.\"Id\" = e.\"ExerciseNameId\" ";
        public static string UserExerciseInsert() =>
        $"UPDATE \"UserExercise\" " +
            $"SET " +
             $"\"IsActive\" = @{nameof(ExcerciseCartManagementModel.Disabled)}, " +
             $"\"Order\" = @{nameof(ExcerciseCartManagementModel.order)} " +
            $"WHERE  " +
            $"\"{nameof(ExcerciseCartManagementModel.Id)}\" = @{nameof(ExcerciseCartManagementModel.Id)}";

        public static string GetUserExercisePhases() =>
            " select upe.\"Id\" ,epn.\"Description\",epn.\"Name\",upe.\"IsActive\"  from \"UserPhaseExercise\" upe " +
            "join \"ExercisePhase\" ep on upe.\"ExercisePhaseId\" = ep.\"Id\"  " +
            "join \"ExercisePhaseName\" epn on ep.\"PhaseNameId\" = epn.\"Id\"  " +
            "where upe.\"UserExerciseId\" = @Key " +
            "order by upe.\"Id\" asc";


        public static string UserPhaseUpdate() =>
       $"UPDATE \"UserPhaseExercise\" " +
           $"SET " +
            $"\"IsActive\" = @{nameof(UserPhaseSaveModel.IsActive)} " +
           $"WHERE  " +
           $"\"Id\" = @{nameof(UserPhaseSaveModel.PhaseId)}";
    }
}
