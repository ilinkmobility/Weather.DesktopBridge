using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        public ObservableCollection<Weather> ForecastList { get; set; } = new ObservableCollection<Weather>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                WwwFormUrlDecoder decoder = new WwwFormUrlDecoder(e.Parameter.ToString());
                try
                {
                    var message = decoder.GetFirstValueByName("list");

                    var forecastList = JsonConvert.DeserializeObject<List<Weather>>(message);

                    Forecast.ItemsSource = forecastList;

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("MainPage OnNavigatedTo Error: " + ex.Message);
                }
            }
        }

        public async void ShowDialog(string msg)
        {
            var messageDialog = new MessageDialog(msg);
            
            messageDialog.Commands.Add(new UICommand("Close"));

            // Show the message dialog
            await messageDialog.ShowAsync();
        }
    }
}
