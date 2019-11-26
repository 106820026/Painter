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
    public partial class Form1 : Form
    {
        DrawingModel.Model _model;
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();

        public Form1()
        {
            InitializeComponent();
            // prepare canvas
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.CornflowerBlue;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            // prepare clear button
            _clear.AutoSize = true;
            _clear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            // prepare presentation model and model
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
        }

        // 清除畫面
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
            _model.CurrentMode = (int)999m;
            _rectangle.Enabled = true;
            _line.Enabled = true;
        }

        // 畫矩形
        public void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _model.CurrentMode = 0;
            _rectangle.Enabled = false;
            _line.Enabled = true;
            
        }

        // 畫線
        public void HandleLineButtonClick(object sender, System.EventArgs e)
        {
            _model.CurrentMode = 1;
            _rectangle.Enabled = true;
            _line.Enabled = false;
        }

        // 按下滑鼠
        public void HandleCanvasPressed(object sender, MouseEventArgs e)
        {
            _model.PressPointer(e.X, e.Y);
        }

        // 釋放滑鼠
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _model.ReleasePointer(e.X, e.Y);
        }

        // 偵測滑鼠移動
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
        }

        // 畫圖
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // 偵測改變
        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}
