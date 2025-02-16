﻿using System.Collections.Generic;
using System.Drawing;

namespace App.Infrastructure.LayoutingAlgorithms
{
    public interface ILayouter
    {
        List<Rectangle> GetRectanglesCopy();

        Size GetRectanglesBoundaryBox();

        Result<Rectangle> PutNextRectangle(Size rectangleSize);
    }
}