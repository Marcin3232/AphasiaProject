using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.Exercise
{
    [Table("Exercise")]
    public class ExerciseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("IdExerciseName", TypeName = "int")]
        public ExerciseNameModel ExerciseName { get; set; }
        [Required]
        public int IdUser { get; set; }
        public bool IsActive { get; set; }
        public AphasiaModel? Aphasia { get; set; }
        public int Order { get; set; }
    }
}
