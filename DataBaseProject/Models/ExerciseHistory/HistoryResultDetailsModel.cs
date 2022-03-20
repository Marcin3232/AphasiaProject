using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Models.ExerciseHistory
{
    [Table("HistoryResultDetails")]
    public class HistoryResultDetailsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Answers { get; set; }
        public int CorrectAnswers { get; set; }
        public int CorrectClicks { get; set; }
        public int WrongClicks { get; set; }
        public int TipClicks { get; set; }
    }
}
