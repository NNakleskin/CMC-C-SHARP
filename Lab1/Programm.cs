using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    public static class Programm {
        public static void func1(double x, ref double y1, ref double y2) {
            y1 = 4 * x;
            y2 = x * x * 2;
        }
        public static DataItem func2(double x) => new DataItem(x, 4 * x, x * x * 2);
        private static void Main() {
            Question1();
            Question2();
            Question3_4();
        }
        private static void Question1() {
            var iso8601String = "20221017T07:12:52Z";
            DateTime date = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ",
                                            System.Globalization.CultureInfo.InvariantCulture);
            V2DataArray obj = new V2DataArray("question_1", date, 5, 6, 12, func1);
            string format = "F3";
            Console.WriteLine(obj.ToLongString(format));
            V2DataList new_list = (V2DataList)obj;
            Console.WriteLine(new_list.ToLongString(format));
        }
        private static void Question2() {
            var iso8601String = "20221017T07:12:52Z";
            DateTime date = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ",
                                            System.Globalization.CultureInfo.InvariantCulture);
            double[] x = new double[] { 1, 4, 6, 9, 10, 12, 15, 16, 18, 20 };
            V2DataList list = new V2DataList("question_2", date, x, func2);
            string format = "F3";
            Console.WriteLine(list.Property.ToLongString(format));
        }
        private static void Question3_4() {
            V2MainCollection col = new V2MainCollection(3, 3);
            string format = "F3";
            Console.WriteLine(col.ToLongString(format));
            foreach (var elem in col) {
                Console.WriteLine(elem.MinField);
            }
        }
    }
}
