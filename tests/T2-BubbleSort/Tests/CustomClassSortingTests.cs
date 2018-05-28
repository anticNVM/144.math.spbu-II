namespace Tests
{
    using System;
    using Xunit;
    using System.Collections.Generic;
    using BubbleSortSource;
    using System.Collections;

    /// <summary>
    /// Кастомный класс для теста
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// Компаратор для класса person
    /// </summary>
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return string.Compare(x.Name, y.Name);
        }
    }

    /// <summary>
    /// Генератор testCase`ов
    /// </summary>
    public class PersonTestDataGenerator
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[]
            {
                new object[]
                {
                new Person {Name = "Salieri", Age = 20},
                new Person {Name = "Mancini", Age = 79},
                new Person {Name = "Vivaldi", Age = 16},
                new Person {Name = "Serpico", Age = 19},
                },

                new object[]
                {
                new Person {Name = "Mancini", Age = 79},
                new Person {Name = "Salieri", Age = 20},
                new Person {Name = "Serpico", Age = 19},
                new Person {Name = "Vivaldi", Age = 16},
                },
            };

        }
    }

    /// <summary>
    /// Тесты
    /// </summary>
    public class CustomClassSortingTests
    {
        [Theory]
        [MemberData("TestData", MemberType = typeof(PersonTestDataGenerator))]
        public void DataDrivenTest(Person[] array, Person[] sorted)
        {
            var actualSorted = BubbleSort.Sort(array, new PersonComparer());

            Assert.Equal(sorted, actualSorted);
        }
    }

}