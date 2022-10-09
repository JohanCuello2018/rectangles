using Microsoft.VisualStudio.TestTools.UnitTesting;
using RectangleProcessor.Core;

namespace RectangleProcessor.UnitTests
{
    [TestClass]
    public class AdjacentUnitTests
    {
        [TestMethod]
        public void Validate_Adjacent_Lower_Returns_True()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(0, 0, 10, -10);

            Assert.IsTrue(rectangle1.Adjacent(rectangle2));
        }

        [TestMethod]
        public void Validate_Adjacent_Upper_Returns_True()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(0, 10, 10, 10);

            Assert.IsTrue(rectangle1.Adjacent(rectangle2));
        }

        [TestMethod]
        public void Validate_Adjacent_Left_Returns_True()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(0, 0, -10, 10);

            Assert.IsTrue(rectangle1.Adjacent(rectangle2));
        }

        [TestMethod]
        public void Validate_Adjacent_Right_Returns_True()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(10, 0, 10, 10);

            Assert.IsTrue(rectangle1.Adjacent(rectangle2));
        }

        [TestMethod]
        public void Validate_Adjacent_Right_Returns_False()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(11, 0, 10, -10);

            Assert.IsFalse(rectangle1.Adjacent(rectangle2));
        }

        [TestMethod]
        public void Validate_Adjacent_Right_Non_Returns_False()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(11, 0, 10, 10);

            Assert.IsFalse(rectangle1.Adjacent(rectangle2));
        }

        [TestMethod]
        public void Validate_Adjacent_Left_Non_Returns_False()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(11, 1, -10, 10);

            Assert.IsFalse(rectangle1.Adjacent(rectangle2));
        }
    }
}
