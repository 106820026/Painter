using DrawingModel;
using System;
using System.Collections.Generic;

namespace DrawingForm.PresentationModel
{
    public class PresentationModel
    {
        Model _model;
        bool _rectangleButtonEnable;
        bool _lineButtonEnable;
        bool _hexagoButtonEnable;
        List<bool> _buttonStatus = new List<bool>();

        public PresentationModel(Model model)
        {
            this._model = model;
            _rectangleButtonEnable = true;
            _lineButtonEnable = true;
            _hexagoButtonEnable = true;
            _buttonStatus.Add(_rectangleButtonEnable);
            _buttonStatus.Add(_lineButtonEnable);
            _buttonStatus.Add(_hexagoButtonEnable);
        }

        // 畫圖
        public void Draw(IGraphics adaptor)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(adaptor);
        }

        // 修改Button的Enabled
        public List<bool> SetButtonDisable(int buttonTag)
        {
            for (int i = 0; i < _buttonStatus.Count; i++)
                _buttonStatus[i] = true;
            if (_model.CurrentMode != -1)
            {
                _buttonStatus[buttonTag] = false;
                _model.IsSelected = false;
            }
            return _buttonStatus;
        }
    }
}
