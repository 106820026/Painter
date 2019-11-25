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
            //
            // prepare canvas
            //
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = Color.CornflowerBlue;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            //
            // prepare clear button
            //
            _clear.AutoSize = true;
            _clear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //
            // prepare presentation model and model
            //
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
        }
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
        }

        public void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _model.CurrentMode = 0;
        }

        public void HandleLineButtonClick(object sender, System.EventArgs e)
        {
            _model.CurrentMode = 1;
        }
        public void HandleCanvasPressed(object sender,
       System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }
        public void HandleCanvasReleased(object sender,
       System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerReleased(e.X, e.Y);
        }
        public void HandleCanvasMoved(object sender,
       System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerMoved(e.X, e.Y);
        }
        public void HandleCanvasPaint(object sender,
       System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }
        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}
