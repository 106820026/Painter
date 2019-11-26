using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;
using System;

namespace DrawingApp.PresentationModel
{
    class WindowsStoreGraphicsAdaptor : IGraphics
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
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = new SolidColorBrush(Colors.Black)
            };
            _canvas.Children.Add(line);
        }

        // 畫矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Rectangle rectangle = new Windows.UI.Xaml.Shapes.Rectangle
            {
                Width = Math.Abs(x2 - x1),
                Height = Math.Abs(y2 - y1),
                Stroke = new SolidColorBrush(Colors.Black)
            };
            if (x2 > x1 && y2 > y1)
            {
                Canvas.SetLeft(rectangle, x1);
                Canvas.SetTop(rectangle, y1);
            }
            if (x2 < x1 && y2 > y1)
            {
                Canvas.SetLeft(rectangle, x2);
                Canvas.SetTop(rectangle, y1);
            }
            if (x2 > x1 && y2 < y1)
            {
                Canvas.SetLeft(rectangle, x1);
                Canvas.SetTop(rectangle, y2);
            }
            if (x2 < x1 && y2 < y1)
            {
                Canvas.SetLeft(rectangle, x2);
                Canvas.SetTop(rectangle, y2);
            }
            _canvas.Children.Add(rectangle);
        }
    }
}
