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
        public string SelectShape(Point point)
        {
            List<Shape> shape = _model.GetTotalShapes();
            for (int i = shape.Count - 1; i >= 0; i--)
                if(shape[i].IsSelect(point))
                    return GetDetail(shape[i]);
            _model.IsSelected = false;
            return "Null";
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
