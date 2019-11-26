using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    abstract class Shape
    {
        public double _x1;
        public double _y1;
        public double _x2;
        public double _y2;

        // 畫各種形狀
        public abstract void Draw(IGraphics graphics);
    }
}
