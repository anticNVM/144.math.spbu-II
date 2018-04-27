using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exceptions;
using System;

namespace StackCalculator.Test
{
    /// <summary>
    /// Тесты, проверяющие работоспособность калькулятора
    /// </summary>
    [TestClass]
    public class StackCalcTest
    {
        private ICalculator _calc;

        [TestInitialize]
        public void Init()
        {
            _calc = new StackCalc(new LinkedStack());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void PlusMinusAsOperatorShouldThrowException()
        {
            string expression = "1 2 +-";
            var result = _calc.Calculate(expression);
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
        [ExpectedException(typeof(InvalidExpressionException))]
        public void LetterInExprShouldThrowException()
        {
            string expression = "1 2 a";
            var result = _calc.Calculate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void TooManyOperatorsShouldThrowException()
        {
            string expression = "1 2 + -";
            var result = _calc.Calculate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]
        public void TooManyOperandsShouldThrowException()
        {
            string expression = "1 2 3 +";
            var result = _calc.Calculate(expression);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]        
        public void NothingInInputShouldThrowException()
        {
            string expression = "";
            var result = _calc.Calculate(expression);
        }

        [TestMethod]
        public void AnotherUsefullTest_InBracketsNo()
        {
            string expression = "9 6 - 1 2 + *";
            int expected = 9;
            var result = _calc.Calculate(expression);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]        
        public void ZeroDivisionShouldThrowException()
        {
            string expression = "1 0 /";
            var result = _calc.Calculate(expression);
        }

        [TestMethod]
        public void NegativeNumbers()
        {
            string expression = "-9 -6 - -1 -2 + * -2 /";
            int expected = -4;
            var result = _calc.Calculate(expression);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidExpressionException))]        
        public void TooManySpacesShouldThrowException()
        {
            string expression = "1    2 +";
            var result = _calc.Calculate(expression);
        }
    }
}
