using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    // 設定
    public class Settings {

        private static Settings singleton;

        private Settings() {}

        public static Settings getInstance() {
            if(singleton == null) {
                singleton = new Settings();
            }
            return singleton;
        }

        public int MainFormColor { get; set; }
    }
}
