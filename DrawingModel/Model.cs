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
        List<IShape> _shapes = new List<IShape>();
        IShape _shapeHint;
        const string USELESS_PART = "DrawingModel.";
        const string LINE_TYPE = "DrawingModel.Line";
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

        public IState CurrentState
        {
            get;set;
        }

        public IShape SelectedShape
        {
            get; set;
        }

        public bool IsPressed
        {
            get;set;
        }

        public bool IsSelected
        {
            get; set;
        }

        // 取得所有形狀
        public List<IShape> GetTotalShapes
        {
            get
            {
                return _shapes;
            }
            set
            {
                value = _shapes;
            }
        }

        // 按下滑鼠
        public void PressPointer(double x, double y)
        {
            CurrentState.PressPointer(x, y);
            NotifyModelChanged();
        }

        // 滑鼠移動偵測
        public void MovePointer(double x, double y)
        {
            CurrentState.MovePointer(x, y);
            NotifyModelChanged();
        }

        // 釋放滑鼠
        public void ReleasePointer(double x, double y)
        {
            CurrentState.ReleasePointer(x, y);
            NotifyModelChanged();
        }

        // 畫預覽圖
        public void DrawHint(double x1, double y1, double x2, double y2)
        {
            if (CurrentMode == -1)
            {
                _shapeHint = _shapeFactory.CreateShape(SelectedShape);
                SelectedShape = _shapeHint;
            }
            else
                _shapeHint = _shapeFactory.CreateShape(CurrentMode);
            _shapeHint.X1 = x1;
            _shapeHint.Y1 = y1;
            _shapeHint.X2 = x2;
            _shapeHint.Y2 = y2;
        }

        // 清空畫布
        public void Clear()
        {
            IsPressed = false;
            IsSelected = false;
            if (_shapes.Count != 0)
                _commandManager.Execute(new ClearCommand(this, _shapes));
            NotifyModelChanged();
        }

        // 畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (IShape aShape in _shapes)
                aShape.Draw(graphics);
            if (IsPressed && CurrentMode != -1) // default drawing
                _shapeHint.Draw(graphics);
            if (IsSelected && CurrentMode == -1) // resize & select shape
            {
                _shapeHint.Draw(graphics);
                SelectedShape.DrawFrame(graphics);
            }
        }

        // 存圖
        public void SaveDrawing()
        {
            IShape shape = _shapeFactory.CreateShape(CurrentMode);
            shape.X1 = CurrentState.FirstPointX;
            shape.Y1 = CurrentState.FirstPointY;
            shape.X2 = CurrentState.LastPointX;
            shape.Y2 = CurrentState.LastPointY;
            _commandManager.Execute(new DrawCommand(this, shape));
            CurrentMode = -1;
        }

        // 更改大小
        public void ResizeShape(IShape originalShape, IShape resizedShape, int index)
        {
            _commandManager.Execute(new ResizeCommand(this, originalShape, resizedShape, index));
        }

        // 修改原本的形狀
        public void ResizeOriginalShape(IShape originalShape, int index)
        {
            RefactorCoordinate(originalShape);
            GetTotalShapes.RemoveAt(index);
            GetTotalShapes.Insert(index, originalShape);
        }

        // 復原原本的形狀
        public void RecoverOriginalShape(IShape resizedShape, int index)
        {
            RefactorCoordinate(resizedShape);
            GetTotalShapes.RemoveAt(index);
            GetTotalShapes.Insert(index, resizedShape);
        }

        // 畫在畫布上
        public void DrawShape(IShape shape)
        {
            RefactorCoordinate(shape);
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
        private String GetDetail(IShape shape)
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

        // 調整座標位置
        private void RefactorCoordinate(IShape shape)
        {
            double x1 = Math.Min(shape.X1, shape.X2);
            double y1 = Math.Min(shape.Y1, shape.Y2);
            double x2 = Math.Max(shape.X1, shape.X2);
            double y2 = Math.Max(shape.Y1, shape.Y2);
            if (CurrentMode != 1 || (IsSelected && SelectedShape.GetType().ToString() != LINE_TYPE)) // 線的不能改
            {
                shape.X1 = x1;
                shape.Y1 = y1;
                shape.X2 = x2;
                shape.Y2 = y2;
            }
        }

        // 取得選取的形狀的索引
        public int GetSelectedShapeIndex()
        {
            return GetTotalShapes.FindIndex(selectShape => selectShape == SelectedShape);
        }

        // 從所有形狀中移除選取的
        public void RemoveSelectedShapeFromTotalShapes()
        {
            GetTotalShapes.RemoveAt(GetSelectedShapeIndex());
        }

        // 從所有形狀中插入選取的
        public void InsertSelectedShapeFromTotalShapes(int index)
        {
            GetTotalShapes.Insert(index, SelectedShape);
        }

        // 重新讀取list
        public void ReloadAllShapes(List<IShape> shapes)
        {
            GetTotalShapes.Clear();
            Console.WriteLine(shapes.Count);
            foreach (IShape shape in shapes)
            {
                GetTotalShapes.Add(shape);
            }
            NotifyModelChanged();
        }

        // 偵測所有動作
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
