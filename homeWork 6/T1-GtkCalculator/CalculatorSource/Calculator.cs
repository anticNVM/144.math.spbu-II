﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            ["("] = 0,
            ["+"] = 1,
            ["-"] = 1,
            ["*"] = 2,
            ["/"] = 2,
        };

        public static double Evaluate(string expression)
        {
            expression = expression.Replace(" ", string.Empty);
            var tokens = ParseExpression(expression);
            var posfix = SortingStation(tokens);
            var result = Calculate(posfix);

            return result;
        }

        private static LinkedList<string> SortingStation(LinkedList<string> tokens)
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
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        postfixNotation.AddLast(stack.Pop());
                    }

                    if (stack.Count == 0)
                    {
                        throw new Exceptions.InvalidExpressionException(
                            "В выражении пропущена открывающаяя скобка");
                    }

                    stack.Pop();
                }
                else
                {
                    throw new Exceptions.InvalidExpressionException("Неподдерживаемый символ");
                }
            }

            while (stack.Count > 0)
            {
                if (stack.Peek() == "(")
                {
                    throw new Exceptions.InvalidExpressionException(
                        "В выражении пропущена закрывающая скобка");
                }

                postfixNotation.AddLast(stack.Pop());
            }

            return postfixNotation;
        }

        private static double Calculate(LinkedList<string> tokens)
        {
            var stack = new Stack<double>();

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double value))
                {
                    stack.Push(value);
                }
                else
                {
                    try
                    {
                        var rightOperand = stack.Pop();
                        double res = _operators[token](stack.Pop(),rightOperand);
                        stack.Push(res);
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new Exceptions.InvalidExpressionException(
                            "Неверное число операндов (меньше необходимого)", e);
                    }
                    catch (DivideByZeroException e)
                    {
                        throw new Exceptions.InvalidExpressionException(
                            "Деление на ноль", e);
                    }
                }
            }

            // значит, что ввели пустую строку
            if (stack.Count == 0)
            {
                return 0;
            }

            double result = stack.Pop();
            if (stack.Count > 0)
            {
                throw new Exceptions.InvalidExpressionException(
                    "Неверное число операндов (больше необходимого)");
            }

            return result;
        }

        private static LinkedList<string> ParseExpression(string expression)
        {
            var tokens = new LinkedList<string>();
            var length = expression.Length;
            string num = "";

            var i = 0;
            while (i < length)
            {
                if (char.IsDigit(expression[i]))
                {
                    while (i < length && char.IsDigit(expression[i]))
                    {
                        num += expression[i];
                        i++;
                    }

                    tokens.AddLast(num);
                    num = string.Empty;
                }
                else
                {
                    tokens.AddLast(char.ToString(expression[i]));
                    i++;
                }
            }

            return tokens;
        }
    }
}