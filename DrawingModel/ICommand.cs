using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingModel
{
    interface ICommand
    {
        // 執行
        void Execute();

        // 取消執行
        void CancelExecute();
    }
}