using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Models
{
    public class HistoryResultDetails
    {
        public int Id { get; set; }
        public int Answers { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongClicks { get; set; }
        public int TipClicks { get; set; }
    }
}
