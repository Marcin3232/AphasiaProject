using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.ExerciseHistory
{
    [Table("ExerciseHistory")]
    public class ExerciseHistoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ExercisePhaseId { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        public List<HistoryResultDetailsModel> HistoryResultDetails { get; set; }
        public long? ExecutionTime { get;set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
