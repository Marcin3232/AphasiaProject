using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.Exercise
{
    [Table("ExerciseType")]
    public class ExerciseTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ExerciseTypeNameModel ExerciseTypeName { get; set; }
    }
}
