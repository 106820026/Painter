using System;
using System.Collections.Generic;
using System.Drawing;
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
        public override bool IsSelect(Point point)
        {
            float width = (float)Math.Abs(X2 - X1);
            float height = (float)Math.Abs(Y2 - Y1);
            float edge = width / 13 * 5;
            float deltaWidth = (width - edge) / 2;
            double initialY = (Y1 + Y2) / 2; //平行向下移
            if (X2 - X1 < 0)
            {
                edge = -edge;
                deltaWidth = -deltaWidth;
            }
            float deltaHeight = height / 2;
            return point.X > Math.Min(X1, X2) && point.X < Math.Max(X1, X2) && point.Y > Math.Min(Y1, Y2) && point.Y < Math.Max(Y1, Y2) && !IsLeft(new Point((int)X1, (int)initialY), new Point((int)(X1 + deltaWidth), (int)(initialY - deltaHeight)), new Point((int)point.X, (int)point.Y)) && !IsLeft(new Point((int)X1, (int)initialY), new Point((int)(X1 + deltaWidth), (int)(initialY + deltaHeight)), new Point((int)point.X, (int)point.Y)) && !IsLeft(new Point((int)X1, (int)initialY), new Point((int)(X1 + deltaWidth), (int)(initialY - deltaHeight)), new Point((int)point.X, (int)point.Y)) && IsLeft(new Point((int)(X1 + deltaWidth + edge), (int)(initialY + deltaHeight)), new Point((int)X2, (int)initialY), new Point((int)point.X, (int)point.Y)) && IsLeft(new Point((int)(X1 + deltaWidth + edge), (int)(initialY - deltaHeight)), new Point((int)X2, (int)initialY), new Point((int)point.X, (int)point.Y));
        }

        // 在線的左邊
        private static bool IsLeft(PointF linePointA, PointF linePointB, PointF targetPoint)
        {
            return (targetPoint.Y - linePointA.Y) / (linePointB.Y - linePointA.Y) * (linePointB.X - linePointA.X) + linePointA.X > targetPoint.X;
        }
    }
}
