using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AphasiaProject.Models.Exercises
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
        public int KindId { get; set; }        
        public bool IsActive { get; set; }
    }
}
