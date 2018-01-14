using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.ULongCalculator;

namespace SimpleCalculator.Tests.ULongCalculatorTests
{
    [TestClass]
    public class ULongSCStringConverterTest
    {
        [TestMethod]
        public void _2ToStringTest()
        {
            //Arrange
            var uLongSCStringConverter = new ULongSCStringConverter();

            //Act
            var result = uLongSCStringConverter.ToString(2);

            //Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void _2FromStringTest()
        {
            //Arrange
            var uLongSCStringConverter = new ULongSCStringConverter();

            //Act
            var result = uLongSCStringConverter.FromString("2");

            //Assert
            Assert.AreEqual((ulong)2, result);
        }

        [TestMethod]
        public void FromEmptyStringReturn0()
        {
            //Arrange
            var uLongSCStringConverter = new ULongSCStringConverter();

            //Act
            var result = uLongSCStringConverter.FromString("");

            //Assert
            Assert.AreEqual((ulong)0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FromTextStringThrowFormatException()
        {
            //Arrange
            var uLongSCStringConverter = new ULongSCStringConverter();

            //Act
            uLongSCStringConverter.FromString("hello");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FromNegativeNumStringOverflowFormatException()
        {
            //Arrange
            var uLongSCStringConverter = new ULongSCStringConverter();

            //Act
            uLongSCStringConverter.FromString("-3");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void FromVeryBigNumStringOverflowFormatException()
        {
            //Arrange
            var uLongSCStringConverter = new ULongSCStringConverter();

            //Act
            uLongSCStringConverter.FromString("99999999999999999999");
        }
    }
}
