using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeGeneratorSource;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Класс, тестирующий функциональность <see cref="PrimeGenerator"/>
    /// </summary>
    [TestClass]
    public class PrimeGeneratorTest
    {
        /// <summary>
        /// Проверяет, действительно ли первые 10 сгенерированных чисел простые
        /// </summary>
        [TestMethod]
        public void FirstTenGeneratedNumbersShouldBePrimes()
        {
            var expected =  new List<int> {2, 3, 5, 7, 11, 13, 17, 19, 23, 29};
            var actual = PrimeGenerator.GenerateFirst(10).ToArray();

            var i = 0;
            expected.ForEach((number) => {
                Assert.AreEqual(number, actual[i]);
                i++;
            });
        }

        /// <summary>
        /// Проверяет, что <see cref="PrimeGenerator.GenerateFirst"/> генерит ровно amount чисел
        /// </summary>
        [TestMethod]
        public void GenerateFirstShouldReturnCollectionWithRightLength()
        {
            var primes = PrimeGenerator.GenerateFirst(10).ToArray();

            Assert.AreEqual(primes.Length, 10);
        }
    }
}
