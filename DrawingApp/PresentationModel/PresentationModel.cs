using DrawingModel;

namespace DrawingApp.PresentationModel
{
    public class PresentationModel
    {
        Model _model;
        public PresentationModel(Model model)
        {
            this._model = model;
        }

        // 畫圖
        public void Draw(IGraphics interfaceGraphics)
        {
            // 重複使用igraphics物件
            _model.Draw(interfaceGraphics);
        }
    }
}
