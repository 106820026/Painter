using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModelCommandManagerTest.FakeAdaptor
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
    public class CommandManagerTests
    {
        CommandManager commandManager;
        Model model;

        [TestInitialize]
        public void Initialize()
        {
            commandManager = new CommandManager();
            model = new Model();
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            Line line = new Line();
            line.Draw(new FakeAdaptor());
            commandManager.Execute(new ClearCommand(model, model.GetTotalShapes));
            Assert.IsNotNull(line);
        }

        [TestMethod()]
        public void UndoTest()
        {
            Assert.IsFalse(commandManager.IsRedoEnabled);
            Assert.ThrowsException<System.Exception>(() => model.Undo());
            model.CurrentMode = 1;
            model.PressPointer(90, 150);
            model.ReleasePointer(180, 300);
            model.Draw(new FakeAdaptor());
            model.Undo();
            Assert.AreEqual(model.GetTotalShapes.Count, 0);
        }

        [TestMethod()]
        public void RedoTest()
        {
            Assert.IsFalse(commandManager.IsUndoEnabled);
            Assert.ThrowsException<System.Exception>(() => model.Redo());
            model.CurrentMode = 1;
            model.PressPointer(90, 150);
            model.ReleasePointer(180, 300);
            model.Draw(new FakeAdaptor());
            model.Undo();
            model.Redo();
            Assert.AreEqual(model.GetTotalShapes.Count, 1);
        }
    }
}