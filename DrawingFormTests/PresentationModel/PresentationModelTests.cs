using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingModel;

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
            Assert.Fail();
        }
    }
}