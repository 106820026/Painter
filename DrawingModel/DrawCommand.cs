﻿using System;
//using System.Drawing;

namespace DrawingModel
{
    public class DrawCommand : ICommand
    {
        IShape _shape;
        Model _model;
        public DrawCommand(Model model, IShape shape)
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
