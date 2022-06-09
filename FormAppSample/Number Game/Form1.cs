using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_Game {
    public partial class Form1 : Form {
        Random rand = new Random(Seed: 50);

        private int randomNumber;

        public Form1() {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            // 乱数取得
            randomNumber = rand.Next(minValue: 1, maxValue: 50);
            this.Text = randomNumber.ToString();
        }

        private void Ansbutton_Click(object sender, EventArgs e) {
            if(randomNumber == Ans.Value) {
                toolStripStatusLabel1.Text = "正解";
            }
            else if(randomNumber > Ans.Value){
                toolStripStatusLabel1.Text = "入力した値より大きいです";
            }
            else if(randomNumber < Ans.Value) {
                toolStripStatusLabel1.Text = "入力した値より小さいです";
            }

        }

        private void Form1_Load(object sender, EventArgs e) {
            randomNumber = rand.Next(minValue: 1, maxValue: 50);
            this.Text = randomNumber.ToString();
        }
    }
}
