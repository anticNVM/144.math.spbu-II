namespace CalculatorSource
{
    using System;
    using System.Collections.Generic;
    using CalculatorSource.Exceptions;
    using ArithmeticOperators = System.Collections.Generic.Dictionary<string, System.Func<double, double, double>>;

    /// <summary>
    /// Калькулятор
    /// </summary>
    public static class Calculator
    {
        /// <summary>
        /// Ассоциативный массив, который по оператору возвращает соответствующую бинарную операцию
        /// </summary>
        private static ArithmeticOperators _operators = new ArithmeticOperators()
        {
            ["+"] = (x, y) => x + y,
            ["-"] = (x, y) => x - y,
            ["*"] = (x, y) => x * y,
            ["/"] = (x, y) =>
            {
                const double delta = 1e-6;
                if (Math.Abs(y) < delta)
                {
                    throw new DivideByZeroException();
                }

                return x / y;
            }
        };

        /// <summary>
        /// Ассоциативный массив, который по оператору возвращает соответствующий приоритет операции
        /// </summary>
        private static Dictionary<string, int> _priorityOfOperators = new Dictionary<string, int>()
        {
            ["("] = 0,
            ["+"] = 1,
            ["-"] = 1,
            ["*"] = 2,
            ["/"] = 2,
        };

        /// <summary>
        /// Считает выражение в инфиксной записи.
        /// </summary>
        /// <returns>Значение выражения</returns>
        /// <param name="expression">Выражение для вычисления</param>
        /// <exception cref="InvalidExpressionException">Бросается, если выражение некорректно</exception>
        public static double Evaluate(string expression)
        {
            expression = expression.Replace(" ", string.Empty);
            var tokens = ParseExpression(expression);
            var postfix = SortingStation(tokens);
            var result = Calculate(postfix);

            return result;
        }

        /// <summary>
        /// Разделяет выражение по токенам
        /// </summary>
        /// <returns>Список токенов</returns>
        /// <param name="expression">Выражение</param>
        private static LinkedList<string> ParseExpression(string expression)
        {
            var tokens = new LinkedList<string>();
            var length = expression.Length;
            string tempNum = "";

            var i = 0;
            while (i < length)
            {
                // цифры мб не однозначными
                if (char.IsDigit(expression[i]))
                {
                    while (i < length && char.IsDigit(expression[i]))
                    {
                        tempNum += expression[i];
                        i++;
                    }

                    tokens.AddLast(tempNum);
                    tempNum = string.Empty;
                }
                // все остальные символы - однозначные
                else
                {
                    tokens.AddLast(char.ToString(expression[i]));
                    i++;
                }
            }

            return tokens;
        }

        /// <summary>
        /// Преобразует выражение в инфиксной записи в выражение в постфиксной
        /// </summary>
        /// <returns>Список токенв в постфиксной записи</returns>
        /// <param name="tokens">Список токенов в инфиксной записи</param>
        /// <exception cref="InvalidExpressionException">Бросается, если выражение некорректно</exception>
        private static LinkedList<string> SortingStation(LinkedList<string> tokens)
        {
            var postfixNotation = new LinkedList<string>();
            var stack = new Stack<string>();

            foreach (var token in tokens)
            {
                // если операнд
                if (double.TryParse(token, out double _))
                {
                    postfixNotation.AddLast(token);
                }
                // если опретор
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
                        throw new InvalidExpressionException(
                            InvalidExpressionException._messages[
                            InvalidExpressionException.MessageTypes.MissedOpeningBracket]);
                    }

                    stack.Pop();
                }
                else
                {
                    throw new InvalidExpressionException(
                        InvalidExpressionException._messages[
                        InvalidExpressionException.MessageTypes.UnsupportedCharacters]);
                }
            }

            while (stack.Count > 0)
            {
                if (stack.Peek() == "(")
                {
                    throw new InvalidExpressionException(
                        InvalidExpressionException._messages[
                        InvalidExpressionException.MessageTypes.MissedClosingBracket]);
                }

                postfixNotation.AddLast(stack.Pop());
            }

            return postfixNotation;
        }

        /// <summary>
        /// Считает значение выражения в постфиксной записи
        /// </summary>
        /// <returns>Значение выражения</returns>
        /// <param name="tokens">Список токенов</param>
        /// <exception cref="InvalidExpressionException">Бросается, если выражение некорректно</exception>
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
                        double res = _operators[token](stack.Pop(), rightOperand);
                        stack.Push(res);
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new InvalidExpressionException(
                            InvalidExpressionException._messages[
                            InvalidExpressionException.MessageTypes.NotEnoughOperands], e);
                    }
                    catch (DivideByZeroException e)
                    {
                        throw new InvalidExpressionException(
                            InvalidExpressionException._messages[
                            InvalidExpressionException.MessageTypes.DivisionByZero], e);
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
                throw new InvalidExpressionException(
                    InvalidExpressionException._messages[
                    InvalidExpressionException.MessageTypes.OverOperands]);
            }

            return result;
        }
    }
}
