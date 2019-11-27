using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUITest
{
    class DrawingToolTest
    {
        //name 為panel AccessibleName
        public static void DrawRectangle(string name, int x1, int y1, int x2, int y2)
        {
            ClickButton("Rectangle");
            UITestControl canvas = Robot.FindPanel(name);
            Mouse.StartDragging(canvas, new Point(x1, y1));
            Mouse.StopDragging(canvas, new Point(x2, y2));
        }

        public static void DrawLine(string name, int x1, int y1, int x2, int y2)
        {
            ClickButton("Line");
            UITestControl canvas = Robot.FindPanel(name);
            Mouse.StartDragging(canvas, new Point(x1, y1));
            Mouse.StopDragging(canvas, new Point(x2, y2));
        }

        public static void ClickClear()
        {
            ClickButton("Clear");
        }

        //Using Robot to ClickButton
        private static void ClickButton(string buttonText)
        {
            Robot.ClickButton(buttonText);
        }
    }
}