using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class DrawingState : IState
    {
        Model _model;
        double _firstPointX;
        double _firstPointY;
        double _lastPointX;
        double _lastPointY;

        public DrawingState(Model model)
        {
            _model = model;
        }

        // 按下滑鼠
        public void PressPointer(double x, double y)
        {
            _model.IsPressed = true;
            _firstPointX = x;
            _firstPointY = y;
        }

        // 滑鼠移動偵測
        public void MovePointer(double x, double y)
        {
            if (_model.IsPressed)
                _model.DrawHint(_firstPointX, _firstPointY, x, y);
        }

        // 釋放滑鼠
        public void ReleasePointer(double x, double y)
        {

        }
    }
}
