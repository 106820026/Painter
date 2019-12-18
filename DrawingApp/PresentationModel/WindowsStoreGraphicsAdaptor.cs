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
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.Fill = new SolidColorBrush(Windows.UI.Colors.Aqua);
            _canvas.Children.Add(rectangle);
        }

        // 連矩形的點
        private Windows.UI.Xaml.Shapes.Rectangle LinkPointToRectangle(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle();
            rectangle.Width = Math.Abs(x2 - x1);
            rectangle.Height = Math.Abs(y2 - y1);
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
            if (y2 - y1 < 0)
                height = -height;
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
            Windows.UI.Xaml.Shapes.Rectangle rectangle = LinkPointToRectangle(x1, y1, x2, y2);
            rectangle.Stroke = new SolidColorBrush(Colors.Red);
            rectangle.StrokeThickness = (int)3m;
            rectangle.StrokeDashArray = new DoubleCollection();
            rectangle.StrokeDashArray.Add(1);
            rectangle.StrokeDashArray.Add((int)2m);
            _canvas.Children.Add(rectangle);
            DrawAnglePoint(x1, y1);
            DrawAnglePoint(x2, y1);
            DrawAnglePoint(x1, y2);
            DrawAnglePoint(x2, y2);
        }

        // 畫線框
        public void DrawLineFrame(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = LinkPointToLine(x1, y1, x2, y2);
            line.Stroke = new SolidColorBrush(Colors.Red);
            line.StrokeThickness = (int)3m;
            line.StrokeDashArray = new DoubleCollection();
            line.StrokeDashArray.Add(1);
            line.StrokeDashArray.Add((int)2m);
            DrawAnglePoint(x1, y1);
            DrawAnglePoint(x2, y2);
            _canvas.Children.Add(line);
        }

        // 畫六角形框
        public void DrawHexagonFrame(double x1, double y1, double x2, double y2)
        {
            DrawRectangleFrame(x1, y1, x2, y2);
        }

        // 畫白點
        private void DrawAnglePoint(double x, double y)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush(Colors.White);
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Width = (int)10m;
            ellipse.Height = (int)10m;
            ellipse.RenderTransform = new TranslateTransform() { X = x - (int)5m, Y = y - (int)5m };
            _canvas.Children.Add(ellipse);
        }
    }
}