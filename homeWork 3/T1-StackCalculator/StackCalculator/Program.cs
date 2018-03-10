using System;

namespace StackCalculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            ICalculator calc;

            int type = GetStackType();
            switch (type)
            {
                case (int)StackTypes.LinkedStack:
                    calc = new StackCalc(new LinkedStack());
                    break;
                case (int)StackTypes.ArrayStack:
                    calc = new StackCalc(new ArrayStack());
                    break;
                default:
                    calc = null;
                    break;
            }

            Console.Write("\nВведите выражение в постфиксной форме для вычисления");
            Console.Write(" (операнды должны разделяться пробелом)\n>>> ");
            var expression = Console.ReadLine();
            try
            {
                var result = calc.Calculate(expression);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exceptions.InvalidExpressionException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.StackTrace);
                // если throw вместо return, то unhandled exception
                return;
            }
        }

        private static int GetStackType()
        {
            Console.WriteLine("Введите тип используемого стека: ");
            Console.Write("  0 - стек на указателях\n  1 - стек на массиве\n>>> ");
            var input = Console.ReadLine();
            int type;
            while (!(int.TryParse(input, out type) && (type == 0 || type == 1)))
            {
                Console.Write("Пожалуйста, введите корректное значение: ");
                input = Console.ReadLine();
            }

            return type;
        }

        private enum StackTypes
        {
            LinkedStack, ArrayStack
        }
    }
}
