using DataBaseProject.Models.Exercise;
using Microsoft.EntityFrameworkCore;

namespace DataBaseProject.Context
{
    public class ExerciseDbContext : DbContext, IExerciseDbContext
    {
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options) : base(options)
        {
        }

        public DbSet<ExerciseModel> Exercises { get; set; }
        public DbSet<ExerciseNameModel> ExerciseNames { get; set; }
        public DbSet<ExercisePhaseModel> ExercisePhase { get; set; }
        public DbSet<ExercisePhaseNameModel> ExercisePhaseNames { get; set; }
        public DbSet<ExerciseKindModel> ExerciseKind { get; set; }
        public DbSet<ExerciseKindNameModel> ExerciseKindNames { get; set; }
        public DbSet<ExerciseTypeModel> ExerciseType { get; set; }
        public DbSet<ExerciseTypeNameModel> ExerciseTypeNames { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ExerciseModel>();
            //modelBuilder.Entity<ExercisePhaseNameModel>().HasData(ExercisePhaseNameFill.GetFilled());
            //modelBuilder.Entity<ExerciseKindNameModel>().HasData(ExerciseKindNameFill.GetFilled());
            ////    modelBuilder.Entity<ExerciseTypeNameFill>().HasData(ExerciseTypeNameFill.GetFilled());
            ////    modelBuilder.Entity<ExerciseTypeFill>().HasData(ExerciseTypeFill.GetFilled());
            //modelBuilder.Entity<ExerciseNameModel>().HasData(ExerciseNameFillList.ExerciseNameList());
        }
    }
}
