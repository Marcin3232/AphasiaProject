using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AphasiaProject.Models.Exercises
{
    [Table("Exercise")]
    public class ExerciseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("IdExerciseName", TypeName = "int")]
        public ExerciseNameModel ExerciseName { get; set; }
        [Required, Index(IsUnique = true)]
        public int IdUser { get; set; }
        public bool IsActive { get; set; }
    }
}
