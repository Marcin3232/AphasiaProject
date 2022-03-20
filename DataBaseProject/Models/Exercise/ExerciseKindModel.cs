using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.Exercise
{
    [Table("ExerciseKind")]
    public class ExerciseKindModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ExerciseKindNameModel ExerciseKindName { get; set; }
    }
}
