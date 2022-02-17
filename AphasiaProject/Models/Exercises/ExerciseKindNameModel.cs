using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AphasiaProject.Models.Exercises
{
    [Table("ExerciseKindName")]
    public class ExerciseKindNameModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Kind { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
