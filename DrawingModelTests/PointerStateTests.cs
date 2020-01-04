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
    public class PointerStateTests
    {
        Model model;
        ShapeFactory shapeFactory;

        [TestInitialize]
        public void Initialize()
        {
            model = new Model();
            shapeFactory = new ShapeFactory();
        }

        [TestMethod()]
        public void PointerStateTest()
        {
            PointerState pointerState = new PointerState(model);
            Assert.IsNotNull(pointerState);
        }

        [TestMethod()]
        public void PressPointerTest()
        {
            model.CurrentMode = 0;
            model.CurrentState = new DrawingState(model);
            model.PressPointer(0, 0);
            model.MovePointer(90, 150);
            model.ReleasePointer(90, 150);
            model.IsSelected = false;
            model.SelectedShape = model.GetTotalShapes[0];
            model.CurrentMode = -1;
            model.CurrentState = new PointerState(model);
            model.PressPointer(90, 150);
            model.MovePointer(100, 160);
            model.ReleasePointer(100, 160);
            model.IsSelected = true;
            model.SelectedShape = model.GetTotalShapes[0];
            model.CurrentMode = -1;
            model.CurrentState = new PointerState(model);
            model.PressPointer(200, 150);
            model.MovePointer(100, 160);
            model.ReleasePointer(100, 160);
            model.IsSelected = true;
            model.SelectedShape = model.GetTotalShapes[0];
            model.CurrentMode = -1;
            model.CurrentState = new PointerState(model);
            model.PressPointer(90, 150);
            model.MovePointer(100, 160);
            model.ReleasePointer(100, 160);
            Assert.AreEqual(model.GetTotalShapes.Count, 1);
        }

        //[TestMethod()]
        //public void MovePointerTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ReleasePointerTest()
        //{
        //    Assert.Fail();
        //}
    }
}