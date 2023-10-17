using System.Runtime.CompilerServices;
/*
override - перегруженная версия метода
*/
namespace Lab1 {
    public struct DataItem {
        public double x { get; set; } // Автоматическая генерация геттеров и сеттеров это удобно:))
        public double[] fields { get; set; }
        public DataItem(double x, double y1, double y2) { // Базовый конструктор
            this.fields = new double[2];
            this.fields[0] = y1;
            this.fields[1] = y2;
            this.x = x;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", x, fields[0], fields[1]);
        }
        public string ToLongString(string format) {
            return string.Format("{0} {1} {2}", x.ToString(format), fields[0].ToString(format), fields[1].ToString(format));
        }
    }
}

