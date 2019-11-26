using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using DrawingModel;
namespace DrawingApp.PresentationModel
{
    class PresentationModel
    {
        Model _model;
        IGraphics _interfaceGraphics;
        public PresentationModel(Model model, Canvas canvas)
        {
            this._model = model;
            _interfaceGraphics = new WindowsStoreGraphicsAdaptor(canvas);
        }

        // 畫圖
        public void Draw()
        {
            // 重複使用igraphics物件
            _model.Draw(_interfaceGraphics);
        }
    }
}
