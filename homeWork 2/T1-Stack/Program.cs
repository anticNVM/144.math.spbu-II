using System;

namespace T1_Stack
{
    class Program
    {
        public static void Main(string[] args)
        {
            StackTest();
        }

        private static void StackTest()
        {
            var stack = new Stack();
            var rand = new Random();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine($"Count = {stack.Count}");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine($"Count = {stack.Count}");
            Console.WriteLine(stack.Pop());

            stack.Push(rand.Next(10));
            stack.Push(rand.Next(10));            
            stack.Push(rand.Next(10));
            Console.WriteLine($"Count = {stack.Count}");
            stack.Clear();
            Console.WriteLine($"Count = {stack.Count}");
        }
    }
}
