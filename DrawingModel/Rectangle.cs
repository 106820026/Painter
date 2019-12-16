using System;
using System.Collections.Generic;
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
        public override bool IsSelect(double x, double y)
        {
            return x> Math.Min(X1, X2) && x < Math.Max(X1, X2) && y > Math.Min(Y1, Y2) && y < Math.Max(Y1, Y2);
        }
    }
}
