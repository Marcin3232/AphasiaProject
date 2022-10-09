 using CommonExercise.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CommonExercise.ExerciseHistoryManager
{
    public class HistoryManager
    {
        public static List<ExerciseHistory> Initialize(Exercise exercise)
        {
            var tempList = new List<ExerciseHistory>();
            exercise.Phases.ForEach(ph => tempList.Add(Create(ph)));
            return tempList;
        }

        public static void Start(List<ExerciseHistory> history, ExercisePhase phase)
        {
            var temp = history.FirstOrDefault(x => x.ExercisePhaseId == phase.Id);
            temp.StartDate = temp.StartDate == null ? DateTime.Now : temp.StartDate;
            temp.Timer.Start();
        }


        public static void End(List<ExerciseHistory> history, ExercisePhase phase)
        {
            var temp = history.FirstOrDefault(x => x.ExercisePhaseId == phase.Id);
            temp.EndDate = DateTime.Now;
            temp.Timer.Stop();
        }


        private static ExerciseHistory Create(ExercisePhase exercisePhase) => new ExerciseHistory()
        {
            ExerciseId = exercisePhase.ExerciseId,
            ExercisePhaseId = exercisePhase.Id,
            HistoryResultDetails = new HistoryResultDetails(),
            StartDate = null,
            EndDate = null,
            Timer = new Stopwatch()

        };
    }
}
