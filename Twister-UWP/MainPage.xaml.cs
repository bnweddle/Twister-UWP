using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Twister_UWP.RotaryWheel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Twister_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            rotaryWheelDemo.Slices = new Dictionary<string, Color>
            {
                { "Blue", Colors.Blue },
                { "Green", Colors.Green },
                { "Red", Colors.Red },
                { "Orange", Colors.Orange },
            };

            rotaryWheelDemo.PropertyChanged += RotaryWheelDemo_PropertyChanged;
        }

        private void RotaryWheelDemo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var rotaryWheel = (Wheel)sender;
            switch (e.PropertyName)
            {
                case "SelectedItemValue":
                    {
                        Debug.WriteLine(rotaryWheel.SelectedItemValue);
                        break;
                    }
            }

        }
    }
}
