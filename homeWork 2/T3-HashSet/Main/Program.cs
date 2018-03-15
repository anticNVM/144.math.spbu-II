using System;
using HashSetSource;
using System.Collections.Generic;

namespace Main
{
    static class Program
    {
        private static void Main(string[] args)
        {
            var ListOfHashes = new Dictionary<string, Func<int, int>>() {
                // число по абсолютному значению
                { "positive", num => Math.Abs(num) },

                // квадрат числа
                { "square", num => (int)Math.Pow(num, 2) },

                // куб числа
                { "cube", num => Math.Abs((int)Math.Pow(num, 3)) },

                // дополнение до числа
                { "supplement", num => int.MaxValue - Math.Abs(num) },
            };

            
        }
    }
}
