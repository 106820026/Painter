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
            float width = (float)Math.Abs(x2 - x1);
            float height = (float)Math.Abs(y2 - y1);
            if (x2 > x1 && y2 > y1)
                DrawAndFillRectangle((float)x1, (float)y1, width, height);
            if (x2 < x1 && y2 > y1)
                DrawAndFillRectangle((float)x2, (float)y1, width, height);
            if (x2 > x1 && y2 < y1)
                DrawAndFillRectangle((float)x1, (float)y2, width, height);
            if (x2 < x1 && y2 < y1)
                DrawAndFillRectangle((float)x2, (float)y2, width, height);
        }

        // 矩形畫線+著色
        private void DrawAndFillRectangle(double x, double y, double width, double height)
        {
            SolidBrush myBrush = new SolidBrush(Color.Aqua);
            _graphics.FillRectangle(myBrush, (float)x, (float)y, (float)width, (float)height);
            _graphics.DrawRectangle(Pens.Black, (float)x, (float)y, (float)width, (float)height);
        }

        // 畫六角形
        public void DrawHexagon(double x1, double y1, double x2, double y2)
        {
            float height = (float)Math.Abs(y2 - y1) / (int)2m;
            float width = (float)Math.Abs(x2 - x1) / (int)4m;
            double initialY = (y1 + y2) / (int)2m;
            if (x2 - x1 < 0)
                width = -width;
            SolidBrush myBrush = new SolidBrush(Color.Tomato);
            Point[] points = new Point[(int)6m] { new Point((int)x1, (int)initialY), new Point((int)(x1 + width), (int)(initialY + height)), new Point((int)(x1 + width * (int)3m), (int)(initialY + height)), new Point((int)x2, (int)initialY), new Point((int)(x1 + width * (int)3m), (int)(initialY - height)), new Point((int)(x1 + width), (int)(initialY - height)) };
            _graphics.FillPolygon(myBrush, points);
            _graphics.DrawPolygon(new Pen(Color.Black), points);
        }

        // 畫矩形框
        public void DrawRectangleFrame(double x1, double y1, double x2, double y2)
        {
            float width = (float)Math.Abs(x2 - x1);
            float height = (float)Math.Abs(y2 - y1);
            Pen pen = new Pen(Color.Red);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            if (x2 > x1 && y2 > y1)
                _graphics.DrawRectangle(pen, (float)x1, (float)y1, width, height);
            if (x2 < x1 && y2 > y1)
                _graphics.DrawRectangle(pen, (float)x2, (float)y1, width, height);
            if (x2 > x1 && y2 < y1)
                _graphics.DrawRectangle(pen, (float)x1, (float)y2, width, height);
            if (x2 < x1 && y2 < y1)
                _graphics.DrawRectangle(pen, (float)x2, (float)y2, width, height);
            DrawAnglePoint(x1, y1);
            DrawAnglePoint(x2, y2);
            DrawAnglePoint(x1, y2);
            DrawAnglePoint(x2, y1);
        }

        // 畫線框
        public void DrawLineFrame(double x1, double y1, double x2, double y2)
        {
            Pen pen = new Pen(Color.Red);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            _graphics.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
            DrawAnglePoint(x1, y1);
            DrawAnglePoint(x2, y2);
        }

        // 畫六角形框
        public void DrawHexagonFrame(double x1, double y1, double x2, double y2)
        {
            float width = (float)Math.Abs(x2 - x1);
            float height = (float)Math.Abs(y2 - y1);
            Pen pen = new Pen(Color.Red);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            _graphics.DrawRectangle(pen, (float)x1, (float)y1, width, height);
            DrawAnglePoint(x1, y1);
            DrawAnglePoint(x2, y2);
            DrawAnglePoint(x1, y2);
            DrawAnglePoint(x2, y1);
        }

        // 畫白點
        private void DrawAnglePoint(double x, double y)
        {
            _graphics.FillEllipse(new SolidBrush(Color.White), (float)(x - 2.5d), (float)(y - 2.5d), (int)5m, (int)5m);
            _graphics.DrawEllipse(new Pen(Color.Black), (float)(x - 2.5d), (float)(y - 2.5d), (int)5m, (int)5m);
        }
    }
}