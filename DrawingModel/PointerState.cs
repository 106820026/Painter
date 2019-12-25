using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class PointerState : IState
    {
        Model _model;

        public PointerState(Model model)
        {
            _model = model;
        }

        // 按下滑鼠
        public void PressPointer(double x, double y)
        {
            _model.IsPressed = true;
        }

        // 滑鼠移動偵測
        public void MovePointer(double x, double y)
        {

        }

        // 釋放滑鼠
        public void ReleasePointer(double x, double y)
        {
            _model.IsPressed = false;
        }
    }
}
