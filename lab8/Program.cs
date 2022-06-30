using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public struct Car
    {
        public int Fuel { set; get; }
        public double VehicleCost { get; set; }
        public float Speed { get; set; }
        public Car(int Speed, int Fuel, int VehicleCost)
        {
            this.Speed = Speed;
            this.Fuel = Fuel;
            this.VehicleCost = VehicleCost;
        }
        public override string ToString()
        {
            return "Info about car: fuel consumption-"+Fuel+"; cost-"+VehicleCost+"; average speed-"+Speed+"\n";
        }
    }
    interface IMyList<T> where T : struct
    {
        MyList<T> RemoveElement(MyList<T> someListForDeleting, T elementToDelete);
        MyList<T> AddElement(MyList<T> someListForAdding, T elementToAdd);
        void ShowInfo();
    }
    public class MyList<T> : IMyList<T> where T : struct //чтобы и на значимые системные и на структуру Car
    {
        public T listElement;
        public List<T> list { get; set; }
        public MyList(List<T> list)
        {
            this.list = list;
        }
        public MyList()
        {
            this.list = new List<T>();
            this.listElement = default(T);
        }
        public MyList(T listElement)
        {
            this.list = new List<T>();
            this.listElement = listElement;
        }
        public MyList<T> RemoveElement(MyList<T> someListForDeleting, T elementToDelete)
        {
            someListForDeleting.list.Remove(elementToDelete);
            return someListForDeleting;
        }
        public MyList<T> AddElement(MyList<T> someListForAdding, T elementToAdd)
        {
            someListForAdding.list.Add(elementToAdd);
            return someListForAdding;
        }
        public void ShowInfo()
        {
            if (this.list.Count == 0)
            {
                throw new Exception("Список пуст");
            }
            Console.Write("Содержимое поля list экземпляра класса MyList: ");
            foreach (T i in this.list)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        public static MyList<T> operator +(MyList<T> someListForAdding, T elementToAdd)
        {
            someListForAdding.list.Insert(0, elementToAdd);
            return someListForAdding;
        }
        public static MyList<T> operator --(MyList<T> someListForDeleting)
        {
            someListForDeleting.list.RemoveAt(someListForDeleting.list.Count - 1);
            return someListForDeleting;
        }
        public static bool operator ==(MyList<T> firstList, MyList<T> secondList)
        {
            return firstList.list.SequenceEqual(secondList.list);
        }
        public static bool operator !=(MyList<T> firstList, MyList<T> secondList) //тк идут парой
        {
            return !(firstList.list.SequenceEqual(secondList.list));
        }
        public static bool operator true(MyList<T> firstList) //тк идут парой
        {
            List<T> listForSecond = firstList.list.ToList();//toList() возвращ новый лист, а не копию на first
            MyList<T> secondList = new MyList<T>(listForSecond);
            firstList.list.Sort();
            if (firstList.list.SequenceEqual(secondList.list)) { return true; }
            else return false;
        }
        public static bool operator false(MyList<T> firstList)
        {
            MyList<T> secondList = firstList;
            secondList.list.Sort();
            if (!firstList.list.SequenceEqual(secondList.list)) { return false; }
            else return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<int> list = new List<int>() { 2, 6, 3, 11 };
                MyList<int> myList1 = new MyList<int>(list);
                myList1.AddElement(myList1, 7);
                myList1.AddElement(myList1, 12);
                myList1.AddElement(myList1, 1);
                myList1.AddElement(myList1, 9);
                myList1.AddElement(myList1, 15);
                myList1.AddElement(myList1, 13);
                myList1.AddElement(myList1, 21);
                myList1.ShowInfo();
                myList1.RemoveElement(myList1, 1);
                myList1.ShowInfo();
                Console.WriteLine();

                MyList<double> myList2 = new MyList<double>();
                //myList2.ShowInfo(); // выдаст exception
                myList2.AddElement(myList2, 7.2);
                myList2.AddElement(myList2, 4.4);
                myList2.AddElement(myList2, 1.6);
                myList2.AddElement(myList2, 9.8);
                myList2.AddElement(myList2, 15.3);
                myList2.AddElement(myList2, 13.7);
                myList2.AddElement(myList2, 21.5);
                myList2.ShowInfo();
                myList2.RemoveElement(myList2, 1.6);
                myList2.ShowInfo();
                Console.WriteLine();

                Car car1 = new Car(70, 8, 1000);
                Car car2 = new Car(80, 9, 7000);
                MyList<Car> carsList = new MyList<Car>();
                carsList.AddElement(carsList, car1);
                carsList.AddElement(carsList, car2);
                carsList.ShowInfo();
                Console.WriteLine("Нет исключений");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.WriteLine("Блок выполнен");
            }
            Console.ReadKey();
        }
    }
}
