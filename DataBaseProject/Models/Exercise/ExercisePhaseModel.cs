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
        public ExercisePhaseNameModel PhaseName { get; set; }
        public int ExerciseId { get; set; }
        public ExerciseKindModel ExerciseKind { get; set; }
        public ExerciseTypeModel ExerciseType { get; set; }
        public bool IsActive { get; set; }
        public int Repeat { get; set; } = 1;
        public bool IsSoundEveryStep { get; set; } = false;
        public bool IsHelper { get; set; } = false;
    }
}
