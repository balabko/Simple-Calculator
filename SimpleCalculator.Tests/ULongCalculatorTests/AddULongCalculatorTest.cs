using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.ULongCalculator;

namespace SimpleCalculator.Tests.ULongCalculatorTests
{
    [TestClass]
    public class AddULongCalculatorTest
    {
        [TestMethod]
        public void Sum2And5Return7()
        {
            //Arrange
            var addULongCalculator = new AddULongCalculator();

            //Act
            var result = addULongCalculator.Execute(2, 5);

            //Assert
            Assert.AreEqual((ulong) 7, result);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Sum18446744073709551615And1ThrowOverflow()
        {
            //Arrange
            var addULongCalculator = new AddULongCalculator();

            //Act
            addULongCalculator.Execute(18446744073709551615, 1);
        }
    }
}
