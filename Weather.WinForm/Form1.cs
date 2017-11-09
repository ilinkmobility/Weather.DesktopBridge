using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather.WinForm
{
    public partial class Form1 : Form
    {
        public string[] Cities = { "chennai", "mumbai", "delhi" };

        public Form1()
        {
            InitializeComponent();
            
            pictureBox1.Image = Properties.Resources.Sunny;
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Uri uri = new Uri("open.weather.uwp://");
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != 0)
            {
                var forecast = WeatherServiceManager.Instance.GetForecast(Cities[comboBox1.SelectedIndex - 1]);

                if (forecast.Count > 0)
                {
                    lblHigh.Text = "High : " + forecast[0].High;
                    lblLow.Text = "Low : " + forecast[0].Low;
                }
            }
        }
    }
}
