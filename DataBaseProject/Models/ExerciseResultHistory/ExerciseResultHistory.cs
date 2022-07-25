using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.ExerciseResultHistory;

[Table("ExerciseResultHistory")]
public class ExerciseResultHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("Key", TypeName = "text")]
    [Required]
    public string Key { get; set; } = string.Empty;
    [Column("JsonValue", TypeName = "text")]
    [Required]
    public string JsonValue { get; set; } = string.Empty;
    [Required]
    public DateTime CreateTime { get; set; }

}

