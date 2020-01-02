using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class ShapeFactory
    {
        const int MODE0 = 0;
        const int MODE1 = 1;
        const int MODE2 = 2;
        const String WARNING = "Parameter index is out of range.";
        const string USELESS_PART = "DrawingModel.";
        const String RECTANGLE = "Rectangle";
        const String LINE = "Line";
        const String HEXAGON = "Hexagon";

        // 新增一個形狀
        public IShape CreateShape(int mode)
        {
            if (mode == MODE0)
                return new Rectangle();
            else if (mode == MODE1)
                return new Line();
            else if (mode == MODE2)
                return new Hexagon();
            else
                throw new ArgumentOutOfRangeException(WARNING);
        }

        // 新增一個形狀
        public IShape CreateShape(IShape shape)
        {
            String name = shape.GetType().ToString().Replace(USELESS_PART, String.Empty);
            if (name == RECTANGLE)
                return new Rectangle(shape.X1, shape.Y1, shape.X2, shape.Y2);
            else if (name == LINE)
                return new Line(shape.X1, shape.Y1, shape.X2, shape.Y2);
            else if (name == HEXAGON)
                return new Hexagon(shape.X1, shape.Y1, shape.X2, shape.Y2);
            else
                throw new ArgumentOutOfRangeException(WARNING);
        }
    }
}
