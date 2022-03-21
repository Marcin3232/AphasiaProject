using System.Collections.Generic;

namespace CommonExercise.Utils
{
    public class MultiplierList
    {
        public static List<T> Multiply<T>(object list, int repeat)
        {
            if (repeat == 1)
                return (List<T>)list;

            var tempList = new List<T>();

            for (int i = 0; i < repeat; i++)
                tempList.AddRange((List<T>)list);

            return tempList;
        }
    }
}
