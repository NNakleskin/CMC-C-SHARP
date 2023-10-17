using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab1 {
    public delegate void FValues(double x, ref double y1, ref double y2);
    public class V2DataArray : V2Data {
        public double[] Net { get; set; }
        public double[,] FieldsInNet { get; set; }
        public V2DataArray(string key, DateTime date) : base(key, date) {
            Net = new double[0];
            FieldsInNet = new double[2, Net.Length];
        }
        public V2DataArray(string key, DateTime date, double[] x, FValues F) : base(key, date) {
            Net = (double[])x.Clone();
            FieldsInNet = new double[2, Net.Length];
            for (int i = 0; i < Net.Length; ++i) {
                F(Net[i], ref FieldsInNet[0, i], ref FieldsInNet[1, i]);
            }
        }
        public V2DataArray(string key, DateTime date, int nX, double xL, double xR, FValues F) : base(key, date) {
            Net = new double[nX];
            FieldsInNet = new double[2, Net.Length];
            double step = (double)(xR - xL) / (nX - 1);
            for (int i = 0; i < nX; ++i) {
                Net[i] = xL + step * i;
                F(Net[i], ref FieldsInNet[0, i], ref FieldsInNet[1, i]);
            }
        }
        public double[] this[int index] {
            get {
                if (index != 0 && index != 1) throw new ArgumentOutOfRangeException("The dimension number must be 0 or 1.");
                double[] ret = new double[FieldsInNet.GetLength(index)];
                for (int i = 0; i < ret.Length; ++i) {
                    ret[i] = (double)FieldsInNet[index, i];
                }
                return ret;
            }
        }
        public static explicit operator V2DataList(V2DataArray source) {
             V2DataList res = new V2DataList(source.Key, source.Date);
            for (int i = 0; i < source.Net.Length; ++i) {
                DataItem cur = new DataItem(source.Net[i], source.FieldsInNet[0, i], source.FieldsInNet[1, i]);
                res.DataList.Add(cur); 
            }
            return res;
        }
        public override double MinField {
            get {
                double min = double.MaxValue;
                foreach (double elem in FieldsInNet) {
                    min = Math.Min(min, Math.Abs(elem));
                }
                return min;
            }
        }
        public override string ToString() {
            return string.Format("V2DataArray {0}", base.ToString());
        }
        public override string ToLongString(string format) {
            var output = new StringBuilder();
            output.Append(ToString() + "\n");
            for (int i = 0; i < Net.Length && i < FieldsInNet.GetLength(1); ++i) {
                output.Append(string.Format("{0} {1} {2}\n", Net[i].ToString(format), FieldsInNet[0, i].ToString(format), FieldsInNet[1, i].ToString(format)));
            }
            return output.ToString();
        }
    }
}
