using System;
using System.Collections.Generic;
using CalculatorSource;
using CalculatorSource.Exceptions;
using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture()]
    public class IncorrectInputDataTests
    {
        private static readonly List<TestCaseData> _data = new List<TestCaseData>()
        {
            new TestCaseData("1.2", InvalidExpressionException._messages[
                InvalidExpressionException.MessageTypes.UnsupportedCharacters])
            .SetName("Expression with point should throw an exception"),

            new TestCaseData("abc", InvalidExpressionException._messages[
                InvalidExpressionException.MessageTypes.UnsupportedCharacters])
            .SetName("Expression with letters should throw an exception"),

            new TestCaseData("44am", InvalidExpressionException._messages[
                InvalidExpressionException.MessageTypes.UnsupportedCharacters])
            .SetName("Expression with both digits and letters should throw an exception"),

            new TestCaseData("(2*(2+3)", InvalidExpressionException._messages[
                InvalidExpressionException.MessageTypes.MissedClosingBracket])
            .SetName("Expression without closing bracket should throw an exception"),

            new TestCaseData("1+2)", InvalidExpressionException._messages[
                InvalidExpressionException.MessageTypes.MissedOpeningBracket])
            .SetName("Expression without opening should throw an exception"),

            new TestCaseData("(1+2)3", InvalidExpressionException._messages[
                InvalidExpressionException.MessageTypes.OverOperands])
            .SetName("Expression with more operands should throw an exception"),

            new TestCaseData("11+", InvalidExpressionException._messages[
                InvalidExpressionException.MessageTypes.NotEnoughOperands])
            .SetName("Expression with less operands should throw an exception"),

            new TestCaseData("1/0", InvalidExpressionException._messages[
                InvalidExpressionException.MessageTypes.DivisionByZero])
            .SetName("Expression with division by 0 should throw an exception"),

            new TestCaseData("0/0", InvalidExpressionException._messages[
                InvalidExpressionException.MessageTypes.DivisionByZero])
            .SetName("Expression with 0/0 throw an exception"),
        };

        public static IEnumerable<TestCaseData> TestCaseData()
        {
            foreach (var test in _data)
            {
                yield return test;
            }
        }

        [TestCaseSource("TestCaseData")]
        public void TestCase(string expression, string message)
        {
            var e = Assert.Throws<InvalidExpressionException>(() => Calculator.Evaluate(expression));
            Assert.AreEqual(message, e.Message);
        }
    }
}
