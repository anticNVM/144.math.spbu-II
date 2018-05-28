using System;
using Xunit;
using System.Collections.Generic;
using BubbleSortSource;

namespace Tests
{
    /// <summary>
    /// Генератор testcase`щв для проверки bubbleSort на значениях типа int
    /// </summary>
    public static class TestDataGenerator
    {
        private static readonly List<object[]> _data = new List<object[]>
        {
            // empty array test
            new object[] {
                new int[] {},
                new int[] {},
            },
            // 1 element test
            new object[] {
                new int[] {1},
                new int[] {1},
            },
            // 2 element test
            new object[] {
                new int[] {36,5},
                new int[] {5,36},
            },
            // 3 element test
            new object[] {
                new int[] {7,4,5},
                new int[] {4,5,7},
            },
            // 4 element test
            new object[] {
                new int[] {1,5,3,10},
                new int[] {1,3,5,10},
            },
            // 5 element test
            new object[] {
                new int[] {1,5,3,10,10},
                new int[] {1,3,5,10,10},
            },
            // 6 element test
            new object[] {
                new int[] {30,4,5,6,8,10},
                new int[] {4,5,6,8,10,30},
            },
            // sort sorted array test
            new object[] {
                new int[] {7,7,7,7,7,7,7,7,7,7},
                new int[] {7,7,7,7,7,7,7,7,7,7},
            },
            // array of zeroes test
            new object[] {
                new int[10],
                new int[10],
            },
            // reverse order array test
            new object[] {
                new int[] {10,9,8,7,6,5,4,3,2,1},
                new int[] {1,2,3,4,5,6,7,8,9,10},
            },
            // negative array test
            new object[] {
                new int[] {-30,-4,-5,-6,-8,-10},
                new int[] {-30,-10,-8,-6,-5,-4},
            },
            // 4 ones, then 6 zeroes
            new object[] {
                new int[] {1,1,1,1,0,0,0,0,0,0},
                new int[] {0,0,0,0,0,0,1,1,1,1},
            },
        };

        public static IEnumerable<object[]> TestData => _data;
    }

    /// <summary>
    /// Класс, тестирующий <see cref="BubbleSort.Sort"/>
    /// </summary>
    public class HeapSortTest
    {
        [Theory]
        [MemberData("TestData", MemberType = typeof(TestDataGenerator))]
        public void DataDrivenTest(int[] array, int[] sorted)
        {
            var actualSorted = BubbleSort.Sort(array, Comparer<int>.Default);

            Assert.Equal(sorted, actualSorted);
        }
    }
}
