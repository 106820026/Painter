using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{

    [Serializable]
    public class Rectangle : IShape
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

        public Rectangle()
        {

        }

        public Rectangle(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        // 畫矩形
        public void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X1, Y1, X2, Y2);
        }

        // 畫矩形外框
        public void DrawFrame(IGraphics graphics)
        {
            graphics.DrawRectangleFrame(X1, Y1, X2, Y2);
        }

        // 被選取
        public bool IsSelect(double x, double y)
        {
            return x > Math.Min(X1, X2) && x < Math.Max(X1, X2) && y > Math.Min(Y1, Y2) && y < Math.Max(Y1, Y2);
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
