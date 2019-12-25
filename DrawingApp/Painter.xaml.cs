using DrawingApp.PresentationModel;
using DrawingModel;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
namespace DrawingApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Model _model;
        PresentationModel.PresentationModel _presentationModel;
        IGraphics _interfaceGraphics;
        List<Button> _shapeButtons;

        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model);
            _interfaceGraphics = new WindowsStoreGraphicsAdaptor(_canvas);
            _shapeButtons = new List<Button>();
            _shapeButtons.Add(_rectangle);
            _shapeButtons.Add(_line);
            _shapeButtons.Add(_hexagon);
            _canvas.PointerPressed += HandleCanvasPressed;
            _canvas.PointerReleased += HandleCanvasReleased;
            _canvas.PointerMoved += HandleCanvasMoved;
            _clear.Click += HandleClearButtonClick;
            _rectangle.Click += HandleRectangleButtonClick;
            _line.Click += HandleLineButtonClick;
            _hexagon.Click += HandleHexagonButtonClick;
            _undo.Click += UndoHandler;
            _redo.Click += RedoHandler;
            _model._modelChanged += HandleModelChanged;
            _model._modelChanged += RefreshUserInterface;
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //}

        // 清除畫面
        private void HandleClearButtonClick(object sender, RoutedEventArgs e)
        {
            _model.Clear();
            _model.CurrentMode = -1;
            _model.IsSelected = false;
            SetButtonDisable(int.Parse(((Button)sender).Tag.ToString()));
            RefreshUserInterface();
        }

        // 畫矩形
        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _model.CurrentMode = 0;
            SetButtonDisable(int.Parse(((Button)sender).Tag.ToString()));
        }

        // 畫線
        private void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _model.CurrentMode = 1;
            SetButtonDisable(int.Parse(((Button)sender).Tag.ToString()));
        }

        // 畫六角形
        private void HandleHexagonButtonClick(object sender, RoutedEventArgs e)
        {
            _model.CurrentMode = (int)2m;
            SetButtonDisable(int.Parse(((Button)sender).Tag.ToString()));
        }

        // 按下滑鼠
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 釋放滑鼠
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _shapePositionTextLabel.Text = _model.SelectShape(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            SetAllButtonEnable();
            RefreshUserInterface();
        }

        // 滑鼠移動偵測
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 畫圖
        public void HandleModelChanged()
        {
            _presentationModel.Draw(_interfaceGraphics);
        }

        // 修改Button的Enabled 畫完全部按鈕要跳起來
        private void SetAllButtonEnable()
        {
            if(_model.CurrentMode == -1)
                foreach (Button button in _shapeButtons)
                    button.IsEnabled = true;
        }

        // 修改Button的Enabled 把按下的Disable掉
        private void SetButtonDisable(int buttonTag)
        {
            for (int i = 0; i < _shapeButtons.Count; i++)
                _shapeButtons[i].IsEnabled = (_presentationModel.SetButtonDisable(buttonTag))[i];
            HandleModelChanged();
        }

        // 回到上一步
        void UndoHandler(object sender, RoutedEventArgs e)
        {
            _model.IsSelected = false;
            _model.Undo();
            RefreshUserInterface();
        }

        // 取消回到上一步
        void RedoHandler(object sender, RoutedEventArgs e)
        {
            _model.IsSelected = false;
            _model.Redo();
            RefreshUserInterface();
        }

        // 更新redo與undo是否為enabled
        void RefreshUserInterface()
        {
            _redo.IsEnabled = _model.IsRedoEnabled;
            _undo.IsEnabled = _model.IsUndoEnabled;
        }
    }
}