using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Line : Shape
    {
        // 畫線
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_x1, _y1, _x2, _y2);
        }
    }
}
