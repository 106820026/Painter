using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Hexagon : Shape
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

        // 畫六角形
        public void Draw(IGraphics graphics)
        {
            graphics.DrawHexagon(X1, Y1, X2, Y2);
        }

        // 畫出外框
        public void DrawFrame(IGraphics graphics)
        {
            graphics.DrawHexagonFrame(X1, Y1, X2, Y2);
        }

        // 被選取
        public bool IsSelect(double x, double y)
        {
            return x > Math.Min(X1, X2) && x < Math.Max(X1, X2) && y > Math.Min(Y1, Y2) && y < Math.Max(Y1, Y2) && IsInside(x, y);
        }

        // 在四條斜線內
        private bool IsInside(double x, double y)
        {
            float height = (float)Math.Abs(Y2 - Y1) / (int)2m;
            float width = (float)Math.Abs(X2 - X1) / (int)4m;
            double initialY = (Y1 + Y2) / (int)2m;
            if (X2 > X1)
                return (y - initialY) / height * width + X1 < x && (y - initialY - height) / (-height) * width + X1 + (int)3m * width > x && (y - initialY) / (-height) * (-width) + X2 > x && (y - initialY + height) / height * (-width) + X1 + width < x;
            else
                return (y - initialY) / height * width + X2 < x && (y - initialY - height) / (-height) * width + X2 + (int)3m * width > x && (y - initialY) / (-height) * (-width) + X1 > x && (y - initialY + height) / height * (-width) + X2 + width < x;
        }
    }
}
