using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class ClearCommand : ICommand
    {
        List<IShape> _shapes = new List<IShape>();
        Model _model;

        public ClearCommand(Model model, List<IShape> shapes)
        {
            _model = model;
            foreach (IShape shape in shapes)
                _shapes.Add(shape);
        }

        // 執行
        public void Execute()
        {
            foreach (IShape shape in _shapes)
                _model.DeleteShape();
        }

        // 取消執行
        public void CancelExecute()
        {
            foreach (IShape shape in _shapes)
                _model.DrawShape(shape);
        }
    }
}
