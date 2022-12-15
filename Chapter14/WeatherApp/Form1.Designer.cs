
namespace WeatherApp {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.btWeatherGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbareaSelect = new System.Windows.Forms.ComboBox();
            this.tbweather = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btWeatherGet
            // 
            this.btWeatherGet.Location = new System.Drawing.Point(20, 38);
            this.btWeatherGet.Name = "btWeatherGet";
            this.btWeatherGet.Size = new System.Drawing.Size(92, 31);
            this.btWeatherGet.TabIndex = 1;
            this.btWeatherGet.Text = "取得";
            this.btWeatherGet.UseVisualStyleBackColor = true;
            this.btWeatherGet.Click += new System.EventHandler(this.btWeatherGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(16, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "天気概況";
            // 
            // cbareaSelect
            // 
            this.cbareaSelect.FormattingEnabled = true;
            this.cbareaSelect.Items.AddRange(new object[] {
            "北海道 宇谷地方",
            "青森",
            "岩手",
            "宮城",
            "秋田",
            "山形",
            "福島",
            "茨木",
            "栃木",
            "群馬",
            "埼玉",
            "千葉",
            "東京",
            "神奈川",
            "山梨",
            "長野",
            "岐阜",
            "静岡",
            "愛知",
            "三重",
            "新潟",
            "富山",
            "石川",
            "福井",
            "滋賀",
            "京都",
            "大阪",
            "兵庫",
            "奈良",
            "和歌山",
            "鳥取",
            "島根",
            "岡山",
            "広島",
            "徳島",
            "香川",
            "愛媛",
            "高知",
            "山口",
            "福岡",
            "佐賀",
            "長崎",
            "熊本",
            "大分",
            "宮崎",
            "鹿児島",
            "沖縄"});
            this.cbareaSelect.Location = new System.Drawing.Point(128, 44);
            this.cbareaSelect.Name = "cbareaSelect";
            this.cbareaSelect.Size = new System.Drawing.Size(92, 20);
            this.cbareaSelect.TabIndex = 3;
            this.cbareaSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tbweather
            // 
            this.tbweather.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbweather.Location = new System.Drawing.Point(128, 97);
            this.tbweather.Multiline = true;
            this.tbweather.Name = "tbweather";
            this.tbweather.Size = new System.Drawing.Size(240, 73);
            this.tbweather.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 200);
            this.Controls.Add(this.tbweather);
            this.Controls.Add(this.cbareaSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btWeatherGet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btWeatherGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbareaSelect;
        private System.Windows.Forms.TextBox tbweather;
    }
}

