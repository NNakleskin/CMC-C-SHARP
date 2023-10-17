using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1 {
    public static class Programm {
        public static void func1(double x, ref double y1, ref double y2) {
            y1 = x;
            y2 = x * x;
        }
        public static DataItem func2(double x) => new DataItem(x, x, x * x);
        private static void Main() {
            Console.WriteLine("Task1\n");
            Task1();
            Console.WriteLine(".....\n");
            Console.WriteLine("Task2\n");
            Task2();
            Console.WriteLine(".....\n");
            Console.WriteLine("Task3\n");
            Task3_4();
        }
        private static void Task1() {
            var iso8601String = "20221017T07:12:52Z";
            DateTime date = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ",
                                            System.Globalization.CultureInfo.InvariantCulture);
            V2DataArray obj = new V2DataArray("question_1", date, 5, 6, 12, func1);
            string format = "F3";
            Console.WriteLine(obj.ToLongString(format));
            V2DataList new_list = (V2DataList)obj;
            Console.WriteLine(new_list.ToLongString(format));
        }
        private static void Task2() {
            var iso8601String = "20221017T07:12:52Z";
            DateTime date = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ",
                                            System.Globalization.CultureInfo.InvariantCulture);
            double[] x = new double[] { 1, 4, 6, 9, 10, 12, 15, 16, 18, 20 };
            V2DataList list = new V2DataList("question_2", date, x, func2);
            string format = "F3";
            Console.WriteLine(list.Property.ToLongString(format));
        }
        private static void Task3_4() {
            V2MainCollection col = new V2MainCollection(3, 3);
            string format = "F3";
            Console.WriteLine(col.ToLongString(format));
            foreach (var elem in col) {
                Console.WriteLine(elem.MinField);
            }
        }
    }
}
