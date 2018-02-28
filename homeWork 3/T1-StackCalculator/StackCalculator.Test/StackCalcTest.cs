using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackCalculator.Test
{
    [TestClass]
    public class StackCalcTest
    {
        private static ICalculator _calc;

        [TestInitialize]
        public void Init()
        {
            _calc = new StackCalc(new LinkedStack());
        }

        [TestMethod]
        public void DontUse_PlusMinus_AsOperator()
        {
            string expression = "1 2 +-";
            var result = _calc.Calculate(expression);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsRightOrderOfOperands()
        {
            string expression = "1 2 -";
            int expected = -1;
            var result = _calc.Calculate(expression);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LetterInExpr()
        {
            string expression = "1 2 a";
            var result = _calc.Calculate(expression);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TooManyOperators()
        {
            string expression = "1 2 + -";
            var result = _calc.Calculate(expression);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TooManyOperands()
        {
            string expression = "1 2 3 +";
            var result = _calc.Calculate(expression);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void NothingInInput()
        {
            string expression = "";
            var result = _calc.Calculate(expression);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void AnotherUsefullTest_InBracketsNo()
        {
            string expression = "9 6 - 1 2 + *";
            int expected = 9;
            var result = _calc.Calculate(expression);

            Assert.AreEqual(expected, result);
        }
    }
}
