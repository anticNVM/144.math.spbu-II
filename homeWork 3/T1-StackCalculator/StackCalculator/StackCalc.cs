using System;
using Exceptions;

namespace StackCalculator
{
    public class StackCalc : ICalculator
    {
        private readonly IStack _stack;
        private const string _operators = "+ - * /";

        public StackCalc(IStack stack)
        {
            _stack = stack;
            _stack.Clear();
        }

        public int Calculate(string expression)
        {
            _stack.Clear();

            var tokens = expression.Split(' ');
            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    _stack.Push(number);
                }
                else
                {
                    try
                    {
                        int right = _stack.Pop();
                        int left = _stack.Pop();
                        int result = CalcBinary(left, right, token);
                        _stack.Push(result);
                    }
                    catch (EmptyStackException e)
                    {
                        throw new InvalidExpressionException(
                            "Неверное число операторов в выражении", e
                        );
                    }
                    catch (DivideByZeroException e)
                    {
                        throw new DivideByZeroException(
                            "В выражении присутсвует деление на ноль", e
                        );
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new InvalidExpressionException(
                            "Неверный оператор!", e
                        );
                    }
                }
            }

            int value = _stack.Pop();
            if (!_stack.IsEmpty())
            {
                throw new InvalidExpressionException(
                    "Неверное число операторов в выражении"
                );
            }

            return value;

        }

        private static int CalcBinary(int leftOperand, int rightOperand, string op)
        {
            int result = 0;
            switch (op)
            {
                case "+":
                    result = leftOperand + rightOperand;
                    break;
                case "-":
                    result = leftOperand - rightOperand;
                    break;
                case "*":
                    result = leftOperand * rightOperand;
                    break;
                case "/":
                    if (rightOperand == 0)
                    {
                        throw new DivideByZeroException("Нельзя делить на ноль!");
                    }
                    result = leftOperand / rightOperand;
                    break;
                default:
                    throw new InvalidOperationException($"Можно использовать только операторы {_operators}.");
            }

            return result;
        }
    }
}
