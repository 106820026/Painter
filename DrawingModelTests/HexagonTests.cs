using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModelHexagonTest.FakeAdaptor
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
    public class HexagonTests
    {
        [TestMethod()]
        public void DrawTest()
        {
            Hexagon hexagon = new Hexagon();
            hexagon.Draw(new FakeAdaptor());
            Assert.IsNotNull(hexagon);
        }

        [TestMethod()]
        public void DrawFrameTest()
        {
            Hexagon hexagon = new Hexagon();
            hexagon.DrawFrame(new FakeAdaptor());
            Assert.IsNotNull(hexagon);
        }

        [TestMethod()]
        public void IsSelectTest()
        {
            Hexagon hexagon = new Hexagon();
            Assert.IsFalse(hexagon.IsSelect(150, 450));
            hexagon.X1 = 100;
            hexagon.Y1 = 100;
            hexagon.X2 = 200;
            hexagon.Y2 = 200;
            Assert.IsTrue(hexagon.IsSelect(150, 150));
            Assert.IsFalse(hexagon.IsSelect(400, 550));
            hexagon.X1 = 200;
            hexagon.Y1 = 100;
            hexagon.X2 = 100;
            hexagon.Y2 = 200;
            Assert.IsTrue(hexagon.IsSelect(150, 150));
            Assert.IsFalse(hexagon.IsSelect(400, 550));
            hexagon.X1 = 200;
            hexagon.Y1 = 200;
            hexagon.X2 = 200;
            hexagon.Y2 = 200;
        }
    }
}