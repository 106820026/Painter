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
    public class ResizeCommandTests
    {
        Model model;
        IShape originalShape;
        IShape resizeShape;
        int index;
        CommandManager commandManager;
        ResizeCommand resizeCommand;

        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            originalShape = new Rectangle(0, 0, 1, 1);
            resizeShape = new Rectangle(0, 0, 100, 100);
            index = 0;
            resizeCommand = new ResizeCommand(model, originalShape, resizeShape, index);
            commandManager = new CommandManager();
        }

        [TestMethod()]
        public void ResizeCommandTest()
        {
            Assert.IsNotNull(resizeCommand);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            model.GetTotalShapes.Add(new Rectangle(0, 0, 1, 1));
            resizeCommand.Execute();
            Assert.AreEqual(model.GetTotalShapes.Count, 1);
        }

        [TestMethod()]
        public void CancelExecuteTest()
        {
            model.GetTotalShapes.Add(new Rectangle(0, 0, 1, 1));
            resizeCommand.CancelExecute();
            Assert.AreEqual(model.GetTotalShapes.Count, 1);
        }
    }
}