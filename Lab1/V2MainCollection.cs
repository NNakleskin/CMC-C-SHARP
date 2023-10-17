using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    public class V2MainCollection : System.Collections.ObjectModel.ObservableCollection<V2Data> {
        public bool Contains(string key) {
            return Items.Any(elem => elem.Key == key);
        }
        public new bool Add(V2Data v2Data) {
            foreach (var item in Items) {
                if (item.Key == v2Data.Key) { return false; }
            }
            base.Add(v2Data);
            return true;
        }
        public V2MainCollection(int nV2DataArray, int nv2DataList) {
            Random rnd = new Random();
            string key = "";
            var iso8601String = "20221017T07:12:52Z";
            DateTime date = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ", System.Globalization.CultureInfo.InvariantCulture);
            Items.Add(new V2DataArray(key, date, new double[] { 2 }, Programm.func1));
            for (int i = 0; i < nV2DataArray; i++) {
                int leng = rnd.Next(1, 10);
                double[] x = Enumerable.Range(0, leng).Select(_ => rnd.NextDouble()).ToArray();
                Items.Add(new V2DataArray(key, date, x, Programm.func1));
            }
            for (int i = 0; i < nv2DataList; i++) {
                int leng = rnd.Next(1, 10);
                double[] x = Enumerable.Range(0, leng).Select(_ => rnd.NextDouble()).ToArray();
                Items.Add(new V2DataList(key, date, x, Programm.func2));
            }
        }
        public string ToLongString(string format) {
            var output = new StringBuilder();
            foreach (var item in Items) {
                output.Append(string.Format("{0}\n", item.ToLongString(format)));
            }
            return string.Format("{0}", output);
        }
        public override string ToString() {
            var output = new StringBuilder();
            foreach (var item in Items) {
                output.Append(string.Format("{0}\n", item.ToString()));
            }
            return output.ToString();
        }
    }
}
