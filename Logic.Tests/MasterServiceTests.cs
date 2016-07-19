using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Moq;
using NUnit.Framework;

namespace ForTest
{
    [TestFixture]
    public class MasterServiceTests
    {
        private Mock<IAlgoService> _algoServiceMock;

        private Mock<IDataService> _dataServicMock;

        private IMasterService _underTest;


        #region GetDoubleSum

        [Test]
        public void GetDoubleSumThrowsInvalidOperationExceptionWhenDataIsNullTest()
        {
            _dataServicMock.Setup(ds => ds.GetAllData()).Returns(null as IEnumerable<int>);

            Assert.Throws<InvalidOperationException>(() =>_underTest.GetDoubleSum());
        }

        [Test]
        public void GetDoubleSumThrowsInvalidOperationExceptionWhenDataIsEmptyTest()
        {
            _dataServicMock.Setup(ds => ds.GetAllData()).Returns(new List<int>());

            Assert.Throws<InvalidOperationException>(() => _underTest.GetDoubleSum());
        }

        [Test]
        public void GetDoubleSumDoesCallToAlgoServiceDoubleSumWhenAllIsOkTest()
        {
            var data = new List<int> {1,2,3};
            _dataServicMock.Setup(ds => ds.GetAllData()).Returns(data);

            _underTest.GetDoubleSum();

            _algoServiceMock.Verify(algs => algs.DoubleSum(data));
        }

        #endregion

        #region GetAverage

        [Test]
        public void GetAverageDoesCallToAlgoServiceAverageTest()
        {
            var data = new List<int> { 1, 2, 3 };
            _dataServicMock.Setup(ds => ds.GetAllData()).Returns(data);

            _underTest.GetAverage();

            _algoServiceMock.Verify(algs => algs.GetAverage(data));
        }

        #endregion

        #region GetMaxSquare

        [Test]
        public void GetMaxSquareDoesCallToAlgoServiceGetMaxSquareTest()
        {
            var data = 20;
            _dataServicMock.Setup(ds => ds.GetMax()).Returns(data);

            _underTest.GetMaxSquare();

            _algoServiceMock.Verify(algs => algs.Sqr(data));
        }
        #endregion

        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            _algoServiceMock = new Mock<IAlgoService>();
            _dataServicMock = new Mock<IDataService>();
            
            _underTest = new MasterService(_algoServiceMock.Object, _dataServicMock.Object);
        }

        #endregion

    }
}
