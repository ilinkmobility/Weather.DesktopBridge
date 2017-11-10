using DesktopBridge;
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
        public List<Weather> forecastList;
        public Helpers helpers;
        public string[] Cities = { "chennai", "mumbai", "delhi" };

        public Form1()
        {
            InitializeComponent();

            helpers = new Helpers();
            
            pictureBox1.Image = Properties.Resources.Sunny;

            if (!helpers.IsRunningAsUwp())
            {
                linkLabel1.Visible = false;
            }
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var list = WeatherServiceManager.Instance.ToJson(forecastList);
            Uri uri = new Uri("open.weather.uwp://message?list=" + list);
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != 0)
            {
                forecastList = WeatherServiceManager.Instance.GetForecast(Cities[comboBox1.SelectedIndex - 1]);

                if (forecastList.Count > 0)
                {
                    lblHigh.Text = "High : " + forecastList[0].High;
                    lblLow.Text = "Low : " + forecastList[0].Low;
                }
            }
        }
    }
}
