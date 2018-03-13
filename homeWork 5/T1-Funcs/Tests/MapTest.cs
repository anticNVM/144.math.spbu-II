using System;
using System.Collections.Generic;
using Xunit;
using FuncsLib;

namespace Tests
{
    public static class MapTestData
    {
        private static readonly List<object[]> _data = new List<object[]>
        {   // TEST OF
            // correct behavior with int
            new object[] {
                new List<int>() {1, 2, 3},
                new Func<int, int>(x => x * 2),
                new List<int>() {2, 4, 6},
            },

            // correct behavior with string
            new object[] {
                new List<string>() {"a", "b", "c", "d"},
                new Func<string, string>(ch => ch.ToUpper()),
                new List<string>() {"A", "B", "C", "D"},
            },

            // another type in result
            new object[] {
                new List<string>() {"1", "2", "3", "4"},
                new Func<string, int>(str => int.Parse(str)),
                new List<int>() {1, 2, 3, 4},
            },
            
            // empty list
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
        public void MapDataDrivenTest<TIn, TOut>(List<TIn> list, Func<TIn, TOut> function, List<TOut> expected)
        {
            var actual = Funcs.Map<TIn, TOut>(list, function);

            Assert.Equal(expected, actual);
        }
    }
}
