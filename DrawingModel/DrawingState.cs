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

        public double FirstPointX
        {
            get;set;
        }

        public double FirstPointY
        {
            get; set;
        }

        public double LastPointX
        {
            get; set;
        }

        public double LastPointY
        {
            get; set;
        }

        public DrawingState(Model model)
        {
            _model = model;
        }

        // 按下滑鼠
        public void PressPointer(double x, double y)
        {
            FirstPointX = x;
            FirstPointY = y;
            _model.DrawHint(FirstPointX, FirstPointY, FirstPointX, FirstPointY);
            _model.IsPressed = true;
        }

        // 滑鼠移動偵測
        public void MovePointer(double x, double y)
        {
            _model.DrawHint(FirstPointX, FirstPointY, x, y);
        }

        // 釋放滑鼠
        public void ReleasePointer(double x, double y)
        {
            _model.IsPressed = false;
            LastPointX = x;
            LastPointY = y;
            if (LastPointX - FirstPointX != 0 || LastPointY - FirstPointY != 0)
                _model.SaveDrawing();
        }
    }
}
