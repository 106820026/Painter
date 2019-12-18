using DrawingModel;
using System;
using System.Collections.Generic;

namespace DrawingApp.PresentationModel
{
    public class PresentationModel
    {
        Model _model;
        bool _rectangleButtonEnable;
        bool _lineButtonEnable;
        bool _hexagonButtonEnable;
        List<bool> _buttonStatus = new List<bool>();

        public PresentationModel(Model model)
        {
            this._model = model;
            _rectangleButtonEnable = true;
            _lineButtonEnable = true;
            _hexagonButtonEnable = true;
            _buttonStatus.Add(_rectangleButtonEnable);
            _buttonStatus.Add(_lineButtonEnable);
            _buttonStatus.Add(_hexagonButtonEnable);
        }

        // 畫圖
        public void Draw(IGraphics interfaceGraphics)
        {
            // 重複使用igraphics物件
            _model.Draw(interfaceGraphics);
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
