using AphasiaProject.Models.Exercises;
using AphasiaProject.Utils;
using Microsoft.EntityFrameworkCore;

namespace AphasiaProject.Models.DB.Exercises
{
    public class ExerciseDbContext : DbContext
    {
        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options):base(options)
        {
        }

        public DbSet<ExerciseNameModel> ExerciseNames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ExerciseNameModel>().HasData(ExerciseNameFillList.ExerciseNameList());
        }
    }
}
