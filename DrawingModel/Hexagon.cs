using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Hexagon : Shape
    {
        // 畫六角形
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawHexagon(X1, Y1, X2, Y2);
        }

        // 畫出外框
        public override void DrawFrame(IGraphics graphics)
        {
            graphics.DrawHexagonFrame(X1, Y1, X2, Y2);
        }

        // 被選取
        public override bool IsSelect(double x, double y)
        {
            return x > Math.Min(X1, X2) && x < Math.Max(X1, X2) && y > Math.Min(Y1, Y2) && y < Math.Max(Y1, Y2) && IsInside(x, y);
        }

        // 在線的左邊
        private bool IsInside(double x, double y)
        {
            float height = (float)Math.Abs(Y2 - Y1) / (int)2m;
            float width = (float)Math.Abs(X2 - X1) / (int)4m;
            double initialY = (Y1 + Y2) / (int)2m;
            if (X2 - X1 < 0)
                width = -width;
            return (y - initialY) / height * width + X1 < x && (y - initialY - height) / (-height) * width + X1 + 3 * width > x && (y - initialY) / (-height) * (-width) + X2 > x && (y - initialY + height) / height * (-width) + X1 + width < x;
        }
    }
}
