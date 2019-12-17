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
        CommandManager _commandManager = new CommandManager();
        ShapeFactory _shapeFactory = new ShapeFactory();
        double _firstPointX;
        double _firstPointY;
        double _lastPointX;
        double _lastPointY;
        bool _isPressed = false;
        List<Shape> _shapes = new List<Shape>();
        Shape _shapeHint;
        const string USELESS_PART = "DrawingModel.";
        const string COMMA = ",";
        const string LEFT_PARENTHESES = "(";
        const string RIGHT_PARENTHESES = ")";

        public Model()
        {
            this.CurrentMode = -1;
        }

        public int CurrentMode
        {
            get; set;
        }

        public Shape SelectedShape
        {
            get; set;
        }

        public bool IsSelected
        {
            get; set;
        }

        // 取得所有形狀
        public List<Shape> GetTotalShapes
        {
            get
            {
                return _shapes;
            }
        }

        // 按下滑鼠
        public void PressPointer(double x, double y)
        {
            if (CurrentMode == -1)
                _isPressed = true;
            if (x > 0 && y > 0 && CurrentMode != -1)
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
            if (_isPressed && CurrentMode != -1)
            {
                this.DrawHint(_firstPointX, _firstPointY, x, y);
                NotifyModelChanged();
            }
        }

        // 釋放滑鼠
        public void ReleasePointer(double x, double y)
        {
            if (CurrentMode == -1)
            {
                _isPressed = false;
                NotifyModelChanged();
            }
            if (_isPressed && CurrentMode != -1)
            {
                _isPressed = false;
                _lastPointX = x;
                _lastPointY = y;
                if ( _lastPointX - _firstPointX != 0 || _lastPointY - _firstPointY != 0)
                    SaveDrawing();
                NotifyModelChanged();
            }
        }

        // 畫預覽圖
        public void DrawHint(double x1, double y1, double x2, double y2)
        {
            _shapeHint = _shapeFactory.CreateShape(CurrentMode);
            _shapeHint.X1 = x1;
            _shapeHint.Y1 = y1;
            _shapeHint.X2 = x2;
            _shapeHint.Y2 = y2;
        }

        // 清空畫布
        public void Clear()
        {
            _isPressed = false;
            IsSelected = false;
            if (_shapes.Count != 0)
                _commandManager.Execute(new ClearCommand(this, _shapes));
            NotifyModelChanged();
        }

        // 畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            if (_isPressed)
                _shapeHint.Draw(graphics);
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (IsSelected)
                SelectedShape.DrawFrame(graphics);
        }

        // 存圖
        private void SaveDrawing()
        {
            Shape shape = _shapeFactory.CreateShape(CurrentMode);
            shape.X1 = _firstPointX;
            shape.Y1 = _firstPointY;
            shape.X2 = _lastPointX;
            shape.Y2 = _lastPointY;
            _commandManager.Execute(new DrawCommand(this, shape));
            CurrentMode = -1;
        }

        // 畫在畫布上
        public void DrawShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        // 從畫布上清除
        public void DeleteShape()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        // 回上一步
        public void Undo()
        {
            _commandManager.Undo();
            NotifyModelChanged();
        }

        // 取消回上一步
        public void Redo()
        {
            _commandManager.Redo();
            NotifyModelChanged();
        }
        
        // 選取形狀
        public string SelectShape(double x, double y)
        {
            if (CurrentMode == -1)
                for (int i = _shapes.Count - 1; i >= 0; i--)
                    if (_shapes[i].IsSelect(x, y))
                        return GetDetail(_shapes[i]);
            IsSelected = false;
            return String.Empty;
        }

        // 取得選取圖形的詳細資料
        private String GetDetail(Shape shape)
        {
            IsSelected = true;
            SelectedShape = shape;
            return shape.GetType().ToString().Replace(USELESS_PART, String.Empty) + LEFT_PARENTHESES + (int)shape.X1 + COMMA + (int)shape.Y1 + COMMA + (int)shape.X2 + COMMA + (int)shape.Y2 + RIGHT_PARENTHESES;
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
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
