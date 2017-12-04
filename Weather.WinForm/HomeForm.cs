using DesktopBridge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather.WinForm
{
    public partial class HomeForm : Form
    {
        public List<Weather> forecastList;
        public Helpers helpers;
        public string[] Cities = { "chennai", "mumbai", "delhi" };

        public HomeForm()
        {
            InitializeComponent();

            helpers = new Helpers();
            
            pictureBox1.Image = Properties.Resources.Sunny;

            comboBoxCities.SelectedIndex = 0;

            //if (!helpers.IsRunningAsUwp())
            //{
            //    linkLabel1.Visible = false;
            //}
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var list = WeatherServiceManager.Instance.ToJson(forecastList);
            Uri uri = new Uri("open.weather.uwp://message?list=" + list);
            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            forecastList = WeatherServiceManager.Instance.GetForecast(Cities[comboBoxCities.SelectedIndex]);

            if (forecastList.Count > 0)
            {
                lblHigh.Text = "High : " + forecastList[0].High;
                lblLow.Text = "Low : " + forecastList[0].Low;
            }
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextCode.Text))
            {
                MessageBox.Show("Enter some valid code to compile.", "Error", MessageBoxButtons.OK);
            }
            else
            {
                string result = CompilerHelper.Instance.Compile(richTextCode.Text);
                richTextOutput.Text = result;
            }
        }

        public void ShowAlert()
        {
            MessageBox.Show("Invoked", "Alert", MessageBoxButtons.OK);
        }

        private void btnRunn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CompilerHelper.Instance.CompiledDllPath))
            {
                CompilerHelper.Instance.InvokeConstructor();
            }
        }
    }
}
