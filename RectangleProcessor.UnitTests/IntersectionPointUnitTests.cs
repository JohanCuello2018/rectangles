using Microsoft.VisualStudio.TestTools.UnitTesting;
using RectangleProcessor.Core;
using System.Linq;

namespace RectangleProcessor.UnitTests
{
    [TestClass]
    public class IntersectionPointUnitTests
    {
        [TestMethod]
        public void GetIntersectionPoints_Returns_Two_Coordinates()
        {
            Rectangle rectangle1 = new(1, 1, 2, 2);
            Rectangle rectangle2 = new(2, 2, 3, 3);

            var coordinates = rectangle1.GetIntersectionPoints(rectangle2);

            Assert.IsTrue(coordinates.Count() == 2);
        }

        [TestMethod]
        public void GetIntersectionPoints_Returns_One_Coordinate()
        {
            Rectangle rectangle1 = new(1, 1, 2, 2);
            Rectangle rectangle2 = new(3, 3, 3, 3);

            var coordinates = rectangle1.GetIntersectionPoints(rectangle2);

            Assert.IsTrue(coordinates.Count() == 1);
        }

        [TestMethod]
        public void GetIntersectionPoints_Returns_Four_Coordinates()
        {
            Rectangle rectangle1 = new(2, 3, 5, 4);
            Rectangle rectangle2 = new(3, 2, 3, 7);

            var coordinates = rectangle1.GetIntersectionPoints(rectangle2);

            Assert.IsTrue(coordinates.Count() == 4);
        }
    }
}
