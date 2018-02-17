using System;

namespace T2_Fibonacci
{
    // Посчитать числа Фибоначчи
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите порядковый номер искомого числа Фибоначчи [F(1) = 1] : ");
            var number = Convert.ToInt32(Console.ReadLine());
            var fibNumber = Fibonacci(number);
            Console.WriteLine($"Fibonacci({number}) = {fibNumber}");
        }

        public static int Fibonacci(int number)
        {
            int[] fibNums = new int[2] {0, 1};
            for (var i = 1; i < Math.Abs(number); ++i)
            {
                var previous = fibNums[1];
                fibNums[1] = fibNums[0] + fibNums[1];
                fibNums[0] = previous;
            }

            return number >= 0 ? fibNums[1] : fibNums[1] * Convert.ToInt32(Math.Pow(-1, number + 1));
        }
    }
}
