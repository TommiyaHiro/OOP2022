
using System;

namespace Excercise2 {
    class Program {
        //コマンドライン引数
        static void Main(string[] args) {
            if(args.Length >= 1 && args[0] == "-tof") {
                // インチからメートルへの対応表を出力
                PrintInchToMeterList(1, 10);
            }
            else {
                // メートルからインチへの対応表を出力
                PrintMeterToInchList(1, 10);
            }
        }
        //インチからメートルへの対応表を出力
        private static void PrintInchToMeterList(int start, int stop) {
            //FeetConverter fc = new FeetConverter();
            for(int inch = start; inch <= stop; inch++) {
                double meter = InchConverter.InchToMeter(inch);
                Console.WriteLine("{0} inch = {1:0.0000} m", inch, meter);
            }
        }
        //メートルからインチへの対応表を出力
        private static void PrintMeterToInchList(int start, int stop) {
            //FeetConverter fc = new FeetConverter();
            for(int meter = 1; meter <= 10; meter++) {
                double inch = InchConverter.MeterToInch(meter);
                Console.WriteLine("{0} m = {1:0.0000} inch", meter, inch);
            }
        }
    }
}
