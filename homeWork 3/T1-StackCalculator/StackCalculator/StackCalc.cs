using System;
using Exceptions;

namespace StackCalculator
{
    public class StackCalc : ICalculator
    {
        private readonly IStack _stack;
        private static readonly string _operators = "+ - * /";

        public StackCalc(IStack stack)
        {
            _stack = stack;
            _stack.Clear();
        }

        public int? Calculate(string expression)
        {
            _stack.Clear();

            var tokens = expression.Split(' ');
            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    _stack.Push(number);
                }
                else if (_operators.Contains(token))
                {
                    int right = 0;
                    int left = 0;
                    try
                    {
                        right = _stack.Pop();
                        left = _stack.Pop();
                    }
                    catch (EmptyStackException e)
                    {
                        return null;
                        throw;
                    }

                    int? result = CalcBinary(left, right, token);
                    if (result.HasValue)
                    {
                        _stack.Push(Convert.ToInt32(result));
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            int? value = _stack.Pop();
            if (value != null && _stack.IsEmpty())
            {
                return Convert.ToInt32(value);
            }
            else
            {
                return null;
            }
        }

        private static int? CalcBinary(int leftOperand, int rightOperand, string op)
        {
            switch (op)
            {
                case "+":
                    return leftOperand + rightOperand;
                case "-":
                    return leftOperand - rightOperand;
                case "*":
                    return leftOperand * rightOperand;
                case "/":
                    if (rightOperand == 0)
                    {
                        return null;
                    }

                    return leftOperand / rightOperand;
                default:
                    return null;
            }
        }
    }
}
