using System;
using System.Collections.Generic;
using Xunit;
using FuncsLib;

namespace Tests
{
    public static class FilterTestData
    {
        private static readonly List<object[]> _data = new List<object[]>
        {
            // correct behavior test
            new object[] {
                new List<int>() {1, 2, 3},
                new Func<int, bool>(x => x % 2 == 0),
                new List<int>() {2},
            },
            
            // empty list test
            new object[] {
                new List<int>() {},
                new Func<int, bool>(x => x == 1),
                new List<int>() {},
            },
        };
        public static IEnumerable<object[]> TestData => _data;
    }

    public class FilterTest
    {
        [Theory]
        [MemberData("TestData", MemberType = typeof(FilterTestData))]
        public void FilterDataDrivenTest(List<int> list, Func<int, bool> function, List<int> expected)
        {
            var actual = Funcs<int>.Filter(list, function);

            Assert.Equal(expected, actual);
        }
    }
}