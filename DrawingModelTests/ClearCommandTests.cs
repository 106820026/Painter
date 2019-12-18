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
    public class ClearCommandTests
    {
        Model model;
        List<Shape> shape;
        ClearCommand clearCommand;

        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            shape = new List<Shape>();
        }

        [TestMethod()]
        public void ClearCommandTest()
        {
            shape.Add(new Rectangle());
            shape.Add(new Line());
            clearCommand = new ClearCommand(model, shape);
            Assert.IsNotNull(model);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            model.CurrentMode = 0;
            model.PressPointer(90, 150);
            model.ReleasePointer(190, 250);
            model.CurrentMode = 1;
            model.PressPointer(90, 150);
            model.ReleasePointer(190, 250);
            clearCommand = new ClearCommand(model, model.GetTotalShapes);
            clearCommand.Execute();
            Assert.AreEqual(0, model.GetTotalShapes.Count);
        }

        [TestMethod()]
        public void CancelExecuteTest()
        {
            model.CurrentMode = 0;
            model.PressPointer(90, 150);
            model.ReleasePointer(190, 250);
            model.CurrentMode = 1;
            model.PressPointer(90, 150);
            model.ReleasePointer(190, 250);
            clearCommand = new ClearCommand(model, model.GetTotalShapes);
            clearCommand.Execute();
            clearCommand.CancelExecute();
            Assert.AreEqual(2, model.GetTotalShapes.Count);
        }
    }
}