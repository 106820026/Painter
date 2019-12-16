using System;
//using System.Drawing;

namespace DrawingModel
{
    class DrawCommand : ICommand
    {
        Shape _shape;
        Model _model;
        public DrawCommand(Model model, Shape shape)
        {
            _shape = shape;
            _model = model;
        }

        // 執行
        public void Execute()
        {
            _model.DrawShape(_shape);
        }

        // 取消執行
        public void CancelExecute()
        {
            _model.DeleteShape();
        }
    }
}
