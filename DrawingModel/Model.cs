using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        double _lastPointX;
        double _lastPointY;
        bool _isPressed = false;
        List<Shape> _shapes = new List<Shape>();
        List<Shape> _shapeHint = new List<Shape>();

        public Model()
        {
            this.CurrentMode = (int)999m;
            Rectangle rectangle = new Rectangle();
            Line line = new Line();
            _shapeHint.Add(rectangle);
            _shapeHint.Add(line);
        }

        public int CurrentMode
        {
            get; set;
        }

        // 按下滑鼠
        public void PressPointer(double x, double y)
        {
            if (x > 0 && y > 0 && CurrentMode != (int)999m)
            {
                _firstPointX = x;
                _firstPointY = y;
                this.DrawHint(_firstPointX, _firstPointY, _firstPointX, _firstPointY);
                _isPressed = true;
            }
        }

        // 滑鼠移動偵測
        public void MovePointer(double x, double y)
        {
            if (_isPressed && CurrentMode != (int)999m)
            {
                this.DrawHint(_firstPointX, _firstPointY, x, y);
                NotifyModelChanged();
            }
        }

        // 釋放滑鼠
        public void ReleasePointer(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                _lastPointX = x;
                _lastPointY = y;
                SaveDrawing();
                NotifyModelChanged();
            }
        }

        // 畫預覽圖
        public void DrawHint(double x1, double y1, double x2, double y2)
        {
            _shapeHint[CurrentMode].X1 = x1;
            _shapeHint[CurrentMode].Y1 = y1;
            _shapeHint[CurrentMode].X2 = x2;
            _shapeHint[CurrentMode].Y2 = y2;
        }

        // 清空畫布
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        // 畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            if (_isPressed)
                _shapeHint[CurrentMode].Draw(graphics);
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
        }

        // 存圖
        private void SaveDrawing()
        {
            if (CurrentMode == 0) // 畫矩形
            {
                Rectangle newRectangle = new Rectangle();
                _shapes.Add(this.AddNewShape(newRectangle));
            }
            else if (CurrentMode == 1) // 畫線
            {
                Line newLine = new Line();
                _shapes.Add(this.AddNewShape(newLine));
            }
        }

        // 新增新圖
        private Shape AddNewShape(Shape shape)
        {
            shape.X1 = _firstPointX;
            shape.Y1 = _firstPointY;
            shape.X2 = _lastPointX;
            shape.Y2 = _lastPointY;
            return shape;
        }

        // 偵測所有動作
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
