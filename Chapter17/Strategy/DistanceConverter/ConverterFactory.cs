﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    class ConverterFactory {
        // あらかじめインスタンスを生成し、配列に入れておく
        private static ConverterBase[] _converters = new ConverterBase[]
            {
                new MeterConverter(),
                new FeetConverter(),
                new YardConverter(),
                new InchConverter(),
                new MileConverter(),
                new KmConverter(),
            };
        public static ConverterBase GetInstance(string name) {
            return _converters.FirstOrDefault(n => n.IsMyUnit(name));
        }
    }
}
