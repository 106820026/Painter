﻿using DrawingForm.PresentationModel;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class Form : System.Windows.Forms.Form
    {
        Model _model;
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        const String CANVAS = "canvas";
        const String FILE_NAME = "AllShapes.dat";
        List<Button> _shapeButtons;
        DrawingState _drawingState;
        PointerState _pointerState;
        GoogleDriveService _service;
        OpenFileDialog _uploadFileOpenFileDialog;
        FolderBrowserDialog _downloadFolderBrowserDialog; 

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
            Controls.Add(_canvas);
            // prepare clear button
            _clear.AutoSize = true;
            _clear.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            // prepare presentation model and model
            _model = new Model();
            _presentationModel = new PresentationModel.PresentationModel(_model);
            _model._modelChanged += HandleModelChanged;
            // prepare state
            _drawingState = new DrawingState(_model);
            _pointerState = new PointerState(_model);
            _model.CurrentState = _pointerState;
            // prepare buttons
            _shapeButtons = new List<Button>();
            _shapeButtons.Add(_rectangle);
            _shapeButtons.Add(_line);
            _shapeButtons.Add(_hexagon);
            // google drive
            const String APPLICATION_NAME = "DrawPicture";
            const String CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            _uploadFileOpenFileDialog = new OpenFileDialog();
            _downloadFolderBrowserDialog = new FolderBrowserDialog();
            _uploadFileOpenFileDialog.FileName = "";
            _uploadFileOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            _downloadFolderBrowserDialog.SelectedPath = Directory.GetCurrentDirectory();
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);
            #endregion
        }

        // 清除畫面
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
            SetButtonDisable(int.Parse(((Button)sender).Tag.ToString()));
            _model.CurrentMode = -1;
            _model.IsSelected = false;
            _model.CurrentState = _pointerState;
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
        }

        // 釋放滑鼠
        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _shapePositionTextLabel.Text = _model.SelectShape(e.X, e.Y);
            _model.ReleasePointer(e.X, e.Y);
            SetAllButtonEnable();
            RefreshUserInterface();
        }

        // 偵測滑鼠移動
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _model.MovePointer(e.X, e.Y);
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
            if (_model.CurrentMode == -1)
                foreach (Button button in _tableLayoutPanel.Controls)
                    button.Enabled = true;
            _model.CurrentState = _pointerState;
        }

        // 修改Button的Enabled 把按下的Disable掉
        private void SetButtonDisable(int buttonTag)
        {
            for (int i = 0; i < _shapeButtons.Count; i++)
                _shapeButtons[i].Enabled = (_presentationModel.SetButtonDisable(buttonTag))[i];
            _model.CurrentState = _drawingState;
            HandleModelChanged();
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
        }

        // 按下儲存按鈕
        private void ClickSave(object sender, EventArgs e)
        {
            const String UPLOAD_QUESTION = "要上傳嗎";
            const String QUESTION = "Question";
            DialogResult dialogResult = MessageBox.Show(UPLOAD_QUESTION, QUESTION, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                UploadFileAsync();
                _load.Enabled = true;
            }
        }

        // 按下瀏覽按鈕
        private void ClickLoad(object sender, EventArgs e)
        {
            const String DOWNLOAD_QUESTION = "要下載嗎";
            const String QUESTION = "Question";
            DialogResult dialogResult = MessageBox.Show(DOWNLOAD_QUESTION, QUESTION, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                const String PATH = "./";
                List<Google.Apis.Drive.v2.Data.File> rootFolderFile = _service.ListRootFileAndFolder();
                Google.Apis.Drive.v2.Data.File selectedFile = rootFolderFile[(int)9m];
                _service.DownloadFile(selectedFile, PATH);
                using (Stream stream = File.Open(FILE_NAME, FileMode.Open))
                {
                    var binaryFormatter = new BinaryFormatter();
                    List<IShape> items = (List<IShape>)binaryFormatter.Deserialize(stream);
                    _model.ReloadAllShapes(items);
                }
            }
        }

        // 非同步上傳
        private async Task UploadFileAsync()
        {
            _model._modelChanged -= HandleModelChanged;
            await Task.Factory.StartNew(()=>UploadFileFromGoogleDrive());
            _model._modelChanged += HandleModelChanged;
        }

        // 從Google Drive上傳資料
        private void UploadFileFromGoogleDrive()
        {
            FileStream fileStream = new FileStream(FILE_NAME, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, _model.GetTotalShapes);
            fileStream.Close();
            const String CONTENT_TYPE = "application/octet-stream";
            _service.UploadFile(FILE_NAME, CONTENT_TYPE);
        }
    }
}
