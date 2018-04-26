using System;
using System.Collections.Generic;

namespace CalculatorSource
{
    public static class Calculator
    {
        private sealed class ArithmeticOperators : Dictionary<string, Func<double, double, double>> { }
        private static ArithmeticOperators _operators = new ArithmeticOperators()
        {
            ["+"] = (double x, double y) => x + y,
            ["-"] = (double x, double y) => x - y,
            ["*"] = (double x, double y) => x * y,
            ["/"] = (double x, double y) => x / y,
        };

        private static Dictionary<string, int> _priorityOfOperators = new Dictionary<string, int>()
        {
            ["+"] = 1,
            ["-"] = 1,
            ["*"] = 2,
            ["/"] = 2,
        };

        public static double Evaluate(string expression)
        {
            throw new NotImplementedException();
        }

        private static LinkedList<string> SortingStation(string[] tokens)
        {
            var postfixNotation = new LinkedList<string>();
            var stack = new Stack<string>();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double value))
                {
                    postfixNotation.AddLast(token);
                }
                else if (_operators.ContainsKey(token))
                {
                    while (stack.Count > 0 && _priorityOfOperators[token] <= _priorityOfOperators[stack.Peek()])
                    {
                        postfixNotation.AddLast(stack.Pop());
                    }

                    stack.Push(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        postfixNotation.AddLast(stack.Pop());
                    }

                    stack.Pop();
                }
                else
                {
                    continue;
                }
            }

            while (stack.Count > 0)
            {
                postfixNotation.AddLast(stack.Pop());
            }

            return postfixNotation;
        }
    }
}
