using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Line : IShape
    {
        public double X1
        {
            get; set;
        }

        public double Y1
        {
            get; set;
        }

        public double X2
        {
            get; set;
        }

        public double Y2
        {
            get; set;
        }

        // 畫線
        public void Draw(IGraphics graphics)
        {
            graphics.DrawLine(X1, Y1, X2, Y2);
        }

        // 畫線框
        public void DrawFrame(IGraphics graphics)
        {
            graphics.DrawLineFrame(X1, Y1, X2, Y2);
        }

        // 被選取
        public bool IsSelect(double x, double y)
        {
            return GetDistanceFromPointToLine(x, y) < (int)3m && x >= Math.Min(X1, X2) && x <= Math.Max(X1, X2) && y >= Math.Min(Y1, Y2) && y <= Math.Max(Y1, Y2);
        }

        // 點到線的距離
        private double GetDistanceFromPointToLine(double x, double y)
        {
            return Math.Abs((X2 - X1) * (Y1 - y) - (X1 - x) * (Y2 - Y1)) / Math.Sqrt(Math.Pow(X2 - X1, (int)2m) + Math.Pow(Y2 - Y1, (int)2m));
        }
    }
}
