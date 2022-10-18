

using DataBaseProject.Models.Exercise;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.UserExercise;

[Table("UserExercise")]
public class UserExerciseModel
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public ExerciseModel Exercise { get; set; }
    [Required]
    public UserAphasiaModel UserAphasia { get; set; }
    public bool IsActive { get; set; } = false;
    public int Order { get; set; } = 0;
}

