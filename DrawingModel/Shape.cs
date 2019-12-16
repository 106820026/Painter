using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public abstract class Shape
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

        // 畫各種形狀
        public abstract void Draw(IGraphics graphics);
        
        // 畫紅框
        public abstract void DrawFrame(IGraphics graphics);

        // 被選取
        public abstract bool IsSelect(double x, double y);
    }
}
