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

        public Line()
        {

        }

        public Line(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
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

        // 初始化圖形
        public void InitialShape()
        {
            X1 = X1;
            Y1 = Y1;
            X2 = X1;
            Y2 = Y1;
        }
    }
}
