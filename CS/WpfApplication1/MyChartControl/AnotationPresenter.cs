using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace MyChartControl
{
    public class AnotationPresenter : Control
    {
        static AnotationPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnotationPresenter),
                     new FrameworkPropertyMetadata(typeof(AnotationPresenter)));
        }

        public AnotationPresenter()
        {

        }
    }
}
