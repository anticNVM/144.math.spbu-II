using System;

namespace T4_StackCalculator
{
    public class StackCalculator
    {
        private static readonly string operators = "+ - * /";

        public static int? Calculate(string expression, IStack stack)
        {
            var tokens = expression.Split(' ');
            foreach (var token in tokens)
            {
                if (int.TryParse(token, out int number))
                {
                    stack.Push(number);
                }
                // а если я введу +- --- один оператор же -> проверить
                else if (operators.Contains(token) && char.TryParse(token, out char @operator))
                {
                    int? leftOperand = stack.Pop();
                    int? rightOperand = stack.Pop();

                    if (leftOperand == null || rightOperand == null)
                    {
                        return null;
                    }

                    // Н Е К Р А С И В О
                    var result = CalculateBinary(Convert.ToInt32(leftOperand), Convert.ToInt32(rightOperand), @operator);
                    stack.Push(result);
                }
                else
                {
                    return null;
                }
            }

            int? value = stack.Pop();
            if (value != null && stack.IsEmpty())
            {
                return Convert.ToInt32(value);
            }
            else
            {
                return null;
            }
        }

        private static int CalculateBinary(int leftOperand, int rightOperand, char @operator)
        {
            int result = 0;
            switch (@operator)
            {
                case '+':
                    {
                        result = leftOperand + rightOperand;
                        break;
                    }
                case '-':
                    {
                        result = leftOperand - rightOperand;
                        break;
                    }
                case '*':
                    {
                        result = leftOperand * rightOperand;
                        break;
                    }
                case '/':
                    {
                        result = leftOperand / rightOperand;
                        break;
                    }
                default:
                    break;
            }

            return result;
        }
    }
}
