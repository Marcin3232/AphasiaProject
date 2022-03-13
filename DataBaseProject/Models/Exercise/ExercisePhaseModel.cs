using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.Exercise
{
    [Table("ExercisePhase")]
    public class ExercisePhaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public ExercisePhaseNameModel PhaseName { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        [Required]
        public ExerciseKindModel ExerciseKind { get; set; }
        [Required]
        public ExerciseTypeModel ExerciseType { get; set; }
        public bool IsActive { get; set; }
    }
}
