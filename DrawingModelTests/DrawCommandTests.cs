using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        Model model;
        Line line;
        DrawCommand drawCommand;

        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            line = new Line();
        }

        [TestMethod()]
        public void DrawCommandTest()
        {
            drawCommand = new DrawCommand(model, line);
            Assert.IsNotNull(model);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            model.CurrentMode = 0;
            model.PressPointer(90, 150);
            model.ReleasePointer(190, 250);
            drawCommand = new DrawCommand(model, model.GetTotalShapes[0]);
            drawCommand.CancelExecute();
            drawCommand.Execute();
            Assert.AreEqual(1, model.GetTotalShapes.Count);
        }

        [TestMethod()]
        public void CancelExecuteTest()
        {
            model.CurrentMode = 0;
            model.PressPointer(90, 150);
            model.ReleasePointer(190, 250);
            drawCommand = new DrawCommand(model, model.GetTotalShapes[0]);
            drawCommand.CancelExecute();
            Assert.AreEqual(0, model.GetTotalShapes.Count);
        }
    }
}