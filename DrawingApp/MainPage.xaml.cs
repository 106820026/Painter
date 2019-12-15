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
        DrawingModel.Model _model;
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
            _model._modelChanged += HandleModelChanged;
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
            _model.CurrentMode = 2;
            SetButtonIsEnabled((Button)sender);
        }

        // 按下滑鼠
        public void HandleCanvasPressed(object sender, PointerRoutedEventArgs e)
        {
            _model.PressPointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 釋放滑鼠
        public void HandleCanvasReleased(object sender, PointerRoutedEventArgs e)
        {
            _model.ReleasePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
        }

        // 滑鼠移動偵測
        public void HandleCanvasMoved(object sender, PointerRoutedEventArgs e)
        {
            _model.MovePointer(e.GetCurrentPoint(_canvas).Position.X, e.GetCurrentPoint(_canvas).Position.Y);
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
    }
}