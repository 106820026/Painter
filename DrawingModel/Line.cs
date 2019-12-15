using System;
using System.Collections.Generic;
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
    }
}
