using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingForm.PresentationModel
{
    public class PresentationModel
    {
        Model _model;
        public PresentationModel(Model model)
        {
            this._model = model;
        }

        // 畫圖
        public void Draw(IGraphics adaptor)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(adaptor);
        }

        // 選取形狀
        public string SelectShape(double x, double y)
        {
            List<Shape> shape = _model.GetTotalShapes();
            for (int i = shape.Count - 1; i >= 0; i--)
            {
                if (shape[i].GetType() == Type.GetType("DrawingModel.Rectangle"))
                    if (SelectRectangle(shape[i], x, y))
                        return GetDetail(shape[i]);
                if (shape[i].GetType() == Type.GetType("DrawingModel.Line"))
                    if (SelectLine(shape[i], x, y))
                        return GetDetail(shape[i]);
                if (shape[i].GetType() == Type.GetType("DrawingModel.Hexagon"))
                    if (SelectHexagon(shape[i], x, y))
                        return GetDetail(shape[i]);
            }
            _model.IsSelected = false;
            return "Null";
        }

        // 選到矩形
        private bool SelectRectangle(Shape shape, double x, double y)
        {
            double x1 = shape.X1;
            double y1 = shape.Y1;
            double x2 = shape.X2;
            double y2 = shape.Y2;
            return x > Math.Min(x1, x2) && x < Math.Max(x1, x2) && y > Math.Min(y1, y2) && y < Math.Max(y1, y2);
        }

        // 選到線
        private bool SelectLine(Shape shape, double x, double y)
        {
            double x1 = shape.X1;
            double y1 = shape.Y1;
            double x2 = shape.X2;
            double y2 = shape.Y2;
            return DistanceFromPointToLine(shape, x, y) < 3 && x >= Math.Min(x1, x2) && x <= Math.Max(x1, x2) && y >= Math.Min(y1, y2) && y <= Math.Max(y1, y2);
        }

        // 點到線的距離
        private static double DistanceFromPointToLine(Shape shape, double x, double y)
        {
            return Math.Abs((shape.X2 - shape.X1) * (shape.Y1 - y) - (shape.X1 - x) * (shape.Y2 - shape.Y1)) / Math.Sqrt(Math.Pow(shape.X2 - shape.X1, 2) + Math.Pow(shape.Y2 - shape.Y1, 2));
        }

        // 選到六邊形
        private bool SelectHexagon(Shape shape, double x, double y)
        {
            double x1 = shape.X1;
            double y1 = shape.Y1;
            double x2 = shape.X2;
            double y2 = shape.Y2;
            float width = (float)Math.Abs(x2 - x1);
            float height = (float)Math.Abs(y2 - y1);
            float edge = width / 13 * 5;
            float deltaWidth = (width - edge) / 2;
            if (x2 - x1 < 0)
            {
                edge = -edge;
                deltaWidth = -deltaWidth;
            }
            float deltaHeight = height / 2;
            return x > Math.Min(x1, x2) && x < Math.Max(x1, x2) && y > Math.Min(y1, y2) && y < Math.Max(y1, y2);
        }

        private static double DistanceFromPointToLine(Point point1, Point point2, double x, double y)
        {
            return Math.Abs((point2.X - point1.X) * (point1.Y - y) - (point1.X - x) * (point2.Y - point1.Y)) / Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        // 取得選取圖形的詳細資料
        private String GetDetail(Shape shape)
        {
            _model.IsSelected = true;
            _model.SelectedShape = shape;
            return shape.GetType().ToString().Replace("DrawingModel.", "") + " ( " + shape.X1 + ", " + shape.Y1 + "," + shape.X2 + "," + shape.Y2 + ")";
        }
    }
}
