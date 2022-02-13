using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AphasiaProject.Models.Exercises
{
    [Table("ExerciseKind")]
    public class ExerciseKindModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public ExerciseKindNameModel ExerciseKindName { get; set; }
        [Required]
        public ExerciseTypeModel ExerciseType { get; set; }
    }
}
