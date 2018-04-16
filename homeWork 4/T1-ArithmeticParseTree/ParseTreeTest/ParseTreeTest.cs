using System;
using Xunit;
using ParseTreeSource;
using System.Collections.Generic;

namespace ParseTreeTest
{
    /// <summary>
    /// Тест дерева разбора
    /// </summary>
    public class ParseTreeTest
    {
        public static IEnumerable<object[]> DataGenerator()
        {
            // тест из примера
            yield return new object[] {"( + ( * 1 2 ) 2 )", 4};
            // 1 операнд
            yield return new object[] {"1", 1};
            // 0 операндов
            yield return new object[] {"", 0};
            // полное дерево высоты 3
            yield return new object[] {"( * ( + 2 3 ) ( + 3 3 ) )", 30};
            // деление и разность
            yield return new object[] {"( - 30 ( / 25 5 ) )", 25};
            // деление нуля
            yield return new object[] {"( / 0 1 )", 0};
            // юольшая вложенность операций
            yield return new object[] {"( + ( + ( + ( + 1 1 ) 1 ) 1 ) 1 )", 5};
        }

        [Theory]
        [MemberData(nameof(DataGenerator))]
        public void EvaluateTestWithCorrectData(string expression, int expected)
        {
            var tree = new ParseTree(expression);
            var actual = tree.Evaluate();
            Assert.Equal(expected, actual);
        }
    }
}
