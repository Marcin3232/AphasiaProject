using DataBaseProject.Models.Exercise;
using DataBaseProject.Models.ExerciseHistory;
using DataBaseProject.Models.ExerciseResultHistory;
using DataBaseProject.Models.UserExercise;
using Microsoft.EntityFrameworkCore;

namespace DataBaseProject.Context;

public class ExerciseDbContext : DbContext, IExerciseDbContext
{
    public ExerciseDbContext()
    {
    }

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
    public DbSet<AphasiaModel> Aphasia { get; set; }
    public DbSet<ExerciseHistoryModel> ExerciseHistories { get; set; }
    public DbSet<HistoryResultDetailsModel> HistoryResultDetails { get; set; }
    public DbSet<UserAphasiaModel> UserAphasias { get; set; }
    public DbSet<UserExerciseModel> UserExercises { get; set; }
    public DbSet<UserPhaseExerciseModel> PhaseExercises { get; set; }
    public DbSet<ExerciseResultHistory> ExerciseResultHistories { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql("Server=157.158.62.62;Port=5432;Database=marcopi308;User Id=marcopi308;Password=marcopi308;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseModel>();

    }
}
