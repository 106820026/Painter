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
        public void DrawingTest()
        {
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.Draw(new FakeAdaptor());
            model.ReleasePointer(90, 150);
            model.Draw(new FakeAdaptor());
            model.CurrentMode = -1;
            model.IsSelected = true;
            model.SelectedShape = model.GetTotalShapes[0];
            model.CurrentState = new PointerState(model);
            model.Draw(new FakeAdaptor());
            Assert.AreEqual(model.CurrentMode, -1);
        }

        [TestMethod()]
        public void DrawHintTest()
        {
            model.CurrentMode = 1;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.ReleasePointer(90, 150);
            model.CurrentMode = 1;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(0, 0);
            model.ReleasePointer(0, 0);
            model.CurrentMode = -1;
            model.CurrentState = new PointerState(model);
            model.SelectedShape = model.GetTotalShapes[0];
            model.DrawHint(90, 90, 190, 190);
            model.Draw(new FakeAdaptor());
            model.CurrentMode = 1;
            model.CurrentState = new DrawingState(model);
            model.DrawHint(90, 90, 190, 190);
            model.Draw(new FakeAdaptor());
            Assert.AreEqual(model.CurrentMode, 1);
        }

        [TestMethod()]
        public void ClearTest()
        {
            model.GetTotalShapes.Add(new Line());
            model.Clear();
            Assert.AreEqual(model.CurrentMode, -1);
            model.Clear();
        }

        //[TestMethod()]
        //public void DrawTest()
        //{
        //    model.CurrentMode = 0;
        //    model.PressPointer(90, 150);
        //    model.ReleasePointer(180, 300);
        //    Assert.AreEqual(model.CurrentMode, -1);
        //    model.CurrentMode = 1;
        //    model.PressPointer(90, 150);
        //    model.ReleasePointer(180, 300);
        //    Assert.AreEqual(model.CurrentMode, -1);
        //    model.SelectShape(150, 200);
        //    model.Draw(new FakeAdaptor());

        //}

        [TestMethod()]
        public void DrawShapeTest()
        {
            model.DrawShape(new Line());
            Assert.AreEqual(1, model.GetTotalShapes.Count);
        }

        [TestMethod()]
        public void DeleteShapeTest()
        {
            model.DrawShape(new Line());
            model.DeleteShape();
            Assert.AreEqual(0, model.GetTotalShapes.Count);
        }

        [TestMethod()]
        public void UndoTest()
        {
            Assert.IsFalse(model.IsUndoEnabled);
            model.CurrentMode = 1;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(90, 150);
            model.ReleasePointer(180, 300);
            model.Undo();
            Assert.AreEqual(0, model.GetTotalShapes.Count);
        }

        [TestMethod()]
        public void RedoTest()
        {
            Assert.IsFalse(model.IsRedoEnabled);
            model.CurrentMode = 1;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(90, 150);
            model.ReleasePointer(180, 300);
            model.Undo();
            model.Redo();
            Assert.AreEqual(1, model.GetTotalShapes.Count);
        }

        [TestMethod()]
        public void SelectShapeTest()
        {
            model.CurrentMode = 1;
            model.SelectShape(100, 100);
            Assert.AreEqual(1, model.CurrentMode);
        }

        public void EventHandler()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void GetSelectedShapeIndexTest()
        {
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.ReleasePointer(90, 150);
            model.SelectedShape = model.GetTotalShapes[0];
            Assert.AreEqual(model.GetSelectedShapeIndex(), 0);
        }

        [TestMethod()]
        public void RemoveSelectedShapeFromTotalShapesTest()
        {
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.ReleasePointer(90, 150);
            model.SelectedShape = model.GetTotalShapes[0];
            model.RemoveSelectedShapeFromTotalShapes();
            Assert.AreEqual(model.GetTotalShapes.Count, 0);
        }

        [TestMethod()]
        public void InsertSelectedShapeFromTotalShapesTest()
        {
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.ReleasePointer(90, 150);
            model.SelectedShape = model.GetTotalShapes[0];
            model.InsertSelectedShapeFromTotalShapes(0);
            Assert.AreEqual(model.GetTotalShapes.Count, 2);
        }

        [TestMethod()]
        public void ResizeOriginalShapeTest()
        {
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.ReleasePointer(90, 150);
            model.ResizeOriginalShape(new Rectangle(0, 0, 200, 200), 0);
            Assert.AreEqual(model.GetTotalShapes.Count, 1);
        }

        [TestMethod()]
        public void RecoverOriginalShapeTest()
        {
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.ReleasePointer(90, 150);
            model.RecoverOriginalShape(new Rectangle(0, 0, 200, 200), 0);
            Assert.AreEqual(model.GetTotalShapes.Count, 1);
        }

        [TestMethod()]
        public void ResizeShapeTest()
        {
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.ReleasePointer(90, 150);
            model.ResizeShape(new Rectangle(0, 0, 200, 200), new Rectangle(0, 0, 100, 100), 0);
            Assert.AreEqual(model.GetTotalShapes.Count, 1);
        }

        [TestMethod()]
        public void SelectShapeTest1()
        {
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(550, 550);
            model.MovePointer(660, 660);
            model.ReleasePointer(660, 660);
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.ReleasePointer(90, 150);
            model.SelectShape(60, 60);
            Assert.AreEqual(model.SelectShape(60, 60), "Rectangle(0,0,90,150)");
        }
    }
}