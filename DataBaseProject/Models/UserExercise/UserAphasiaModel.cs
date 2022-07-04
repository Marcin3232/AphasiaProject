using DataBaseProject.Models.Exercise;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.UserExercise;

[Table("UserAphasia")]
public class UserAphasiaModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int IdUser { get; set; }
    [Required]
    public AphasiaModel Aphasia { get; set; }
    public bool IsActive { get; set; }
}

