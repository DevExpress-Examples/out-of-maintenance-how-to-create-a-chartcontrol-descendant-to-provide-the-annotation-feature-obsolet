using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;

namespace MyChartControl
{
    public class Annotation: DependencyObject
    {
        public Annotation()
        {
        }

        static readonly DependencyProperty ArgumentProperty = DependencyProperty.Register("Argument", typeof(double), typeof(Annotation));
        static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(Annotation));
        static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(Annotation));
        static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(Annotation));
        static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register("BorderColor", typeof(Brush), typeof(Annotation));
        static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(int), typeof(Annotation));

        public int BorderThickness
        {
            get { return (int)GetValue(BorderThicknessProperty); }
            set
            {
                SetValue(BorderThicknessProperty, value);
            }
        }

        public Brush BorderColor
        {
            get { return (Brush)GetValue(BorderColorProperty); }
            set
            {
                SetValue(BorderColorProperty, value);
            }
        }

        public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set
            {
                SetValue(BackgroundProperty, value);
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public double Argument
        {
            get { return (double)GetValue(ArgumentProperty); }
            set
            {
                SetValue(ArgumentProperty, value);
            }
        }


        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }
    }
}