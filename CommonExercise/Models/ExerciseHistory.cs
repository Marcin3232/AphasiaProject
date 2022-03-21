using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Models
{
    public class ExerciseHistory
    {
        public int Id { get;set; }
        public int ExerciseId { get; set; }
        public int ExercisePhaseId { get; set; }
        public HistoryResultDetails HistoryResultDetails { get; set; }
        public long? ExecutionTime => Timer?.ElapsedMilliseconds;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Stopwatch Timer  { get; set; }
    }
}
