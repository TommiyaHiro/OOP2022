using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        Settings settings = Settings.getInstance();

        public Form1() {
            InitializeComponent();
        }

        private void btPictureOpen_Click(object sender, EventArgs e) {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btExit_Click(object sender, EventArgs e) {
            //アプリケーションの終了
            Application.Exit();
        }

        private void btAdd_Click(object sender, EventArgs e) {
            DataRow newRow = infosys202234DataSet.CarReportDB.NewRow();
            newRow[1] = dtpDate.Text;
            newRow[2] = cbName.Text;
            newRow[3] = GetCheckBoxGroup();
            newRow[4] = cbCarName.Text; 
            newRow[5] = tbReport.Text; 
            newRow[6] = ImageToByteArray(pbPicture.Image); 

            //データセットへ新しいレコードを追加
            infosys202234DataSet.CarReportDB.Rows.Add(newRow);
            //データベース更新
            this.carReportDBTableAdapter.Update(this.infosys202234DataSet.CarReportDB);

        }

        private void setCbCarName(string text) {
            var cbcom = cbCarName.Items.IndexOf(cbCarName.Text);

            if(cbcom == -1) {
                cbCarName.Items.Add(cbCarName.Text);
            }
        }

        private void setCbAuther(string text) {
            var cbcomm = cbName.Items.IndexOf(cbName.Text);

            if(cbcomm == -1) {
                cbName.Items.Add(cbName.Text);
            }
        }

        // チェックボックスにセットされている値をリストとしてとりだす
        private string GetCheckBoxGroup() {
            if(rbTOYOTA.Checked) {
                return "トヨタ";
            }
            if(rbNISSAN.Checked) {
                return "日産";
            }
            if(rbHONDA.Checked) {
                return "ホンダ";
            }
            if(rbSUBARU.Checked) {
                return "スバル";
            }
            if(rbForeignCar.Checked) {
                return "外国車";
            }
            else {
                return "その他";
            }
        }

        private void btDelete_Click(object sender, EventArgs e) {
            carReportDBBindingSource.RemoveAt(carReportDBDataGridView.CurrentRow.Index);
            this.carReportDBTableAdapter.Update(this.infosys202234DataSet.CarReportDB);

        }

        private void btPictureDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }


        private void btSave_Click(object sender, EventArgs e) {
            carReportDBDataGridView.CurrentRow.Cells[1].Value = dtpDate.Text;
            carReportDBDataGridView.CurrentRow.Cells[2].Value = cbName.Text;
            carReportDBDataGridView.CurrentRow.Cells[3].Value = GetCheckBoxGroup();
            carReportDBDataGridView.CurrentRow.Cells[4].Value = cbCarName.Text;
            carReportDBDataGridView.CurrentRow.Cells[5].Value = tbReport.Text;
            carReportDBDataGridView.CurrentRow.Cells[6].Value = ImageToByteArray(pbPicture.Image);
           
            this.Validate();
            this.carReportDBBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202234DataSet);

        }

        // バイト配列をImageオブジェクトに変換
        public static Image ByteArrayToImage(byte[] b) {
            ImageConverter imgconv = new ImageConverter();
            Image img = (Image)imgconv.ConvertFrom(b);
            return img;
        }

        public static byte[] ImageToByteArray(Image img) {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            // 色設定ダイアログを表示
            if(cdColorSelect.ShowDialog() == DialogResult.OK) {
                BackColor = cdColorSelect.Color;

                settings.MainFormColor = cdColorSelect.Color.ToArgb();
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            try {
                //色設定逆シリアル化(P307)
                using(var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = serializer.Deserialize(reader) as Settings;
                    BackColor = Color.FromArgb(settings.MainFormColor);
            }

            }
            catch(Exception) {


            }

            //Enabled();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //シリアル化(P305)
                        using(var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void carReportDBBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.carReportDBBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202234DataSet);

        }

        private void carReportDBBindingNavigatorSaveItem_Click_1(object sender, EventArgs e) {
            this.Validate();
            this.carReportDBBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.infosys202234DataSet);

        }

        private void button1_Click(object sender, EventArgs e) {
            // TODO: このコード行はデータを 'infosys202234DataSet.CarReportDB' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.carReportDBTableAdapter.Fill(this.infosys202234DataSet.CarReportDB);
        }

        private void DataGridView_Click(object sender, EventArgs e) {

            if(carReportDBDataGridView.CurrentRow == null) {
                return;
            }

            dtpDate.Text = carReportDBDataGridView.CurrentRow.Cells[1].Value.ToString();
            cbName.Text = carReportDBDataGridView.CurrentRow.Cells[2].Value.ToString();
            setMakerRadioSet(carReportDBDataGridView.CurrentRow.Cells[3].Value.ToString());
            cbCarName.Text = carReportDBDataGridView.CurrentRow.Cells[4].Value.ToString();
            tbReport.Text = carReportDBDataGridView.CurrentRow.Cells[5].Value.ToString();
            if(!(carReportDBDataGridView.CurrentRow.Cells[6].Value is DBNull))
                pbPicture.Image = ByteArrayToImage((byte[])carReportDBDataGridView.CurrentRow.Cells[6].Value);
            else
                pbPicture.Image = null;

        }

        private void setMakerRadioSet(string maker) {
            switch(maker) {
                case"トヨタ":
                    rbTOYOTA.Checked = true;
                    break;
                case"日産":
                    rbNISSAN.Checked = true;
                    break;
                case"ホンダ":
                    rbHONDA.Checked = true;
                    break;
                case"スバル":
                    rbSUBARU.Checked = true;
                    break;
                case"外国車":
                    rbForeignCar.Checked = true;
                    break;
                case"その他":
                    rbOther.Checked = true;
                    break;
                default:
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e) {
            carReportDBTableAdapter.FillBy(infosys202234DataSet.CarReportDB, tbSearchName.Text);
        }
    }
}
