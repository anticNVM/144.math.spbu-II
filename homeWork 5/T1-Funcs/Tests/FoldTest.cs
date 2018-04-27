using System;
using System.Collections.Generic;
using Xunit;
using FuncsLib;

namespace Tests
{
    public static class FoldTestData
    {
        private static readonly List<object[]> _data = new List<object[]>
        {   // TEST OF
            // correct behavior with int
            new object[] {
                new List<int>() {1, 2, 3},
                1,
                new Func<int, int, int>((acc, elem) => acc * elem),
                6
            },
            
            // list join
            new object[] {
                new List<string>() {"h", "e", "l", "l", "o"},
                "",
                new Func<string, string, string>((acc, elem) => acc += elem),
                "hello",
            },

            // different types example
            new object[] {
                new List<string>() {"Brave", "New", "World"},
                0,
                new Func<int, string, int>((acc, word) => acc += word.Length),
                13,
            },

            // empty list test
            new object[] {
                new List<int>() {},
                5,
                new Func<int, int, int>((acc, elem) => acc * elem),
                5,
            },
        };

        public static IEnumerable<object[]> TestData => _data;
    }

    public class FoldTest
    {
        [Theory]
        [MemberData("TestData", MemberType = typeof(FoldTestData))]
        public void FoldDataDrivenTest<TIn, TOut>(
            List<TIn> list, TOut initValue, Func<TOut, TIn, TOut> function, TOut expected)
        {
            var actual = Funcs.Fold<TIn, TOut>(list, initValue, function);

            Assert.Equal(expected, actual);
        }
    }
}