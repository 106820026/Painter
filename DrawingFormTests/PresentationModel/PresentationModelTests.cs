using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;

namespace DrawingForm.FakeAdapter
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
            model.Draw(new FakeAdapter.FakeAdapter());
            Assert.IsNotNull(presentationModel);
        }
    }
}