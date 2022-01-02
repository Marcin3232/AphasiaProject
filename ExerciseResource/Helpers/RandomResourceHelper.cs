using System;
using System.Collections.Generic;

namespace ExerciseResource.Helpers
{
    public static class RandomResourceHelper
    {
        private static Random randomObject = new Random();

        public static string GetRandomPicturePath(string[] pictureScrs)
        {
            int pictureCount = pictureScrs.Length;
            var randomPicturePath = pictureScrs[randomObject.Next(pictureCount)];

            return randomPicturePath;
        }

        public static List<T> GetRandomValues<T>(List<T> resourceList) where T : struct
        {
            List<T> values = new List<T>();
            List<T> resourceListCopy = new List<T>(resourceList);

            int resourceCount = resourceList.Count;
            for (int i = 0; i < resourceCount; i++)
            {
                var randomIndex = randomObject.Next(resourceListCopy.Count);

                var randomResource = resourceListCopy[randomIndex];
                resourceListCopy.RemoveAt(randomIndex);

                values.Add(randomResource);
            }

            return values;
        }

        public static List<T> GetRandomValues<T>(List<T> resourceList, out int[] randomIndexes) where T : struct
        {
            List<T> values = new List<T>();
            List<T> resourceListCopy = new List<T>(resourceList);

            int resourceCount = resourceList.Count;
            randomIndexes = new int[resourceCount];

            for (int i = 0; i < resourceCount; i++)
            {
                var randomIndex = randomObject.Next(resourceListCopy.Count);

                var randomResource = resourceListCopy[randomIndex];
                resourceListCopy.RemoveAt(randomIndex);

                values.Add(randomResource);
                randomIndexes[i] = randomIndex;
            }

            return values;
        }
    }
}
