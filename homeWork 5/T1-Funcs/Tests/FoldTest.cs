using System;
using System.Collections.Generic;
using Xunit;
using FuncsLib;

namespace Tests
{
    public static class FoldTestData
    {
        private static readonly List<object[]> _data = new List<object[]>
        {
            // correct behavior test
            new object[] {
                new List<int>() {1, 2, 3},
                1,
                new Func<int, int, int>((acc, elem) => acc * elem),
                6                
            },
            
            // empty list test
            new object[] {
                new List<int>() {},
                5,
                new Func<int, int, int>((acc, elem) => acc * elem),
                5,
            },

            // 
            new object[] {
                new List<string>() {"h", "e", "l", "l"},
                "",
                new Func<string, string, string>((acc, elem) => acc += elem),
                "hell",            
            },
        };
        public static IEnumerable<object[]> TestData => _data;
    }

    public class FoldTest
    {
        [Theory]
        [MemberData("TestData", MemberType = typeof(FoldTestData))]
        public void FoldDataDrivenTest<T>(List<T> list, T initValue, Func<T, T, T> function, T expected)
        {
            var actual = Funcs.Fold<T>(list, initValue, function);

            Assert.Equal(expected, actual);
        }
    }
}