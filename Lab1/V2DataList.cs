using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab1 {
    public class V2DataList : V2Data {
        public delegate DataItem FDI(double x);
        public List<DataItem> DataList { get; set; }
        /*
        конструктор V2DataList (string key, DateTime date)
        для инициализации данных базового класса; в этом конструкторе распределяется память для коллекции List<DataItem>;   
        */
        public V2DataList(string key, DateTime date) : base(key, date) {
            DataList = new List<DataItem>();
        }
        /*
        конструктор 
        V2DataList (string key, DateTime date, double[] x, FDI F), 
        в который через параметр double[] x передается ссылка на массив с координатами, в которых измерено поле; 
        для каждого элемента массива вызывается метод F, который вычисляет значения поля y1,y2; создаётся и 
        добавляется в коллекцию List<DataItem> элемент DataItem; для равных элементов массива x в коллекцию 
        добавляется только один элемент DataItem; 
        */
        public V2DataList(string key, DateTime date, double[] x, FDI F) : this(key, date) {
            foreach(var elem in x) {
                DataList.Add(F(elem));
            }
        }
        // реализацию абстрактного свойства MinField типа double, которое возвращает минимальное абсолютное значение компонент поля (среди всех элементов List<DataItem>);
        public override double MinField => DataList.Min(data => Math.Min(Math.Abs(data.fields[0]), Math.Abs(data.fields[1])));

        /*
        Cвойство типа V2DataArray (только с методом get), которое возвращает объект типа V2DataArray, инициализированный данными класса;
        */
        public V2DataArray Property {
            get {
                double[] net = DataList.Select(cur => cur.x).ToArray();
                double[,] fieldsInNet = new double[2, DataList.Count];
                for (int i = 0; i < DataList.Count; i++) {
                    fieldsInNet[0, i] = DataList[i].fields[0];
                    fieldsInNet[1, i] = DataList[i].fields[1];
                }
                return new V2DataArray(Key, Date) {
                    Net = net,
                    FieldsInNet = fieldsInNet
                };
            }
        }
        /*
        Перегруженную (override) версию виртуального метода string ToString(), который возвращает строку с именем типа 
        объекта, данными базового класса и числом элементов в списке List<DataItem>;
        */
        public override string ToString() {
            return string.Format("V2DataList {0} {1}", base.ToString(), DataList.Count);
        }
        /*
        реализацию абстрактного метода string ToLongString(string format), который возвращает строку с 
        такими же данными, что и метод ToString(), и дополнительно информацию о  каждом элементе из List<DataItem> – 
        координату точки измерения и значения поля; параметр format задает формат вывода чисел с плавающей запятой.
        */
        public override string ToLongString(string format) {
            StringBuilder output = new StringBuilder();
            output.AppendLine(ToString());
            foreach (DataItem item in DataList) {
                output.AppendLine(item.ToLongString(format));
            }
            return output.ToString();
        }
    }
}
