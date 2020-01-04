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

        // 畫線外框
        public void DrawLineFrame(double x1, double y1, double x2, double y2)
        {

        }

        // 畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {

        }

        // 畫矩形外框
        public void DrawRectangleFrame(double x1, double y1, double x2, double y2)
        {

        }

        // 畫六角形
        public void DrawHexagon(double x1, double y1, double x2, double y2)
        {

        }

        // 畫六角形外框
        public void DrawHexagonFrame(double x1, double y1, double x2, double y2)
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
            rectangle.Draw(new DrawingModelRectangleTest.FakeAdaptor.FakeAdaptor());
            Assert.IsNotNull(rectangle);
        }

        [TestMethod()]
        public void DrawFrameTest()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.DrawFrame(new DrawingModelRectangleTest.FakeAdaptor.FakeAdaptor());
            Assert.IsNotNull(rectangle);
        }

        [TestMethod()]
        public void IsSelectTest()
        {
            Rectangle rectangle = new Rectangle();
            Assert.IsFalse(rectangle.IsSelect(150, 450));
            rectangle.X1 = 100;
            rectangle.Y1 = 100;
            rectangle.X2 = 200;
            rectangle.Y2 = 200;
            Assert.IsTrue(rectangle.IsSelect(150, 150));
            Assert.IsFalse(rectangle.IsSelect(400, 550));
            rectangle.X2 = 100;
            rectangle.Y2 = 200;
            rectangle.X1 = 200;
            rectangle.Y1 = 100;
            Assert.IsTrue(rectangle.IsSelect(150, 150));
            Assert.IsFalse(rectangle.IsSelect(400, 550));
        }

        [TestMethod()]
        public void RectangleTest()
        {
            Rectangle rectangle = new Rectangle(0, 0, 1, 1);
            rectangle.InitialShape();
            Assert.AreEqual(rectangle.X1, rectangle.X2);
        }
    }
}