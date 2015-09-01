using System;
using System.Collections.Generic;

namespace ClassesL5
{
    public static class CollectionsHelper
    {
        public static void PrintToConsole<T>(this IEnumerable<T> list) where T : class
        {
            foreach (var x in list)
            {
                Console.WriteLine(x);
            }
        }
    }
}