using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class Form1 : Form {
        BindingList<CarReport> listPerson = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvArticle.DataSource = listPerson;
        }


        private void btExit_Click(object sender, EventArgs e) {
            //アプリケーションの終了
            Application.Exit();
        }

        private void btAdd_Click(object sender, EventArgs e) {
            if(String.IsNullOrWhiteSpace(cbName.Text)) {
                MessageBox.Show("入力されていません");
                return;
            }
            CarReport newPerson = new CarReport {
                Date = dtpDate.Value,
                Auther = cbName.Text,
                //Maker = .Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,

            };
            listPerson.Add(newPerson);
            dgvArticle.Rows[dgvArticle.RowCount - 1].Selected = true;

        }

        private void btPictureOpen_Click(object sender, EventArgs e) {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }

        private void btDelete_Click(object sender, EventArgs e) {
            listPerson.RemoveAt(dgvArticle.CurrentRow.Index);

            if(listPerson.Count() == 0) {
                Enabled();// マスク処理呼び出し
            }

        }

        private void Enabled() {
            btFix.Enabled = btDelete.Enabled = listPerson.Count() > 0 ? true : false;
        }
    }
}
