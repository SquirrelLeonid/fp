﻿using App.Infrastructure.LayoutingAlgorithms.AlgorithmFromTDD;

namespace App.Infrastructure.LayoutingAlgorithms
{
    public interface ILayouterFactory
    {
        Result<ICloudLayouter> CreateLayouter();
    }
}