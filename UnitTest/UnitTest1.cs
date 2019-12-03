using System;
using System.Drawing;
using DrawingModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.FakeAdapter
{
    public class FakeAdapter : IGraphics
    {
        public FakeAdapter()
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

namespace DrawingForm.PresentationModel.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        Model model;
        PresentationModel presentationModel;

        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
        }

        [TestMethod()]
        public void PresentationModelTest()
        {
            Assert.IsNotNull(presentationModel);
        }

        [TestMethod()]
        public void DrawTest()
        {
            model.Draw(new UnitTest.FakeAdapter.FakeAdapter());
            Assert.IsNotNull(presentationModel);
        }
    }
}

namespace DrawingApp.PresentationModel.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        Model model;
        PresentationModel presentationModel;

        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
        }

        [TestMethod()]
        public void PresentationModelTest()
        {
            Assert.IsNotNull(presentationModel);
        }

        [TestMethod()]
        public void DrawTest()
        {
            model.Draw(new UnitTest.FakeAdapter.FakeAdapter());
            Assert.IsNotNull(presentationModel);
        }
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
            Assert.AreEqual(model.CurrentMode, 999);
        }

        [TestMethod()]
        public void PressPointerTest()
        {
            model.CurrentMode = 999;
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
            model.Draw(new UnitTest.FakeAdapter.FakeAdapter());
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
            Assert.AreEqual(model.CurrentMode, 999);
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
            model.Draw(new UnitTest.FakeAdapter.FakeAdapter());
            
        }

        public void EventHandler()
        {
            Assert.IsTrue(true);
        }
    }
}
