using System;
using System.Collections.Generic;

namespace PrimeGeneratorSource
{
    public static class PrimeGenerator
    {
        public static IEnumerable<int> Generate()
        {
            return Filter<int>(GenerateInts(), IsPrime);
        }

        public static IEnumerable<int> GenerateInts()
        {
            int current = 0;
            while (true)
            {
                yield return current++;
            }
        }

        private static IEnumerable<T> Filter<T>(IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        private static bool IsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }

            var i = 2;
            while (i * i <= number)
            {
                if (number % i == 0)
                {
                    return false;
                }

                i++;
            }

            return true;
        }
    }
}
