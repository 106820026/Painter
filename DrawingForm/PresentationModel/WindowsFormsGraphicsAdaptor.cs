using System.Windows.Forms;
using System.Drawing;
using DrawingModel;
using System;

namespace DrawingForm.PresentationModel
{
    public class WindowsFormsGraphicsAdaptor : IGraphics
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
            SolidBrush myBrush = new SolidBrush(Color.Aqua);
            float width = (float)Math.Abs(x2 - x1);
            float height = (float)Math.Abs(y2 - y1);
            _graphics.FillRectangle(myBrush, (float)x1, (float)y1, width, height);
            if (x2 > x1 && y2 > y1)
                _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, width, height);
            if (x2 < x1 && y2 > y1)
                _graphics.DrawRectangle(Pens.Black, (float)x2, (float)y1, width, height);
            if (x2 > x1 && y2 < y1)
                _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y2, width, height);
            if (x2 < x1 && y2 < y1)
                _graphics.DrawRectangle(Pens.Black, (float)x2, (float)y2, width, height);
        }
         
        // 畫六角形
        public void DrawHexagon(double x1, double y1, double x2, double y2)
        {
            float width = (float)Math.Abs(x2 - x1);
            float height = (float)Math.Abs(y2 - y1);
            float edge = width / 13 * 5;
            float deltaWidth = (width - edge) / 2;
            y1 = (y1 + y2) / 2; //平行向下移
            if (x2 - x1 < 0) {
                edge = -edge;
                deltaWidth = -deltaWidth;
            }
            float deltaHeight = height / 2;
            SolidBrush myBrush = new SolidBrush(Color.Tomato);
            Point[] points = new Point[6] { new Point((int)x1, (int)y1), new Point((int)(x1 + deltaWidth), (int)(y1 + deltaHeight)), new Point((int)(x1 + deltaWidth + edge), (int)(y1 + deltaHeight)), new Point((int)x2, (int)y1), new Point((int)(x1 + deltaWidth + edge), (int)(y1 - deltaHeight)), new Point((int)(x1 + deltaWidth), (int)(y1 - deltaHeight)) };
            _graphics.FillPolygon(myBrush, points);
            DrawLine(x1, y1, x1 + deltaWidth, y1 + deltaHeight);
            DrawLine(x1, y1, x1 + deltaWidth, y1 - deltaHeight);
            DrawLine(x1 + deltaWidth, y1 + deltaHeight, x1 + deltaWidth + edge, y1 + deltaHeight);
            DrawLine(x1 + deltaWidth, y1 - deltaHeight, x1 + deltaWidth + edge, y1 - deltaHeight);
            DrawLine(x1 + deltaWidth + edge, y1 + deltaHeight, x2, y1);
            DrawLine(x1 + deltaWidth + edge, y1 - deltaHeight, x2, y1);
        }
    }
}