using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class Weather
    {
        public string Temperature;
        public string State;
        public string Wind;
        public string WindDirection;
        public string Moisture;
        public string WaterTemperature;
        public string Url;

        public Weather()
        {
            Temperature = null;
            State = null;
            Wind = null;
            WindDirection = null;
            Moisture = null;
            WaterTemperature = null;
        }

        public Weather(Weather weather)
        {
            Temperature = weather.Temperature;
            State = weather.State;
            Wind = weather.Wind;
            WindDirection = weather.WindDirection;
            Moisture = weather.Moisture;
            WaterTemperature = weather.WaterTemperature;
        }

        public Weather(string url)
        {
            SetUrl(url);
            RefreshInfo();
        }

        public void RefreshInfo()
        {
            WebClient web = new WebClient();
            web.Encoding = Encoding.UTF8;
            string html = web.DownloadString(Url);
            SetTemperature(html);
            SetState(html);
            SetWind(html);
            SetWindDirection(html);
            SetMoisture(html);
            SetWaterTemperature(html);
        }

        private void SetTemperature(string html)
        {
            Regex regTemp = new Regex(@"<div class=""now__weather""><span class=""unit unit_temperature_c""><span class=""nowvalue__text_l""><span class=""nowvalue__sign"">(\+|-)?<\/span>(\d+\.)<span class=""nowvalue__text_m"">(\d)<\/span>");
            Match m = regTemp.Match(html);
            Temperature = m.Groups[1].Value + m.Groups[2].Value + m.Groups[3].Value + " " + "°C";
        }

        private void SetState(string html)
        {
            Regex regState = new Regex(@"<div class=""now__desc""><span class=""tip _top _center"">(.+)<\/span><\/div>");
            Match m = regState.Match(html);
            State = m.Groups[1].Value;
        }

        private void SetWind(string html)
        {
            Regex regWind = new Regex(@"<div class=""unit unit_wind_m_s""><div class=""nowinfo__value"">\s+(\d+)\s+<\/div>");
            Match m = regWind.Match(html);
            Wind = m.Groups[1].Value + " м/с";
        }

        private void SetWindDirection(string html)
        {
            Regex regDir = new Regex(@"<div class=""nowinfo__measure nowinfo__measure_wind"">\s+.{3}\s+<br>\s+(.+)+\s+<\/div>");
            Match m = regDir.Match(html);
            WindDirection = m.Groups[1].Value;
        }

        private void SetMoisture(string html)
        {
            Regex regMoisture = new Regex(@"<div class=""nowinfo__block""><div class=""nowinfo__type"">Вологість<\/div><div class=""nowinfo__value"">(\d+)<\/div>");
            Match m = regMoisture.Match(html);
            Moisture = m.Groups[1].Value + "%";
        }

        private void SetWaterTemperature(string html)
        {
            Regex regWaterTemp = new Regex(@"<div class=""nowinfo__block""><div class=""nowinfo__type"">Вода<\/div><div class=""unit unit_temperature_c""><div class=""nowinfo__value"">((?:\+|-)\d+\.\d|0)<\/div>");
            Match m = regWaterTemp.Match(html);
            WaterTemperature = m.Groups[1].Value + " °C";
        }

        private void SetUrl(string url)
        {
            Url = url;
        }

        public string GetTemperature()
        {
            return Temperature;
        }

        public string GetState()
        {
            return State;
        }

        public string GetWind()
        {
            return Wind;
        }

        public string GetWindDirection()
        {
            return WindDirection;
        }

        public string GetMoisture()
        {
            return Moisture;
        }

        public string GetWaterTemperature()
        {
            return WaterTemperature;
        }
    }
}


