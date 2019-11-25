using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    interface IGraphics
    {
        void DrawRectangle(double x1, double y1, double x2, double y2);
        void DrawLine(double x1, double y1, double x2, double y2);
        void ClearAll();
    }
}
