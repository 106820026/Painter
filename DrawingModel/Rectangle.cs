using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Rectangle : Shape
    {
        // 畫矩形
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X1, Y1, X2, Y2);
        }

        // 畫矩形外框
        public override void DrawFrame(IGraphics graphics)
        {
            graphics.DrawRectangleFrame(X1, Y1, X2, Y2);
        }

        // 被選取
        public override bool IsSelect(Point point)
        {
            return point.X > Math.Min(X1, X2) && point.X < Math.Max(X1, X2) && point.Y > Math.Min(Y1, Y2) && point.Y < Math.Max(Y1, Y2);
        }
    }
}
