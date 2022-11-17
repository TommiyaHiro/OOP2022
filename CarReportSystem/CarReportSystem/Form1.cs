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

        BindingList<CarReport> listPerson = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvArticle.DataSource = listPerson;
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
            if(String.IsNullOrWhiteSpace(cbName.Text)) {
                MessageBox.Show("入力されていません");
                return;
            }
            CarReport newPerson = new CarReport {
                Date = dtpDate.Value,
                Auther = cbName.Text,
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
                Maker = GetCheckBoxGroup(),
            };
            listPerson.Add(newPerson);
            dgvArticle.Rows[dgvArticle.RowCount - 1].Selected = true;

            setCbAuther(cbName.Text);

            setCbCarName(cbCarName.Text);

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
        private CarReport.MakerGroup GetCheckBoxGroup() {
            if(rbTOYOTA.Checked) {
                return CarReport.MakerGroup.トヨタ;
            }
            if(rbNISSAN.Checked) {
                return CarReport.MakerGroup.日産;
            }
            if(rbHONDA.Checked) {
                return CarReport.MakerGroup.ホンダ;
            }
            if(rbSUBARU.Checked) {
                return CarReport.MakerGroup.スバル;
            }
            if(rbForeignCar.Checked) {
                return CarReport.MakerGroup.外国車;
            }
            else {
                return CarReport.MakerGroup.その他;
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

        private void btPictureDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }


        private void btSave_Click(object sender, EventArgs e) {
            if(sfdSaveDialog.ShowDialog() == DialogResult.OK) {
                try {
                    // バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();

                    using(FileStream fs = File.Open(sfdSaveDialog.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listPerson);
                    }
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btArticleOpen_Click(object sender, EventArgs e) {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    // バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();
                    using(FileStream fs = File.Open(openFileDialog1.FileName, FileMode.Open, FileAccess.Read)) {
                        // シリアル化して読み込む
                        listPerson = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvArticle.DataSource = null;
                        dgvArticle.DataSource = listPerson;
                    }
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
            Enabled();
    }

        private void btFix_Click(object sender, EventArgs e) {
            int index = dgvArticle.CurrentRow.Index;
            listPerson[index].Auther = cbName.Text;
            listPerson[index].Date = dtpDate.Value;
            listPerson[index].CarName = cbCarName.Text;
            listPerson[index].Report = tbReport.Text;
            listPerson[index].Picture = pbPicture.Image;
            dgvArticle.Refresh();// データグリッドビューの更新
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

            Enabled();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //シリアル化(P305)
                        using(var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
        }

        private void cbCarName_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
