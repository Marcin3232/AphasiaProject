using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExercise.Utils
{
    public class MultiplierDictionary
    {
        public static Dictionary<int, T> Multiply<T>(object value, int repeat)
        {
            if (repeat == 1)
                return new Dictionary<int, T>() { { repeat, (T)value } };
            var tempDict = new Dictionary<int, T>();
            for (int i = 0; i < repeat; i++)
            {
                tempDict.Add(i, (T)value);
            }
            return tempDict;
        }
    }
}
