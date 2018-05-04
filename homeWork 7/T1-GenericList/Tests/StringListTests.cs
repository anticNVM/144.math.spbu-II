using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericListSource;

namespace Tests
{
    /// <summary>
    /// Класс тестов, проверяющий методы класса <see cref="GenericList"/>,
    /// использующие проверку на равенство значений ссылочного типа (<see langword="string"/>)
    /// </summary>
    [TestClass]
    public class StringListTests
    {
        private GenericList<string> _list;

        [TestInitialize]
        public void Init()
        {
            _list = new GenericList<string>();
        }

        [TestMethod]
        public void ContainsBehaviorTest1()
        {
            _list.Add("a");
            _list.Add("aa");
            _list.Add("aaa");

            Assert.IsTrue(_list.Contains("aaa"));
        }

        [TestMethod]
        public void ContainsBehaviorTest2()
        {
            var item = "aaa";
            _list.Add(item);

            Assert.IsTrue(_list.Contains(item));
        }
    }
}