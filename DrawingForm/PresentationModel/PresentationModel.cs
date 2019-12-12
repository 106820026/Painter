﻿using DrawingModel;
using System;

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

        public string SelectShape(double x, double y)
        {
            foreach (Shape aShape in _model.GetTotalShapes())
            {
                
            }
            return "Null";
        }
    }
}
