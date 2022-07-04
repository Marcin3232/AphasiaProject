using DataBaseProject.Models.Exercise;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DataBaseProject.Models.UserExercise;

[Table("UserPhaseExercise")]
public class UserPhaseExerciseModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required, NotNull]
    public ExercisePhaseModel ExercisePhase { get; set; }
    [Required, NotNull]
    public UserExerciseModel UserExercise { get; set; }
    public bool IsActive { get; set; } = false;
}

