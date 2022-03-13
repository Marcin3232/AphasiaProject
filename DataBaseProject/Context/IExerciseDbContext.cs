using DataBaseProject.Models.Exercise;
using Microsoft.EntityFrameworkCore;

namespace DataBaseProject.Context
{
    public interface IExerciseDbContext
    {
        DbSet<ExerciseKindModel> ExerciseKind { get; set; }
        DbSet<ExerciseKindNameModel> ExerciseKindNames { get; set; }
        DbSet<ExerciseNameModel> ExerciseNames { get; set; }
        DbSet<ExercisePhaseModel> ExercisePhase { get; set; }
        DbSet<ExercisePhaseNameModel> ExercisePhaseNames { get; set; }
        DbSet<ExerciseModel> Exercises { get; set; }
        DbSet<ExerciseTypeModel> ExerciseType { get; set; }
        DbSet<ExerciseTypeNameModel> ExerciseTypeNames { get; set; }
    }
}