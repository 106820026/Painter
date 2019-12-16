using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : Shape
    {
        // 畫線
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(X1, Y1, X2, Y2);
        }

        // 畫線框
        public override void DrawFrame(IGraphics graphics)
        {
            graphics.DrawLineFrame(X1, Y1, X2, Y2);
        }

        // 被選取
        public override bool IsSelect(Point point)
        {
            return DistanceFromPointToLine(point.X, point.Y) < 3 && point.X >= Math.Min(X1, X2) && point.X <= Math.Max(X1, X2) && point.Y >= Math.Min(Y1, Y2) && point.Y <= Math.Max(Y1, Y2);
        }

        // 點到線的距離
        private double DistanceFromPointToLine(double x, double y)
        {
            return Math.Abs((X2 - X1) * (Y1 - y) - (X1 - x) * (Y2 - Y1)) / Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
        }
    }
}
