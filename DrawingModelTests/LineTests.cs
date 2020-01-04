using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModelLineTest.FakeAdaptor;

namespace DrawingModelLineTest.FakeAdaptor
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
    public class LineTests
    {
        [TestMethod()]
        public void DrawTest()
        {
            Line line = new Line(1, 2, 3, 4);
            line.Draw(new DrawingModelLineTest.FakeAdaptor.FakeAdaptor());
            Line line2 = new Line(0, 0, 0, 1);
            line2.Draw(new DrawingModelLineTest.FakeAdaptor.FakeAdaptor());
            Line line3 = new Line(0, 1, 1, 1);
            line3.Draw(new DrawingModelLineTest.FakeAdaptor.FakeAdaptor());
            Line line4 = new Line(1, 1, 1, 1);
            line4.Draw(new DrawingModelLineTest.FakeAdaptor.FakeAdaptor());
            Assert.IsNotNull(line);
        }

        [TestMethod()]
        public void DrawFrameTest()
        {
            Line line = new Line(1, 2, 3, 4);
            line.DrawFrame(new DrawingModelLineTest.FakeAdaptor.FakeAdaptor());
            Line line2 = new Line(0, 0, 0, 1);
            line2.DrawFrame(new DrawingModelLineTest.FakeAdaptor.FakeAdaptor());
            Line line3 = new Line(0, 1, 1, 1);
            line3.DrawFrame(new DrawingModelLineTest.FakeAdaptor.FakeAdaptor());
            Line line4 = new Line(1, 1, 1, 1);
            line4.DrawFrame(new DrawingModelLineTest.FakeAdaptor.FakeAdaptor());
            Assert.IsNotNull(line);
        }

        [TestMethod()]
        public void IsSelectTest()
        {
            Line line = new Line();
            Assert.IsFalse(line.IsSelect(150, 450));
            line.X1 = 100;
            line.Y1 = 100;
            line.X2 = 200;
            line.Y2 = 200;
            Assert.IsTrue(line.IsSelect(150, 150));
            Assert.IsFalse(line.IsSelect(250, 150));
        }

        [TestMethod()]
        public void InitialShapeTest()
        {
            Line line = new Line(1, 2, 3, 4);
            line.InitialShape();
            Assert.AreEqual(line.X1, line.X2);
        }
    }
}