using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class ResizeCommand : ICommand
    {
        IShape _shape;
        IShape _originalShape;
        Model _model;

        public ResizeCommand(Model model, IShape shape)
        {
            _shape = shape;
            _model = model;
        }

        public void Execute()
        {
            
        }

        // 取消執行
        public void CancelExecute()
        {
           
        }
    }
}
