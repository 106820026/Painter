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
    public class ShapeFactoryTests
    {

        [TestMethod()]
        public void CreateShapeTest()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Rectangle rectangle = new Rectangle();
            Line line = new Line();
            Hexagon hexagon = new Hexagon();
            Assert.AreEqual(shapeFactory.CreateShape(0).GetType(), rectangle.GetType());
            Assert.AreEqual(shapeFactory.CreateShape(1).GetType(), line.GetType());
            Assert.AreEqual(shapeFactory.CreateShape(2).GetType(), hexagon.GetType());
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => shapeFactory.CreateShape(3));
        }

        [TestMethod()]
        public void CreateShapeTest1()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Rectangle rectangle = new Rectangle(0,0,1,1);
            Line line = new Line(0, 0, 1, 1);
            Hexagon hexagon = new Hexagon(0, 0, 1, 1);
            Assert.AreEqual(shapeFactory.CreateShape(rectangle).GetType(), rectangle.GetType());
            Assert.AreEqual(shapeFactory.CreateShape(line).GetType(), line.GetType());
            Assert.AreEqual(shapeFactory.CreateShape(hexagon).GetType(), hexagon.GetType());
        }
    }
}