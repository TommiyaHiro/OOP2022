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

        string[] areaCodes = {
                        "011000",    //北海道　宇谷地方
                        "020000",    //青森
                        "030000",    //岩手
                        "040000",    //宮城
                        "050000",    //秋田
                        "060000",    //山形
                        "070000",    //福島
                        "080000",    //茨木
                        "090000",    //栃木
                        "100000",   //群馬
                        "110000",   //埼玉
                        "120000",   //千葉
                        "130000",   //東京
                        "140000",   //神奈川
                        "150000",   //山梨
                        "160000",   //長野
                        "170000",   //岐阜
                        "180000",   //静岡
                        "190000",   //愛知
                        "200000",   //三重
                        "210000",   //新潟
                        "220000",   //富山
                        "230000",   //石川
                        "240000",   //福井
                        "250000",   //滋賀
                        "260000",   //京都
                        "270000",   //大阪
                        "280000",   //兵庫
                        "290000",   //奈良
                        "300000",   //和歌山
                        "310000",   //鳥取
                        "320000",   //島根
                        "330000",   //岡山
                        "340000",   //広島
                        "350000",   //徳島
                        "360000",   //香川
                        "370000",   //愛媛
                        "380000",   //高知
                        "390000",   //山口
                        "400000",   //福岡
                        "410000",   //佐賀
                        "420000",   //長崎
                        "430000",   //熊本
                        "440000",   //大分
                        "450000",   //宮崎
                        "460100",   //鹿児島
                        "471000",   //沖縄

        };
        string[] weathermark = {
                        "100",
                        "101",
                        "102",
                        "103",
                        "104",
                        "105",
                        "106",
                        "107",
                        "108",
                        "109",
                        "110",
        };


        public Form1() {
            InitializeComponent();


        }

        private void btWeatherGet_Click(object sender, EventArgs e) {

            var wc = new WebClient() {
                Encoding = Encoding.UTF8
            };

            var code = areaCodes[cbareaSelect.SelectedIndex];

            var dString = wc.DownloadString("https://www.jma.go.jp/bosai/forecast/data/forecast/" + code + ".json");
            var json = JsonConvert.DeserializeObject<Class1[]>(dString);
            tbweather.Text = json[0].timeSeries[0].areas[0].weathers[1];



            //tbWeatherInfo.Text = json[0].timeSeries[0].areas[0].weatherCodes[1];
            ////var dString = wc.DownloadString("https://www.jma.go.jp/bosai/forecast/data/overview_forecast/130000.json");
            //if(comboBox1.Text == "東京都") {
            //    var dString = wc.DownloadString("https://www.jma.go.jp/bosai/forecast/data/forecast/130000.json");
            //    var json = JsonConvert.DeserializeObject<Class1[]>(dString);
            //    var mark = json[0].timeSeries[0].areas[0].weathers[1];


            //}
            //if(comboBox1.Text == "群馬県") {
            //    var dString = wc.DownloadString("https://www.jma.go.jp/bosai/forecast/data/forecast/100000.json");
            //    var json = JsonConvert.DeserializeObject<Class1[]>(dString);
            //    tbWeatherInfo.Text = json[0].timeSeries[0].areas[0].weatherCodes[1];
            //}

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

    }
}
