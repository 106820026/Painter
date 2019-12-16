﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class ShapeFactory
    {
        const int RECTANGLE = 0;
        const int LINE = 1;
        const int HEXAGON = 2;
        const String WARNING = "Parameter index is out of range.";

        // 新增一個形狀
        public Shape CreateShape(int shapeType)
        {
            if (shapeType == RECTANGLE)
                return new Rectangle();
            else if (shapeType == LINE)
                return new Line();
            else if (shapeType == HEXAGON)
                return new Hexagon();
            else
                throw new System.ArgumentOutOfRangeException(WARNING);
        }
    }
}
