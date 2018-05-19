using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;

namespace MyChartControl
{
    public static class SizeHelper
    {
        public static Rect BoundsRelativeTo(this FrameworkElement element,
                                         Visual relativeTo)
        {
            return
              element.TransformToVisual(relativeTo)
                     .TransformBounds(new Rect(0, 0, element.ActualWidth, element.ActualHeight));
        }
    }
}
