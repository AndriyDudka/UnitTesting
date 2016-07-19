using System;
using System.Collections.Generic;
using Logic;
using NUnit.Framework;

namespace ForTest
{
    [TestFixture]
    public class AlgoServiceTests
    {
        private IAlgoService _underTest;

        #region DoubleSumTests

        [Test]
        public void DoubleSumNullArgThrowsExceptionWhenArgIsNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => _underTest.DoubleSum(null));
        }

        [Test]
        public void DoubleSumReturnsNullWhenArgIsEmptyTest()
        {
            var empty = new List<int>();

            var result = _underTest.DoubleSum(empty);

            Assert.That(_underTest.MethodsCalledCount, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void DoubleSumHappyPathTest()
        {
            var digits = new List<int> { -1, 1, -2, 2, 0};
            const int expected = 0;

            var result = _underTest.DoubleSum(digits);

            Assert.That(_underTest.MethodsCalledCount, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(expected));
        }

        #endregion

        #region MinValue

        [Test]
        public void GetMinValueThrowsInvalidOperationExceptionWhenDataIsNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => _underTest.MinValue(null));
        }

        [Test]
        public void GetMinValueThrowsInvalidOperationExceptionWhenDataIsEmptyTest()
        {
            var empty = new List<int>();

            Assert.Throws<InvalidOperationException>(() => _underTest.MinValue(empty));
        }

        [Test]
        public void GetMinValueHappyPathTest()
        {
            var digits = new List<int> { -1, 1, -2, 2, 0 };
            const int expected = -2;

            var result = _underTest.MinValue(digits);
      
            Assert.AreEqual(result, expected);
        }

        #endregion

        #region Function
        //Не враховано, що від відємного числа немає корня(не рахуючи комплексні числа)
        [Test]
        public void FunctionThrowExceptionTest()
        {
            Assert.Throws<InvalidOperationException>(() => _underTest.Function(1, -1, 1, 1));
        }

        [Test]
        public void FunctionWhenAllIsOkTest()
        {
            var function = _underTest.Function(1, 1, 1, 1);
            var expected = 2 - Math.PI;

            Assert.That(function, Is.EqualTo(expected));
        }

        #endregion

        #region GetAverage

        [Test]
        public void GetAverageNullArgThrowsExceptionWhenArgIsNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => _underTest.GetAverage(null));
        }
    
        [Test]
        public void GetAverageHappyPathTest()
        {
            var digits = new List<int> {1, 2, 3};
            const int expected = 2;

            var result = _underTest.GetAverage(digits);
     
            Assert.That(result, Is.EqualTo(expected));
        }

        #endregion

        #region GetSqr
       
        [Test]
        public void GetSqrHappyPathTest()
        {
            var result = _underTest.Sqr(2);
            var expected = 4;

            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _underTest = new AlgoService();
        }

        #endregion
    }
}
