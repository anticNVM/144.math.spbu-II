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
        };
        public static IEnumerable<object[]> TestData => _data;
    }

    public class FoldTest
    {
        [Theory]
        [MemberData("TestData", MemberType = typeof(FoldTestData))]
        public void FoldDataDrivenTest(List<int> list, int initValue, Func<int, int, int> function, int expected)
        {
            var actual = Funcs<int>.Fold(list, initValue, function);

            Assert.Equal(expected, actual);
        }
    }
}