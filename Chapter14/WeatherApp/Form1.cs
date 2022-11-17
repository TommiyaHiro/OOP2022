using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();


        }

        private void btWeatherGet_Click(object sender, EventArgs e) {

            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };

            //var dString = wc.DownloadString("https://www.jma.go.jp/bosai/forecast/data/overview_forecast/130000.json");
            if(comboBox1.Text == "東京都") {
                var dString = wc.DownloadString("https://www.jma.go.jp/bosai/forecast/data/forecast/130000.json");
                var json = JsonConvert.DeserializeObject<Class1[]>(dString);
                tbWeatherInfo.Text = json[0].timeSeries[0].areas[0].weathers[1];
            }
            if(comboBox1.Text == "群馬県") {
                var dString = wc.DownloadString("https://www.jma.go.jp/bosai/forecast/data/forecast/100000.json");
                var json = JsonConvert.DeserializeObject<Class1[]>(dString);
                tbWeatherInfo.Text = json[0].timeSeries[0].areas[0].weathers[1];
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

    }
}
