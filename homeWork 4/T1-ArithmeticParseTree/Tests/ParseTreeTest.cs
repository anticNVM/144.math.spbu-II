using System;
using Xunit;
using ParseTreeSource;
using System.Collections.Generic;

namespace ParseTreeTest
{
    /// <summary>
    /// Тест вычисления значения дерева разбора
    /// </summary>
    public class ParseTreeTest
    {
        private static object[][] _testData = new object[][] {
            // тест из примера
            new object[] { "( + ( * 1 2 ) 2 )", "((1 * 2) + 2)", 4 },
            // 1 операнд            
            new object[] { "1", "1", 1 },
            // 0 операндов
            new object[] { "", "0", 0 },
            // полное дерево высоты 3
            new object[] { "( * ( + 2 3 ) ( + 3 3 ) )", "((2 + 3) * (3 + 3))", 30 },
            // деление и разность
            new object[] { "( - 30 ( / 25 5 ) )", "(30 - (25 / 5))", 25 },
            // деление нуля
            new object[] { "( / 0 1 )", "(0 / 1)", 0 },
            // большая вложенность операций
            new object[] { "( + ( + ( + ( + 1 1 ) 1 ) 1 ) 1 )", "((((1 + 1) + 1) + 1) + 1)", 5 },
        };

        public static IEnumerable<object[]> EvaluateDataGenerator()
        {
            foreach (var testCase in _testData)
            {
                yield return new object[] { testCase[0], testCase[2] };
            }
        }

        [Theory]
        [MemberData(nameof(EvaluateDataGenerator))]
        public void EvaluateTestWithCorrectData(string expression, int expected)
        {
            var tree = new ParseTree(expression);
            var actual = tree.Evaluate();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivisionByZeroShouldThrowException()
        {
            var tree = new ParseTree("( / 1 0 )");
            Assert.Throws<DivideByZeroException>(() => tree.Evaluate());
        }

        public static IEnumerable<object[]> ToStringDataGenerator()
        {
            foreach (var testCase in _testData)
            {
                yield return new object[] { testCase[0], testCase[1] };
            }
        }

        [Theory]
        [MemberData(nameof(ToStringDataGenerator))]
        public void ToStringTest(string expression, string expected)
        {
            var tree = new ParseTree(expression);
            var actual = tree.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
