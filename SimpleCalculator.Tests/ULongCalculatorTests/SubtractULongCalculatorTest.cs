using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.ULongCalculator;

namespace SimpleCalculator.Tests.ULongCalculatorTests
{
    [TestClass]
    public class SubtractULongCalculatorTest
    {
        [TestMethod]
        public void Subtract7And5Return2()
        {
            //Arrange
            var subtractor = new SubtractULongCalculator();

            //Act
            var result = subtractor.Execute(7, 5);

            //Assert
            Assert.AreEqual((ulong)2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void Subtract1And2ThrowOverflow()
        {
            //Arrange
            var addULongCalculator = new SubtractULongCalculator();

            //Act
            addULongCalculator.Execute(1, 2);
        }
    }
}
