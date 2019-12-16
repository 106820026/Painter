using DrawingApp.PresentationModel;
using DrawingModel;
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
        public MainPage()
        {
            this.InitializeComponent();
            _model = new DrawingModel.Model();
            _presentationModel = new PresentationModel.PresentationModel(_model);
            _interfaceGraphics = new WindowsStoreGraphicsAdaptor(_canvas);
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
            SetButtonIsEnabled((Button)sender);
            RefreshUserInterface();
        }

        // 畫矩形
        private void HandleRectangleButtonClick(object sender, RoutedEventArgs e)
        {
            _model.CurrentMode = 0;
            SetButtonIsEnabled((Button)sender);
        }

        // 畫線
        private void HandleLineButtonClick(object sender, RoutedEventArgs e)
        {
            _model.CurrentMode = 1;
            SetButtonIsEnabled((Button)sender);
        }

        // 畫六角形
        private void HandleHexagonButtonClick(object sender, RoutedEventArgs e)
        {
            _model.CurrentMode = (int)2m;
            SetButtonIsEnabled((Button)sender);
        }

        // 按下滑鼠
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            RefreshUserInterface();
        }

        // 釋放滑鼠
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            RefreshUserInterface();
        }

        // 滑鼠移動偵測
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
            RefreshUserInterface();
        }

        // 偵測改變
        public void HandleModelChanged()
        {
            _presentationModel.Draw(_interfaceGraphics);
        }

        // 設定Button的IsEnabled
        private void SetButtonIsEnabled(Button pressedButton)
        {
            foreach (Button button in _grid.Children)
                button.IsEnabled = true;
            if (_model.CurrentMode != -1)
                pressedButton.IsEnabled = false;
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

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}