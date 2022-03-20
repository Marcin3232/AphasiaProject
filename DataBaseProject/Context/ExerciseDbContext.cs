using DataBaseProject.Models.Exercise;
using DataBaseProject.Models.ExerciseHistory;
using Microsoft.EntityFrameworkCore;

namespace DataBaseProject.Context
{
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql("Server=localhost;Port=5400;Database=Aphasia;User Id=postgres;Password=niewiem123456789;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseModel>();
            //modelBuilder.Entity<ExercisePhaseNameModel>().HasData(ExercisePhaseNameFill.GetFilled());
            //modelBuilder.Entity<ExerciseKindNameModel>().HasData(ExerciseKindNameFill.GetFilled());
            ////    modelBuilder.Entity<ExerciseTypeNameFill>().HasData(ExerciseTypeNameFill.GetFilled());
            ////    modelBuilder.Entity<ExerciseTypeFill>().HasData(ExerciseTypeFill.GetFilled());
            //modelBuilder.Entity<ExerciseNameModel>().HasData(ExerciseNameFillList.ExerciseNameList());
        }
    }
}
