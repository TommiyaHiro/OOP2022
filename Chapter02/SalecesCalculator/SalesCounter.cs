using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalecesCalculator {
    public class SalesCounter {
        private List<Sale> _sales; // csvファイルから読み込んだデータ

        // コンストラクタ
        public SalesCounter(List<Sale> sales)
        {
            _sales = sales;
        }
        //　店舗別売上を求める
        public Dictionary<string, int> GetPerStoreSales()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach(Sale sale in _sales)
            {
                if(dict.ContainsKey(sale.ProductCategory))
                    dict[sale.ProductCategory] += sale.Amount;
                else
                    dict[sale.ProductCategory] = sale.Amount;
            }
            return dict;
        }
    }
}
