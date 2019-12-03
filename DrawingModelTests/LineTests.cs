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

        // 畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
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
            Line line = new Line();
            line.Draw(new FakeAdaptor());
            Assert.IsNotNull(line);
        }
    }
}