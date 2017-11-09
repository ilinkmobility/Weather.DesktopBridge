using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Weather.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Weather> Forecast { get; set; } = new ObservableCollection<Weather>();

        public MainPage()
        {
            this.InitializeComponent();

            Forecast.Add(new Weather() { Date = "12 Nov 2017", Day = "Wed", High = "32", Low = "21" });
            Forecast.Add(new Weather() { Date = "12 Nov 2017", Day = "Wed", High = "32", Low = "21" });
            Forecast.Add(new Weather() { Date = "12 Nov 2017", Day = "Wed", High = "32", Low = "21" });
            Forecast.Add(new Weather() { Date = "12 Nov 2017", Day = "Wed", High = "32", Low = "21" });
            Forecast.Add(new Weather() { Date = "12 Nov 2017", Day = "Wed", High = "32", Low = "21" });

            ForecastList.ItemsSource = Forecast;
        }
    }
}
