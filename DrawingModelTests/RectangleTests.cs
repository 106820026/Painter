using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using DrawingModelRectangleTest.FakeAdaptor;

namespace DrawingModelRectangleTest.FakeAdaptor
{
    public class FakeAdaptor : IGraphics
    {
        public FakeAdaptor()
        {

        }

        // 清除畫面
        public void ClearAll()
        {

        }

        // 畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {

        }

        // 畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {

        }
    }
}

namespace DrawingModel.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        [TestMethod()]
        public void DrawTest()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Draw(new FakeAdaptor());
            Assert.IsNotNull(rectangle);
        }
    }
}