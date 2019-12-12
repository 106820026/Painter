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
    }
}
