using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IState
    {
        // 按下滑鼠
        void PressPointer(double x, double y);

        // 滑鼠移動偵測
        void MovePointer(double x, double y);

        // 釋放滑鼠
        void ReleasePointer(double x, double y);
    }
}
