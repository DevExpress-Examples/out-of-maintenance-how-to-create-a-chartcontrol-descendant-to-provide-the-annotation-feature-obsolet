using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace MyChartControl
{
    public class AnotationCollection : BindingList<Annotation>
    {

        public AnotationCollection(MyChartControl chart)
        {
            Owner = chart;
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (Owner.AnotationLayer != null)
                CreateAnotationPresenters();
            base.OnListChanged(e);
        }

        protected internal void CreateAnotationPresenters()
        {
            foreach (Annotation anotation in this)
            {
                AnotationPresenter anotationPresenter = new AnotationPresenter() { DataContext = anotation };
                Owner.AnotationLayer.Children.Add(anotationPresenter);
            }
        }
        public MyChartControl Owner { get; private set; }
    }
}