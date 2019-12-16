using DrawingForm.PresentationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class Form : System.Windows.Forms.Form
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        const String CANVAS = "canvas";

        public Form()
        {
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
        }

        // 清除畫面
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
            _model.CurrentMode = -1;
            _model.IsSelected = false;
            SetButtonEnable((Button)sender);
            RefreshUserInterface();
        }

        // 畫矩形
        public void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _model.CurrentMode = 0;
            SetButtonEnable((Button)sender);
        }

        // 畫線
        public void HandleLineButtonClick(object sender, System.EventArgs e)
        {
            _model.CurrentMode = 1;
            SetButtonEnable((Button)sender);
        }

        // 畫六角形
        private void HandleHexagonButtonClick(object sender, EventArgs e)
        {
            _model.CurrentMode = (int)2m;
            SetButtonEnable((Button)sender);
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
            _model.ReleasePointer(e.X, e.Y);
            SetButtonEnable();
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

        // 修改Button的Enabled
        private void SetButtonEnable(Button pressedButton)
        {
            foreach (Button button in _tableLayoutPanel.Controls)
                button.Enabled = true;
            if (_model.CurrentMode != -1)
                pressedButton.Enabled = false;
            _model.IsSelected = false;
        }

        // 修改Button的Enabled
        private void SetButtonEnable()
        {
            if (_model.CurrentMode == -1)
                foreach (Button button in _tableLayoutPanel.Controls)
                    button.Enabled = true;
        }

        // 選擇形狀
        private void SelectShape(object sender, EventArgs e)
        {
            _shapePositionTextLabel.Text = _presentationModel.SelectShape(PointToClient(MousePosition));
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
