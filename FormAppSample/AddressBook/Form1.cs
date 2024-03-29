﻿using System;
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

namespace AddressBook {
    public partial class Form1 : Form {

        BindingList<Person> listPerson = new BindingList<Person>();

        public Form1() {
            InitializeComponent();
            dgvPersons.DataSource = listPerson;
        }

        private void btPictureOpen_Click(object sender, EventArgs e) {
            if(ofdFileOpenDialog.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdFileOpenDialog.FileName);
            }

        }

        private void btAddPerson_Click(object sender, EventArgs e) {
            // 氏名が未入力だったら登録しない
            if(String.IsNullOrWhiteSpace(tbName.Text)) {
                MessageBox.Show("入力されていません");
                return;
            }
            Person newPerson = new Person {
                Name = tbName.Text,
                MailAddress = tbMailAddress.Text,
                Address = tbAddress.Text,
                Company = cbCompany.Text,
                Picture = pbPicture.Image,
                listGroup = GetCheckBoxGroup(),
                Registration = dateTimePicker1.Value,
                TelNumber = tbTelNumber.Text,
                //KindNumber = 

            };
            listPerson.Add(newPerson);
            dgvPersons.Rows[dgvPersons.RowCount - 1].Selected = true;

            //if(listPerson.Count() > 0) {
            //    btDelete.Enabled = true;
            //    btUpdate.Enabled = true;
            //}
            setCbCompany(cbCompany.Text);
            // ↑↑↑
            //別解
            //if(!cbCompany.Items.Contains(cbCompany.Text)) {
            //    cbCompany.Items.Add(cbCompany.Text);
            //}

        }

        // コンボボックスに会社名を登録する
        private void setCbCompany(string company) {
            var cbcom = cbCompany.Items.IndexOf(cbCompany.Text);

            if(cbcom == -1) {
                cbCompany.Items.Add(cbCompany.Text);
            }
        }

        // チェックボックスにセットされている値をリストとしてとりだす
        private List<Person.GroupType> GetCheckBoxGroup() {
            var listGroup = new List<Person.GroupType>();
            if(cbFamily.Checked) {
                listGroup.Add(Person.GroupType.家族);
            }
            if(cbFriend.Checked) {
                listGroup.Add(Person.GroupType.友人);
            }
            if(cbWork.Checked) {
                listGroup.Add(Person.GroupType.仕事);
            }
            if(cbOther.Checked) {
                listGroup.Add(Person.GroupType.その他);
            }
            return listGroup;
        }

        //private List<Person.KindNumberType> GetRadioButton() {
        //    var NumGroup = new List<Person.KindNumberType>();
        //    if(radioButton1.Checked) {
        //        NumGroup.Add(Person.KindNumberType.自宅);
        //    }
        //    if(radioButton2.Checked) {
        //        NumGroup.Add(Person.KindNumberType.携帯);
        //    }

        //    return NumGroup;
        //}


        private void bpPictureClear_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        // データグリッドビューをクリックしたときのイベントハンドラ
        private void dgvPersons_Click(object sender, EventArgs e) {
            if(dgvPersons.CurrentRow == null) return;

            int index = dgvPersons.CurrentRow.Index;

            tbName.Text = listPerson[index].Name;
            tbMailAddress.Text = listPerson[index].MailAddress;
            tbAddress.Text = listPerson[index].Address;
            cbCompany.Text = listPerson[index].Company;
            pbPicture.Image = listPerson[index].Picture;
            dateTimePicker1.Value = listPerson[index].Registration.Year > 1900? listPerson[index].Registration : DateTime.Today;
            CheckBoxAllClear();

            foreach(var group in listPerson[index].listGroup) {
                switch(group) {
                    case Person.GroupType.家族:
                        cbFamily.Checked = true;
                        break;
                    case Person.GroupType.友人:
                        cbFriend.Checked = true;
                        break;
                    case Person.GroupType.仕事:
                        cbWork.Checked = true;
                        break;
                    case Person.GroupType.その他:
                        cbOther.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        // チェックボックスのクリア
        private void CheckBoxAllClear() {
            cbFamily.Checked = cbFriend.Checked = cbWork.Checked = cbOther.Checked = false;
        }

        // 更新ボタンが押された時の処理
        private void btUpdate_Click(object sender, EventArgs e) {
            int index = dgvPersons.CurrentRow.Index;
            listPerson[index].Name = tbName.Text;
            listPerson[index].MailAddress = tbMailAddress.Text;
            listPerson[index].Address = tbAddress.Text;
            listPerson[index].Company = cbCompany.Text;
            listPerson[index].Picture = pbPicture.Image;
            listPerson[index].listGroup = GetCheckBoxGroup();
            dgvPersons.Refresh();// データグリッドビューの更新

        }

        // 削除ボタン
        private void btDelete_Click(object sender, EventArgs e) {
            listPerson.RemoveAt(dgvPersons.CurrentRow.Index);

            if(listPerson.Count() == 0) {
                Enabled();// マスク処理呼び出し
            }
        }

        private void Enabled() {
            btUpdate.Enabled = btDelete.Enabled = listPerson.Count() > 0 ? true : false;
        }

            private void Form1_Load(object sender, EventArgs e) {
                Enabled();
            
            }

            // 保存ボタンのイベントハンドラ
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
        
        private void btOpen_Click(object sender, EventArgs e) {
            if(ofdFileOpenDialog.ShowDialog() == DialogResult.OK) {
                try {
                    // バイナリ形式でシリアル化
                    var bf = new BinaryFormatter();
                    using(FileStream fs = File.Open(ofdFileOpenDialog.FileName, FileMode.Open, FileAccess.Read)){
                        // シリアル化して読み込む
                        listPerson = (BindingList<Person>)bf.Deserialize(fs);
                        dgvPersons.DataSource = null;
                        dgvPersons.DataSource = listPerson;
                    }
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                
                foreach(var item in listPerson.Select(p => p.Company)) {
                    setCbCompany(item); // 存在する会社を登録
                }
            }
            Enabled();
        }

    }
}


