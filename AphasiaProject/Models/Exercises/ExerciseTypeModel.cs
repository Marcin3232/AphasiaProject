using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AphasiaProject.Models.Exercises
{
    [Table("ExerciseType")]
    public class ExerciseTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public ExerciseTypeNameModel ExerciseTypeName { get; set; }
    }
}
