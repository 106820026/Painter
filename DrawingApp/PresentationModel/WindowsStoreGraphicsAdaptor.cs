using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using DrawingModel;
using System;

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
        }

        // 設定左上角座標
        private void SetTopLeft(Windows.UI.Xaml.Shapes.Rectangle rectangle, double top, double left)
        {
            Canvas.SetTop(rectangle, top);
            Canvas.SetLeft(rectangle, left);
        }
    }
}
