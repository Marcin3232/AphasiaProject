using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.Exercise
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
        public string SoundSrc { get; set; }
    }
}
