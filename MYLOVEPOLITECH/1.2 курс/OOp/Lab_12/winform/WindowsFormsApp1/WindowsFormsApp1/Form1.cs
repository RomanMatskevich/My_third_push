using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using ClassLibrary;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string urlWeather = "https://www.gismeteo.ua/ua/weather-zhytomyr-4943/now";
        Weather weather;

        private void Form1_Load(object sender, EventArgs e)
        {

            weather = new Weather(urlWeather);
            RefreshWeather();

        }
   
        void RefreshWeather()
        {
            WebClient web = new WebClient();
            web.Encoding = Encoding.UTF8;
            label1.Text = weather.State;
            label2.Text = weather.Temperature;
            label3.Text = weather.Wind;
            label3.Text = weather.WindDirection;
            label4.Text = weather.Moisture;
            label5.Text = weather.WaterTemperature;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            weather.RefreshInfo();
            RefreshWeather();
        }
    }
}

    

