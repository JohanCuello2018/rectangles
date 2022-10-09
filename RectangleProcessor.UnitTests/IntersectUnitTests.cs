using Microsoft.VisualStudio.TestTools.UnitTesting;
using RectangleProcessor.Core;

namespace RectangleProcessor.UnitTests
{
    [TestClass]
    public class IntersectUnitTests
    {
        [TestMethod]
        public void Validate_Intersect_Returns_True()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(1, 1, 4, 4);

            Assert.IsTrue(rectangle1.Intersects(rectangle2));
        }

        [TestMethod]
        public void Validate_Intersect_Multiple_Points_Returns_True()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(1, 1, 4, 4);

            Assert.IsTrue(rectangle2.Intersects(rectangle1));
        }

        [TestMethod]
        public void Validate_Intersect_Two_Points_Returns_True()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(10, 10, 4, 4);

            Assert.IsTrue(rectangle2.Intersects(rectangle1));
        }

        [TestMethod]
        public void Validate_Intersect_NonIntersected_Returns_False()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(11, 11, 4, 4);

            Assert.IsFalse(rectangle2.Intersects(rectangle1));
        }
    }
}
