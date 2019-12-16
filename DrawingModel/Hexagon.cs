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

        //public override bool IsSelect(Point point)
        //{
        //    float width = (float)Math.Abs(x2 - x1);
        //    float height = (float)Math.Abs(y2 - y1);
        //    float edge = width / 13 * 5;
        //    float deltaWidth = (width - edge) / 2;
        //    double initialY = (y1 + y2) / 2; //平行向下移
        //    if (x2 - x1 < 0)
        //    {
        //        edge = -edge;
        //        deltaWidth = -deltaWidth;
        //    }
        //    float deltaHeight = height / 2;
        //    return x > Math.Min(x1, x2) && x < Math.Max(x1, x2) && y > Math.Min(y1, y2) && y < Math.Max(y1, y2) && !IsLeft(new Point((int)x1, (int)initialY), new Point((int)(x1 + deltaWidth), (int)(initialY - deltaHeight)), new Point((int)x, (int)y)) && !IsLeft(new Point((int)x1, (int)initialY), new Point((int)(x1 + deltaWidth), (int)(initialY + deltaHeight)), new Point((int)x, (int)y)) && !IsLeft(new Point((int)x1, (int)initialY), new Point((int)(x1 + deltaWidth), (int)(initialY - deltaHeight)), new Point((int)x, (int)y)) && IsLeft(new Point((int)(x1 + deltaWidth + edge), (int)(initialY + deltaHeight)), new Point((int)x2, (int)initialY), new Point((int)x, (int)y)) && IsLeft(new Point((int)(x1 + deltaWidth + edge), (int)(initialY - deltaHeight)), new Point((int)x2, (int)initialY), new Point((int)x, (int)y));
        //}

        //private static bool IsLeft(PointF linePointA, PointF linePointB, PointF targetPoint)
        //{
        //    return (targetPoint.Y - linePointA.Y) / (linePointB.Y - linePointA.Y) * (linePointB.X - linePointA.X) + linePointA.X > targetPoint.X;
        //}
    }
}
