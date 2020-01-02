using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class ResizeCommand : ICommand
    {
        IShape _originalShape;
        IShape _resizeShape;
        Model _model;
        int _index;

        public ResizeCommand(Model model, IShape originalShape, IShape resizeShape, int index)
        {
            _originalShape = originalShape;
            _resizeShape = resizeShape;
            _model = model;
            _index = index;
        }

        // 執行
        public void Execute()
        {
            _model.ResizeOriginalShape(_resizeShape, _index);
        }

        // 取消執行
        public void CancelExecute()
        {
            _model.RecoverOriginalShape(_originalShape, _index);
        }
    }
}
