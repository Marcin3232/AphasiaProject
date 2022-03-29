using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonExercise.Utils
{
    public static class Randomizer
    {
        private static Random r = new Random();

        public static List<T> Shuffle<T>(this List<T> input) =>
            input.OrderBy(_ => r.Next()).ToList();

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> input) =>
            input.OrderBy(_ => r.Next());
    }
}
