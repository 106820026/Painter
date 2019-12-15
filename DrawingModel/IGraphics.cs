using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public interface IGraphics
    {
        // 畫矩形
        void DrawRectangle(double x1, double y1, double x2, double y2);

        // 畫矩形外框
        void DrawRectangleFrame(double x1, double y1, double x2, double y2);

        // 畫線
        void DrawLine(double x1, double y1, double x2, double y2);

        // 畫線外框
        void DrawLineFrame(double x1, double y1, double x2, double y2);

        // 畫六角形
        void DrawHexagon(double x1, double y1, double x2, double y2);

        // 畫六角形外框
        void DrawHexagonFrame(double x1, double y1, double x2, double y2);

        // 清除
        void ClearAll();
    }
}
