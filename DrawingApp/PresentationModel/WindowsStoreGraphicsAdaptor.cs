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
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }

        // 畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Colors.Aqua);
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
            _canvas.Children.Add(rectangle);
            rectangle.Fill = myBrush;
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
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Tomato);
            SolidColorBrush myStroke = new SolidColorBrush(Colors.Black);
            float height = (float)Math.Abs(y2 - y1);
            float width = (float)Math.Abs(x2 - x1);
            float deltaHeight = height / 2;
            float edge = width / 13 * 5;
            float deltaWidth = (width - edge) / 2;
            if (x2 - x1 < 0)
            {
                edge = -edge;
                deltaWidth = -deltaWidth;
            }
            Polygon hexagon = new Polygon();
            PointCollection points = new PointCollection();
            points.Add(new Point(x1, y1));
            points.Add(new Point(x1 + deltaWidth, y1 + deltaHeight));
            points.Add(new Point(x1 + deltaWidth + edge, y1 + deltaHeight));
            points.Add(new Point(x2, y1));
            points.Add(new Point(x1 + deltaWidth + edge, y1 - deltaHeight));
            points.Add(new Point(x1 + deltaWidth, y1 - deltaHeight));
            hexagon.Points = points;
            hexagon.Fill = myBrush;
            hexagon.Stroke = myStroke;
            hexagon.StrokeThickness = 1;
            _canvas.Children.Add(hexagon);
        }
    }
}