using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleCalculator.Core;

namespace SimpleCalculator.Tests.CoreTests
{
    [TestClass]
    public class SCProcessorTest
    {
        [TestMethod]
        public void ResetResetsAllValues()
        {
            //Arrange
            Mock<ISCBinOperationFactory<int>> binOperationMock = new Mock<ISCBinOperationFactory<int>>();
            var scProcessor =
                new SCProcessor<int>(binOperationMock.Object) {LopRes = 2, Rop = 5, Operation = SCBinOperation.Add};

            //Act
            scProcessor.Reset();

            //Assert
            Assert.AreEqual(SCBinOperation.None, scProcessor.Operation);
            Assert.AreEqual(0, scProcessor.LopRes);
            Assert.AreEqual(0, scProcessor.Rop);
        }

        [TestMethod]
        public void ResetOperationMakesOperationTypeNone()
        {
            //Arrange
            Mock<ISCBinOperationFactory<int>> binOperationMock = new Mock<ISCBinOperationFactory<int>>();
            var scProcessor =
                new SCProcessor<int>(binOperationMock.Object) {Operation = SCBinOperation.Add };

            //Act
            scProcessor.ResetOperation();

            //Assert
            Assert.AreEqual(SCBinOperation.None, scProcessor.Operation);
        }

        [TestMethod]
        public void ResetOperationDontTouchOps()
        {
            //Arrange
            Mock<ISCBinOperationFactory<int>> binOperationMock = new Mock<ISCBinOperationFactory<int>>();
            var scProcessor =
                new SCProcessor<int>(binOperationMock.Object) { LopRes = 2, Rop = 5 };

            //Act
            scProcessor.ResetOperation();

            //Assert
            Assert.AreEqual(2, scProcessor.LopRes);
            Assert.AreEqual(5, scProcessor.Rop);
        }

        [TestMethod]
        public void Sum2And5ExecuteMakesLopRes7()
        {
            //Arrange
            Mock<ISCBinOperationCalculator<int>> intSummatorMock = new Mock<ISCBinOperationCalculator<int>>();
            Mock<ISCBinOperationFactory<int>> binOperationMock = new Mock<ISCBinOperationFactory<int>>();
            var scProcessor = new SCProcessor<int>(binOperationMock.Object);

            intSummatorMock.Setup(x => x.Execute(2, 5)).Returns(7);
            binOperationMock.Setup(x => x.GetBinOperationCalculator(SCBinOperation.Add))
                .Returns(intSummatorMock.Object);

            //Act
            scProcessor.LopRes = 2;
            scProcessor.Rop = 5;
            scProcessor.Operation = SCBinOperation.Add;
            scProcessor.ExecuteOperation();

            //Assert
            Assert.AreEqual(7, scProcessor.LopRes);
        }
    }
}
