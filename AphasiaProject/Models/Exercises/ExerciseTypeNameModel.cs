using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AphasiaProject.Models.Exercises
{
    [Table("ExerciseTypeName")]
    public class ExerciseTypeNameModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public string Name { get; set; }
        public  string Description { get; set; }
    }
}
