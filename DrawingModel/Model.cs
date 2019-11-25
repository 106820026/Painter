using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        double _lastPointX;
        double _lastPointY;
        bool _isPressed = false;
        List<Line> _lines = new List<Line>();
        List<Rectangle> _rectangles = new List<Rectangle>();
        Line _lineHint = new Line();
        Rectangle _rectangleHint = new Rectangle();

        public Model()
        {
            this.CurrentMode = 999;
        }

        public int CurrentMode{
            get; set;
        }

        // 按下滑鼠
        public void PointerPressed(double x, double y)
        {
            if (x > 0 && y > 0 && CurrentMode != 999)
            {
                _firstPointX = x;
                _firstPointY = y;
                this.DrawHint(_firstPointX, _firstPointY, _firstPointX, _firstPointY);
                _isPressed = true;
            }
        }

        // 滑鼠移動偵測
        public void PointerMoved(double x, double y)
        {
            if (_isPressed && CurrentMode != 999)
            {
                this.DrawHint(_firstPointX, _firstPointY, x, y);
                NotifyModelChanged();
            }
        }

        // 釋放滑鼠
        public void PointerReleased(double x, double y)
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
            if (CurrentMode == 0) // 畫矩形
            {
                _rectangleHint.x1 = x1;
                _rectangleHint.y1 = y1;
                _rectangleHint.x2 = x2 - x1;
                _rectangleHint.y2 = y2 - y1;
            }
            else if(CurrentMode == 1) // 畫線
            {
                _lineHint.x1 = x1;
                _lineHint.y1 = y1;
                _lineHint.x2 = x2;
                _lineHint.y2 = y2;
            }
        }

        // 清空畫布
        public void Clear()
        {
            _isPressed = false;
            _lines.Clear();
            _rectangles.Clear();
            NotifyModelChanged();
        }

        // 畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            if (CurrentMode == 0) // 畫矩形
            {
                if (_isPressed)
                    _rectangleHint.Draw(graphics);
            }
            else if (CurrentMode == 1) // 畫線
            {
                if (_isPressed)
                    _lineHint.Draw(graphics);
            }
            foreach (Rectangle aRectangle in _rectangles)
                aRectangle.Draw(graphics);
            foreach (Line aLine in _lines)
                aLine.Draw(graphics);
        }

        // 存圖
        private void SaveDrawing()
        {
            if (CurrentMode == 0) // 畫矩形
            {
                Rectangle newRectangle = new Rectangle();
                newRectangle.x1 = _firstPointX;
                newRectangle.y1 = _firstPointY;
                newRectangle.x2 = _lastPointX - _firstPointX;
                newRectangle.y2 = _lastPointY - _firstPointY;
                _rectangles.Add(newRectangle);
            }
            else if (CurrentMode == 1) // 畫線
            {
                Line newLine = new Line();
                newLine.x1 = _firstPointX;
                newLine.y1 = _firstPointY;
                newLine.x2 = _lastPointX;
                newLine.y2 = _lastPointY;
                _lines.Add(newLine);
            }
        }

        // 偵測所有動作
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
