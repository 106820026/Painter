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
        int _index;
        bool _resizing;
        ShapeFactory _shapeFactory;
        IShape _originalShape;
        IShape _resizedShape;
        const string LINE_TYPE = "DrawingModel.Line";

        public double FirstPointX
        {
            get; set;
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

        public PointerState(Model model)
        {
            _model = model;
            _shapeFactory = new ShapeFactory();
        }

        // 按下滑鼠
        public void PressPointer(double x, double y)
        {
            _model.IsPressed = true;
            _resizing = WantToResize(x, y);
            _index = _model.GetSelectedShapeIndex();
            if (_resizing)
            {
                _model.RemoveSelectedShapeFromTotalShapes();
                _originalShape = _shapeFactory.CreateShape(_model.SelectedShape);
            }
        }

        // 滑鼠移動偵測
        public void MovePointer(double x, double y)
        {
            if (_resizing)
                _model.DrawHint(_model.SelectedShape.X1, _model.SelectedShape.Y1, x, y);
        }

        // 釋放滑鼠
        public void ReleasePointer(double x, double y)
        {
            _model.IsPressed = false;
            if (_resizing)
            {
                _resizedShape = _shapeFactory.CreateShape(_model.SelectedShape);
                _model.InsertSelectedShapeFromTotalShapes(_index);
                _model.ResizeShape(_originalShape, _resizedShape, _index);
                _resizing = false;
            }
        }

        // 想要改變大小
        private bool WantToResize(double x, double y)
        {
            if (_model.IsSelected)
            {
                IShape shape = _model.SelectedShape;
                double rightBottomX = Math.Max(shape.X1, shape.X2);
                double rightBottomY = Math.Max(shape.Y1, shape.Y2);
                if (_model.IsPressed && x > rightBottomX - (int)5m && x < rightBottomX + (int)5m && y > rightBottomY - (int)5m && y < rightBottomY + (int)5m)
                    return true;
            }
            return false;
        }
    }
}
