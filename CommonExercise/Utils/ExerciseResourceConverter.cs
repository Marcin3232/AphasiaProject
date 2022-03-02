using CommonExercise.Models.ExerciseResource;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;

namespace CommonExercise.Utils
{
    public class ExerciseResourceConverter
    {
        public static dynamic ExerciseResource<T>(JsonElement value) =>
             JsonConvert.DeserializeObject<List<T>>(value.GetRawText());
    }
}
