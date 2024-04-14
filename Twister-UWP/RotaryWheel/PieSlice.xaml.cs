﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Twister_UWP.Helpers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Twister_UWP.RotaryWheel
{
    public sealed partial class PieSlice : UserControl
    {
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(PieSlice), null);

        public static readonly DependencyProperty ForegroundColorProperty =
            DependencyProperty.Register("ForegroundColor", typeof(string), typeof(PieSlice), null);

        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle", typeof(double), typeof(PieSlice), null);

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(PieSlice), null);

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(double), typeof(PieSlice), null);

        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(PieSlice), null);

        public static readonly DependencyProperty HideLabelProperty =
            DependencyProperty.Register("HideLabel", typeof(bool), typeof(PieSlice), null);

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value.ToUpperInvariant()); }
        }

        public Color ForegroundColor
        {
            get { return (Color)GetValue(ForegroundColorProperty); }
            set { SetValue(ForegroundColorProperty, value); }
        }

        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public bool HideLabel
        {
            get { return (bool)GetValue(HideLabelProperty); }
            set { SetValue(HideLabelProperty, value); }
        }

        public PieSlice()
        {
            this.InitializeComponent();
            this.DataContext = this;

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            pieSlicePath.Radius = this.Radius;
            pieSlicePath.StartAngle = this.StartAngle;
            pieSlicePath.Angle = this.Angle;
            pieSlicePath.Fill = new SolidColorBrush(this.BackgroundColor);

            textBlock.Foreground = new SolidColorBrush(this.ForegroundColor);
            textBlockRotate.Angle = StartAngle + Angle / 2;

            var newPoint = QuadrantsHelper.Calculate(4 * Radius / 5, StartAngle, Angle);
            textBlockTranslate.X = newPoint.X;
            textBlockTranslate.Y = newPoint.Y;
        }
    }
}
