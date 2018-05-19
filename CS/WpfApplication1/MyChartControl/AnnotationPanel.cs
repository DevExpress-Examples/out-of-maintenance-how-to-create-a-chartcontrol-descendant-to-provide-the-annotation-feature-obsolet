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
    public class AnnotationPanel : Panel
    {

        public AnnotationPanel(MyChartControl owner)
        {
            Owner = owner;
            Diagram = (XYDiagram2D)Owner.Diagram;
            UpdateClipping();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                InternalChildren[i].Measure(availableSize);
            }
            return availableSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                AnotationPresenter anotationPresenter = (AnotationPresenter)InternalChildren[i];
                Rect anotationRec = CalcAnotationRec(anotationPresenter);
                if (!anotationRec.IsEmpty)
                    anotationPresenter.Arrange(anotationRec);
            }
            return finalSize;
        }

        private Rect CalcAnotationRec(AnotationPresenter anotationPresenter)
        {
            Annotation annotation = (Annotation)anotationPresenter.DataContext;
            double argumnt = annotation.Argument;
            double value = annotation.Value;

            ControlCoordinates coordInfo = Diagram.DiagramToPoint(argumnt, value);
            double x = coordInfo.Point.X;
            double y = coordInfo.Point.Y;
            Rect anotationRec = new Rect(new Point(x, y), anotationPresenter.DesiredSize);
            return anotationRec;
        }
        public void UpdateClipping()
        {
            DomainPanel panel = LayoutHelper.FindElementByType<DevExpress.Xpf.Charts.DomainPanel>(Diagram);
            Rect diagramRec = SizeHelper.BoundsRelativeTo(panel, Owner);
            if (Clip == null)
                Clip = new RectangleGeometry(diagramRec);
            if (Clip.Bounds != diagramRec)
                Clip = new RectangleGeometry(diagramRec);
        }
        public MyChartControl Owner { get; private set; }
        public XYDiagram2D Diagram { get; private set; }

    }
}