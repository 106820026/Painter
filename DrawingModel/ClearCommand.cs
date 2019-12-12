using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ClearCommand : ICommand
    {
        List<Shape> _shapes = new List<Shape>();
        Model _model;

        public ClearCommand(Model model, List<Shape> shapes)
        {
            _model = model;
            foreach (Shape shape in shapes)
                _shapes.Add(shape);
        }

        // 執行
        public void Execute()
        {
            foreach (Shape shape in _shapes)
                _model.DeleteShape();
        }

        // 取消執行
        public void UnExecute()
        {
            foreach (Shape shape in _shapes)
                _model.DrawShape(shape);
        }
    }
}
