using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    public abstract class V2Data {
        public string Key { get; } // Сеттеры не нужны поскольку мы не реализуем их в наследуемых классах
        public DateTime Date { get; }
        public V2Data(string key, DateTime date) {
            this.Key = key;
            this.Date = date;
        }
        public abstract double MinField { get; }
        public override string ToString() {
            return string.Format("{0} {1}", Key, Date);
        }
        public abstract string ToLongString(string format);
    }
}
