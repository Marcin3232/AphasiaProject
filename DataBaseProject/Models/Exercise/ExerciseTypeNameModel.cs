using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.Exercise
{
    [Table("ExerciseTypeName")]
    public class ExerciseTypeNameModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
