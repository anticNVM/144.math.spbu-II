using System;
using System.Collections.Generic;
using Xunit;
using FuncsLib;

namespace Tests
{
    public static class MapTestData
    {
        private static readonly List<object[]> _data = new List<object[]>
        {
            // correct behavior test
            new object[] {
                new List<int>() {1, 2, 3},
                new Func<int, int>(x => x * 2),
                new List<int>() {2, 4, 6},
            },
            
            // empty list test
            new object[] {
                new List<int>() {},
                new Func<int, int>(x => x * 2),
                new List<int>() {},
            },
        };
        public static IEnumerable<object[]> TestData => _data;
    }

    public class MapTest
    {
        [Theory]
        [MemberData("TestData", MemberType = typeof(MapTestData))]
        public void MapDataDrivenTest(List<int> list, Func<int, int> function, List<int> expected)
        {
            var actual = Funcs<int>.Map(list, function);

            Assert.Equal(expected, actual);
        }
    }
}
