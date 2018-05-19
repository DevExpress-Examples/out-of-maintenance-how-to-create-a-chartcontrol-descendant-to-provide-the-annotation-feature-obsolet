using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using DevExpress.Xpf.Charts;
using System.Windows.Controls;
using System.Collections.Generic;
using DevExpress.Xpf.Core.Native;

namespace MyChartControl
{
    public class MyChartControl : ChartControl
    {
        public object OldXVisualRangeMax { get; set; }
        public object OldXVisualRangeMin { get; set; }
        public object OldYVisualRangeMax { get; set; }
        public object OldYVisualRangeMin { get; set; }

        public MyChartControl()
            : base()
        {
            Annotations = new AnotationCollection(this);
            Loaded += MyChartControl_Loaded;
        }

        void MyChartControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (AnotationLayer == null)
            {
                Grid root = (Grid)VisualTreeHelper.GetChild(this, 0);
                SetUpCursorLayer();
                SetUpAnotations(root);
                SetUpUpdates();
            }
        }

        void MyChartControl_Zoom(object sender, XYDiagram2DZoomEventArgs e)
        {
            AnotationLayer.InvalidateArrange();
        }

        void MyChartControl_Scroll(object sender, XYDiagram2DScrollEventArgs e)
        {
            AnotationLayer.InvalidateArrange();
        }

        void MyChartControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AnotationLayer.UpdateClipping();
            AnotationLayer.InvalidateArrange();
        }

        private void SetUpUpdates()
        {
            XYDiagram2D diagram = (XYDiagram2D)Diagram;
            diagram.Scroll += MyChartControl_Scroll;
            diagram.Zoom += MyChartControl_Zoom;
            SizeChanged += MyChartControl_SizeChanged;
            diagram.LayoutUpdated += diagram_LayoutUpdated;
        }

        void diagram_LayoutUpdated(object sender, EventArgs e)
        {
            AnotationLayer.UpdateClipping();

            XYDiagram2D diagram = (XYDiagram2D)Diagram;
            if (IsRangeUpdated())
            {
                AnotationLayer.InvalidateArrange();
                OldXVisualRangeMax = diagram.ActualAxisX.ActualVisualRange.ActualMaxValue;
                OldXVisualRangeMin = diagram.ActualAxisX.ActualVisualRange.ActualMinValue;
                OldYVisualRangeMax = diagram.ActualAxisY.ActualVisualRange.ActualMaxValue;
                OldYVisualRangeMin = diagram.ActualAxisY.ActualVisualRange.ActualMinValue;
            }
        }

        private bool IsRangeUpdated()
        {
            XYDiagram2D diagram = (XYDiagram2D)Diagram;
            return diagram.ActualAxisX.ActualVisualRange == null || diagram.ActualAxisY.ActualVisualRange == null ||
                (OldXVisualRangeMax != diagram.ActualAxisX.ActualVisualRange.ActualMaxValue || OldXVisualRangeMin != diagram.ActualAxisX.ActualVisualRange.ActualMinValue) || (OldYVisualRangeMax != diagram.ActualAxisY.ActualVisualRange.ActualMaxValue || OldYVisualRangeMin != diagram.ActualAxisY.ActualVisualRange.ActualMinValue);
        }

        private void SetUpCursorLayer()
        {
            FrameworkElement navigationLayer = LayoutHelper.FindElementByName(this, "PART_NavigationLayer");
            Canvas.SetZIndex(navigationLayer, 99);
        }
        private void SetUpAnotations(Grid root)
        {
            AnotationLayer = new AnnotationPanel(this) { };
            root.Children.Add(AnotationLayer);
            Annotations.CreateAnotationPresenters();
        }

        public AnotationCollection Annotations { get; set; }
        protected internal AnnotationPanel AnotationLayer { get; set; }
    }
}