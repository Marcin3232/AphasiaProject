using System;

namespace AphasiaClientApp.Services.ExerciseResultHistoryServices
{
    public class ExerciseResultHistory
    {
        public int Id { get; internal set; }
        public string Key { get; internal set; }
        public string JsonValue { get; internal set; }
        public DateTime CreateTime { get; internal set; }
    }
}