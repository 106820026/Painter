using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Rectangle : Shape
    {
        // 畫
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_x1, _y1, _x2, _y2);
        }
    }
}
