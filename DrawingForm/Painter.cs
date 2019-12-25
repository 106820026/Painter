using DrawingForm.PresentationModel;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class Form : System.Windows.Forms.Form
    {
        Model _model;
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        const String CANVAS = "canvas";
        List<Button> _shapeButtons;

        public Form()
        {
            #region initialization
            InitializeComponent();
            // prepare canvas
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.CornflowerBlue;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            _canvas.AccessibleName = CANVAS;
            _canvas.Click += SelectShape;
            Controls.Add(_canvas);
            // prepare clear button
            _clear.AutoSize = true;
            _clear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            // prepare presentation model and model
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model);
            _model._modelChanged += HandleModelChanged;
            // prepare buttons
            _shapeButtons = new List<Button>();
            _shapeButtons.Add(_rectangle);
            _shapeButtons.Add(_line);
            _shapeButtons.Add(_hexagon);
            // prepare state

            #endregion
        }

        // 清除畫面
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
            SetButtonDisable(int.Parse(((Button)sender).Tag.ToString()));
            _model.CurrentMode = -1;
            _model.IsSelected = false;
            RefreshUserInterface();
        }

        // 畫矩形
        public void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _model.CurrentMode = 0;
            SetButtonDisable(int.Parse(((Button)sender).Tag.ToString()));
        }

        // 畫線
        public void HandleLineButtonClick(object sender, System.EventArgs e)
        {
            _model.CurrentMode = 1;
            SetButtonDisable(int.Parse(((Button)sender).Tag.ToString()));
        }

        // 畫六角形
        private void HandleHexagonButtonClick(object sender, EventArgs e)
        {
            _model.CurrentMode = (int)2m;
            SetButtonDisable(int.Parse(((Button)sender).Tag.ToString()));
        }

        // 按下滑鼠
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.PressPointer(e.X, e.Y);
            RefreshUserInterface();
        }

        // 釋放滑鼠
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            if (_model.CurrentMode == -1)
                _shapePositionTextLabel.Text = _model.SelectShape(e.X, e.Y);
            _model.ReleasePointer(e.X, e.Y);
            SetAllButtonEnable();
            RefreshUserInterface();
        }

        // 偵測滑鼠移動
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
            RefreshUserInterface();
        }

        // 畫圖
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics));
        }

        // 偵測改變
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        // 修改Button的Enabled 畫完全部按鈕要跳起來
        private void SetAllButtonEnable()
        {
            if(_model.CurrentMode == -1)
                foreach (Button button in _tableLayoutPanel.Controls)
                    button.Enabled = true;
        }

        // 修改Button的Enabled 把按下的Disable掉
        private void SetButtonDisable(int buttonTag)
        {
            for (int i = 0; i < _shapeButtons.Count; i++)
                _shapeButtons[i].Enabled = (_presentationModel.SetButtonDisable(buttonTag))[i];
            HandleModelChanged();
        }

        // 選擇形狀
        private void SelectShape(object sender, EventArgs e)
        {
            //_shapePositionTextLabel.Text = _model.SelectShape(PointToClient(MousePosition).X, PointToClient(MousePosition).Y);
        }

        // 回到上一步
        void UndoHandler(Object sender, EventArgs e)
        {
            _model.IsSelected = false;
            _model.Undo();
            RefreshUserInterface();
        }

        // 取消回到上一步
        void RedoHandler(Object sender, EventArgs e)
        {
            _model.IsSelected = false;
            _model.Redo();
            RefreshUserInterface();
        }

        // 更新redo與undo是否為enabled
        void RefreshUserInterface()    
        {
            _redo.Enabled = _model.IsRedoEnabled;
            _undo.Enabled = _model.IsUndoEnabled;
            Invalidate();
        }
    }
}
