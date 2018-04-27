using NUnit.Framework;
using System;
using System.Collections.Generic;
using CalculatorSource;


namespace CalculatorTests
{
    [TestFixture()]
    public class CorrectInputDataTests
    {
        //private sealed class DataSet : List<KeyValuePair<string, double>> { }
        private static readonly List<TestCaseData> _data = new List<TestCaseData>()
        {
            //new TestCaseData(new Dictionary<string, double>() {
            //    [""] = 1
            //}).SetName("Empty expression should evaluated in 0"),

            new TestCaseData("25", 25).SetName("Single number should evaluated in itself"),
            new TestCaseData("1+2", 3).SetName("Simple smoke test"),
            new TestCaseData("119+1", 120).SetName("Smoke test with bigger numbers"),
            new TestCaseData("(1+2)", 3).SetName("Smoke test with brackets"),
            new TestCaseData("1+2*3", 7).SetName("Test with multiplication"),
            new TestCaseData("1+2-3*4", -9).SetName("Test with subtraction"),
            new TestCaseData("1+2*3-4", 3).SetName("Right order of operations test"),
            new TestCaseData("(1+2)*3", 9).SetName("Test with brackets"),
            new TestCaseData("(1+2*3)/2", 3.5).SetName("Test with division"),
            new TestCaseData("(2*(2+3)+4)/2", 7).SetName("Everything at once test"),
            new TestCaseData("0/1", 0).SetName("Division of 0 should evaluated in 0"),
            new TestCaseData("11 * 2 * 33  *  4 * 55", 159720).SetName("Test with spaces should works correctly"),
        };

        public static IEnumerable<TestCaseData> TestCaseData()
        {
            foreach (var test in _data)
            {
                yield return test;
            }
        }

        [TestCaseSource("TestCaseData")]
        public void DataDrivenTest(string expression, double expected)
        {
            const double delta = 1e-6;
            var actual = Calculator.Evaluate(expression);

            Assert.AreEqual(expected, actual, delta);
        }
    }
}
