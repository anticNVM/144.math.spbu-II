using System;

namespace T1_factorial
{
    // Посчитать факториал
    class Program
    {
        static void Main(string[] args)
        {
            var input = CorrectInput();
            Console.WriteLine($"{input}! = {Factorial(input)}");
        }

        public static int Factorial(int stage)
        {
            if (stage == 0) 
                return 1;

            return stage * Factorial(stage - 1);
        }

        public static int CorrectInput()
        {
            Console.Write("Введите натуральное число для вычисления факториала: ");
            var input = Convert.ToInt32(Console.ReadLine());
            while (input < 0)
            {
                Console.WriteLine("Факториал определён только для натуральных числел.");
                Console.Write("Пожалуйста, введите корректное значение: ");
                input = Convert.ToInt32(Console.ReadLine());
            }
            return input;
        }
    }
}
