using Microsoft.VisualStudio.TestTools.UnitTesting;
using RectangleProcessor.Core;

namespace RectangleProcessor.UnitTests
{
    [TestClass]
    public class ContainsUnitTests
    {
        [TestMethod]
        public void Validate_Contains_Returns_True()
        { 
            Rectangle rectangle1 = new(0,0,10,10);
            Rectangle rectangle2 = new(1,1,4,4);
        
            Assert.IsTrue(rectangle1.Contains(rectangle2));
        }

        [TestMethod]
        public void Validate_Contains_NonContained_Intersected_Returns_False()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(1, 1, 4, 4);

            Assert.IsFalse(rectangle2.Contains(rectangle1));
        }

        [TestMethod]
        public void Validate_Contains_NonContained_NonIntersected_Returns_False()
        {
            Rectangle rectangle1 = new(0, 0, 10, 10);
            Rectangle rectangle2 = new(11, 11, 4, 4);

            Assert.IsFalse(rectangle2.Contains(rectangle1));
        }
    }
}
