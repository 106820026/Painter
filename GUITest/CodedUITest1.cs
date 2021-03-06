﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Windows.UI.Xaml.Controls;

namespace GUITest
{
    /// <summary>
    /// CodedUITest1 的摘要說明
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestInitialize]
        public void Initialize()
        {
            Robot.Initialize(@"..\..\..\DrawingForm\bin\Debug\DrawingForm.exe", "Painter");
        }

        [TestMethod]
        public void DrawRectangleTest()
        {
            // 若要為這個測試產生程式碼，請在捷徑功能表上選取 [產生自動程式化 UI 測試的程式碼]，並選取其中一個功能表項目。
            DrawingToolTest.DrawRectangle("canvas", 200, 200, 300, 300);
        }

        [TestMethod]
        public void DrawLineTest()
        {
            DrawingToolTest.DrawLine("canvas", 200, 200, 300, 300);
        }

        [TestMethod]
        public void DrawHexagonTest()
        {
            DrawingToolTest.DrawHexagon("canvas", 200, 200, 300, 300);
        }

        [TestMethod]
        public void ClickClearTest()
        {
            DrawingToolTest.ClickClear();
        }

        [TestMethod]
        public void DrawHouse()
        {
            DrawingToolTest.DrawHexagon("canvas", 600, 200, 700, 250);
            DrawingToolTest.DrawLine("canvas", 475, 200, 350, 350);
            DrawingToolTest.DrawLine("canvas", 475, 200, 600, 350);
            DrawingToolTest.DrawRectangle("canvas", 350, 350, 600, 550);
            DrawingToolTest.DrawRectangle("canvas", 600, 220, 610, 365);
            DrawingToolTest.DrawRectangle("canvas", 400, 400, 430, 430);
            DrawingToolTest.DrawRectangle("canvas", 450, 400, 480, 430);
            DrawingToolTest.DrawRectangle("canvas", 425, 440, 470, 500);
            DrawingToolTest.DrawRectangle("canvas", 510, 390, 520, 435);
            DrawingToolTest.DrawRectangle("canvas", 530, 375, 540, 430);
            DrawingToolTest.DrawRectangle("canvas", 550, 395, 565, 460);
            DrawingToolTest.MouseDragging("canvas", 565, 460, 570, 465);
            Robot.ClickButton("Undo");
            Robot.ClickButton("Redo");
            Robot.ClickButton("Save");
            Robot.ClickButton("是(Y)");
            UITestControl canvas = Robot.FindPanel("canvas");
            Mouse.Click(canvas, new Point(650, 225));
            Robot.AssertText("_shapePositionTextLabel", "Hexagon(600,200,700,250)");
            DrawingToolTest.ClickClear();
            Robot.ClickButton("Load");
            Robot.ClickButton("是(Y)");
            Mouse.Click(canvas, new Point(650, 225));
            Robot.AssertText("_shapePositionTextLabel", "Hexagon(600,200,700,250)");
            DrawingToolTest.ClickClear();
        }

        [TestMethod]
        public void UndoTest()
        {
            DrawingToolTest.DrawHexagon("canvas", 250, 250, 600, 600);
            Robot.ClickButton("Undo");
        }

        [TestMethod]
        public void RedoTest()
        {
            DrawingToolTest.DrawHexagon("canvas", 250, 250, 600, 600);
            Robot.ClickButton("Undo");
            Robot.ClickButton("Redo");
        }

        [TestMethod]
        public void SelectShapeTest()
        {
            DrawingToolTest.DrawHexagon("canvas", 250, 250, 600, 600);
            UITestControl canvas = Robot.FindPanel("canvas");
            Mouse.Click(canvas, new Point(500, 500));
            Robot.AssertText("_shapePositionTextLabel", "Hexagon(250,250,600,600)");
        }

        [TestMethod]
        public void ResizeShapeTest()
        {
            DrawingToolTest.DrawRectangle("canvas", 250, 250, 600, 600);
            DrawingToolTest.MouseDragging("canvas", 600, 600, 700, 700);
            UITestControl canvas = Robot.FindPanel("canvas");
            Mouse.Click(canvas, new Point(650, 650));
            Robot.AssertText("_shapePositionTextLabel", "Hexagon(250,250,700,700)");
            Robot.ClickButton("Undo");
            Robot.AssertText("_shapePositionTextLabel", "Hexagon(250,250,600,600)");
            Robot.ClickButton("Redo");
            Robot.AssertText("_shapePositionTextLabel", "Hexagon(250,250,700,700)");
        }

        #region 其他測試屬性

        // 您可以使用下列其他屬性撰寫測試: 

        ////在每項測試執行前先使用 TestInitialize 執行程式碼 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // 若要為這個測試產生程式碼，請在捷徑功能表上選取 [產生自動程式化 UI 測試的程式碼]，並選取其中一個功能表項目。
        //}

        ////在每項測試執行後使用 TestCleanup 執行程式碼
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // 若要為這個測試產生程式碼，請在捷徑功能表上選取 [產生自動程式化 UI 測試的程式碼]，並選取其中一個功能表項目。
        //}

        #endregion

        /// <summary>
        ///取得或設定提供目前測試回合
        ///相關資訊與功能的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
