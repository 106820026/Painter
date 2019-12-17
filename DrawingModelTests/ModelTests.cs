using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



namespace DrawingModel.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model model;

        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            model._modelChanged += EventHandler;
        }

        [TestMethod()]
        public void ModelTest()
        {
            Assert.AreEqual(model.CurrentMode, -1);
        }

        [TestMethod()]
        public void PressPointerTest()
        {
            model.CurrentMode = -1;
            model.PressPointer(90, 150);
            model.CurrentMode = 0;
            model.PressPointer(0, 0);
            model.PressPointer(90, 150);
            Assert.AreEqual(model.CurrentMode, 0);
        }

        [TestMethod()]
        public void MovePointerTest()
        {
            model.CurrentMode = 1;
            model.PressPointer(90, 150);
            model.MovePointer(180, 300);
            model.CurrentMode = 0;
            model.PressPointer(90, 150);
            model.MovePointer(180, 300);
            model.Draw(new FakeAdaptor());
            Assert.AreEqual(model.CurrentMode, 0);
        }

        [TestMethod()]
        public void ReleasePointerTest()
        {
            model.CurrentMode = 0;
            model.PressPointer(90, 150);
            model.ReleasePointer(180, 300);
            Assert.AreEqual(model.CurrentMode, 0);
            model.CurrentMode = 1;
            model.PressPointer(90, 150);
            model.ReleasePointer(180, 300);
            Assert.AreEqual(model.CurrentMode, 1);
        }

        [TestMethod()]
        public void DrawHintTest()
        {
            model.CurrentMode = 1;
            model.DrawHint(90, 90, 190, 190);
            Assert.AreEqual(model.CurrentMode, 1);
        }

        [TestMethod()]
        public void ClearTest()
        {
            model.Clear();
            Assert.AreEqual(model.CurrentMode, -1);
        }

        [TestMethod()]
        public void DrawTest()
        {
            model.CurrentMode = 0;
            model.PressPointer(90, 150);
            model.ReleasePointer(180, 300);
            Assert.AreEqual(model.CurrentMode, 0);
            model.CurrentMode = 1;
            model.PressPointer(90, 150);
            model.ReleasePointer(180, 300);
            Assert.AreEqual(model.CurrentMode, 1);
            model.Draw(new FakeAdaptor());

        }

        public void EventHandler()
        {
            Assert.IsTrue(true);
        }
    }
}