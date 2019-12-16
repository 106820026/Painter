using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;
using System;
using Windows.Foundation;

namespace DrawingApp.PresentationModel
{
    public class WindowsStoreGraphicsAdaptor : IGraphics
    {
        Canvas _canvas;
        public WindowsStoreGraphicsAdaptor(Canvas canvas)
        {
            this._canvas = canvas;
        }

        // 全部清除
        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        // 畫線
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = LinkPointToLine(x1, y1, x2, y2);
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        // 連線的點
        private Windows.UI.Xaml.Shapes.Line LinkPointToLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            return line;
        }

        // 畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = LinkPointToRectangle(x1, y1, x2, y2);
            rectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Aqua);
            _canvas.Children.Add(rectangle);
        }

        // 連矩形的點
        private Windows.UI.Xaml.Shapes.Rectangle LinkPointToRectangle(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = Math.Abs(x2 - x1);
            rectangle.Height = Math.Abs(y2 - y1);
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            if (x2 > x1 && y2 > y1)
                this.SetTopLeft(rectangle, y1, x1);
            if (x2 < x1 && y2 > y1)
                this.SetTopLeft(rectangle, y1, x2);
            if (x2 > x1 && y2 < y1)
                this.SetTopLeft(rectangle, y2, x1);
            if (x2 < x1 && y2 < y1)
                this.SetTopLeft(rectangle, y2, x2);
            return rectangle;
        }

        // 設定左上角座標
        private void SetTopLeft(Windows.UI.Xaml.Shapes.Rectangle rectangle, double top, double left)
        {
            Canvas.SetTop(rectangle, top);
            Canvas.SetLeft(rectangle, left);
        }

        // 畫六角形
        public void DrawHexagon(double x1, double y1, double x2, double y2)
        {
            Polygon hexagon = LinkPointToHexagon(x1, y1, x2, y2);
            hexagon.Fill = new SolidColorBrush(Colors.Tomato);
            hexagon.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(hexagon);
        }

        // 連六角形點
        private Polygon LinkPointToHexagon(double x1, double y1, double x2, double y2)
        {
            float height = (float)Math.Abs(y2 - y1) / (int)2m;
            float width = (float)Math.Abs(x2 - x1) / (int)4m;
            double initialY = (y1 + y2) / (int)2m;
            if (x2 - x1 < 0)
                width = -width;
            Polygon hexagon = new Polygon();
            PointCollection points = new PointCollection();
            points.Add(new Point(x1, initialY));
            points.Add(new Point(x1 + width, initialY + height));
            points.Add(new Point(x1 + width * (int)3m, initialY + height));
            points.Add(new Point(x2, initialY));
            points.Add(new Point(x1 + width * (int)3m, initialY - height));
            points.Add(new Point(x1 + width, initialY - height));
            hexagon.Points = points;
            return hexagon;
        }

        // 畫矩形框
        public void DrawRectangleFrame(double x1, double y1, double x2, double y2)
        {

        }

        public void DrawLineFrame(double x1, double y1, double x2, double y2)
        {

        }

        public void DrawHexagonFrame(double x1, double y1, double x2, double y2)
        {

        }
    }
}