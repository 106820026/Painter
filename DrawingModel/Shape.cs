using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface Shape
    {
        double X1
        {
            get; set;
        }

        double Y1
        {
            get; set;
        }

        double X2
        {
            get; set;
        }

        double Y2
        {
            get; set;
        }

        // 畫各種形狀
        void Draw(IGraphics graphics);
        
        // 畫紅框
        void DrawFrame(IGraphics graphics);

        // 被選取
        bool IsSelect(double x, double y);
    }
}
