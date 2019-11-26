using System.Windows.Forms;
using System.Drawing;
using DrawingModel;
using System;

namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        // 清除畫面
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        // 畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        // 畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            float width = (float)Math.Abs(x2 - x1);
            float height = (float)Math.Abs(y2 - y1);
            if (x2 > x1 && y2 > y1)
                _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, width, height);
            if (x2 < x1 && y2 > y1)
                _graphics.DrawRectangle(Pens.Black, (float)x2, (float)y1, width, height);
            if (x2 > x1 && y2 < y1)
                _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y2, width, height);
            if (x2 < x1 && y2 < y1)
                _graphics.DrawRectangle(Pens.Black, (float)x2, (float)y2, width, height);
        }
    }
}