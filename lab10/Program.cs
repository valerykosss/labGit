using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab_10
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Student(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList();
            Random rand = new Random();
            //Создать необобщенную коллекцию ArrayList.
            //a.Заполните ее 5 - ю случайными целыми числами
            for (int i = 0; i < 5; i++)
            {
                arrayList.Add(rand.Next(25));
            }
            //b. Добавьте к ней строку
            string middleName = "Alexsandrovna";
            //c. Добавьте объект типа Student
            Student studentLera = new Student("Valeria", "Koss");
            arrayList.Add(middleName);
            arrayList.Add(studentLera.Name);
            arrayList.Add(studentLera.Surname);
            Console.Write("ArrayList: ");
            foreach (var item in arrayList)
            {
                Console.Write(item + "; ");
            }
            Console.Write($"Count of elements in list: {arrayList.Count}");
            // Удалите заданный элемент
            arrayList.Remove(middleName);
           
            Console.WriteLine();
            Console.Write("ArrayList: ");
            foreach (var item in arrayList)
            {
                Console.Write(item + "; ");
            }
            Console.Write($"Count of elements in list: {arrayList.Count}");

            //Выполните поиск в коллекции значения
            Console.WriteLine();
            Console.Write("Enter the element you want to find: ");
            /*object elemToFind = Console.ReadLine();
            int indexOfElemToFind = arrayList.IndexOf(elemToFind);
            Console.WriteLine($"The first occurrence of {elemToFind} is at index {indexOfElemToFind}");*/

            string elemToFind = Console.ReadLine();
            int counter=0;
            for (int i = 0; i < arrayList.Count; i++)
            {
                bool isFound = false;
                if (elemToFind == arrayList[i].ToString())
                {
                    isFound = true;
                    if (isFound == true)
                    {
                        ++counter;
                        Console.WriteLine($"The index of {elemToFind} is {counter}");
                    }
                }
            }
            int indexOfElemToFind = arrayList.IndexOf("Koss");
            Console.WriteLine($"The index of 'Koss' is {++indexOfElemToFind}");
            bool doesContain = arrayList.Contains("Valeria");
            Console.WriteLine($"Does list contain 'Valeria'? {doesContain}");
            Console.WriteLine();
            Console.WriteLine();

            //SortedList<TKey, TValue>
            SortedList<char, char> sortedList = new SortedList<char, char>();
            sortedList.Add('1', 'a');
            sortedList.Add('2', 'b');
            sortedList.Add('3', 'c');
            sortedList.Add('4', 'd');
            sortedList.Add('5', 'e');
            sortedList.Add('6', 'a');

            ICollection<char> keys = sortedList.Keys; //коллекция ключей
            IList<char> values = sortedList.Values; //коллекция значений

            foreach (char key in keys)//получить значения по ключам
            {
                Console.WriteLine($"Key: {key}, Value: {sortedList[key]}");
            }
            //b.Удалите из коллекции n последовательных элементов добавьте другие элементы
            Console.WriteLine("Enter the position to delete from:");
            int position = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the amount of elements to delete from:");
            int amount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < amount; i++)
            {
                sortedList.RemoveAt(position - 1);
            }
            foreach (char key in keys)//получить значения по ключам
            {
                Console.WriteLine($"Key: {key}, Value: {sortedList[key]}");
            }
            Console.WriteLine();
            Console.WriteLine();


            //Создайте вторую коллекцию (см. таблицу) и заполните ее данными из
            //первой коллекции. перенос значений из sortedList в List<T> 
            Console.WriteLine("Transfer values from sortedList to list: ");
            List<char> list = new List<char>();
            Console.Write("List<char> made up of values: ");
            for (int i = 0; i < sortedList.Count; i++)
            {
                //list.Add(keys[i]);
                list.Add(values[i]);

                Console.Write(list[i] + "; ");
            }
            Console.WriteLine();

            // Найдите во второй коллекции заданное значение
            Console.WriteLine("Enter value to find: ");
            char charValueToFind = (char)Console.Read();
            int count=0;
            bool flag=false;
            for (int i = 0; i < list.Count; i++)
            {
                if (charValueToFind == list[i])
                {
                    flag = true;
                    ++count;
                }
            }
            if (flag == true) Console.WriteLine($"Element occurs in list for {count} times");
            else Console.WriteLine("There is no such element in list");
            Console.WriteLine();
            Console.WriteLine();

            /*Повторите задание п.2 для пользовательского типа данных (в качестве типа 
             * T возьмите любой свой класс из лабораторной №5 (Наследование…. ). Не
              забывайте о необходимости реализации интерфейсов (IComparable,
              ICompare,….). При выводе коллекции используйте цикл foreach*/

           SortedList<char, Car> carSortedList = new SortedList<char, Car>();
            Car car1 = new Car(СarRegistrationNumber:"1231", СarRegionNumber:2, CarBrand:"BMW", Speed:70, Fuel:8, VehicleCost:5000);
            Car car2 = new Car(СarRegistrationNumber:"2145", СarRegionNumber: 7, CarBrand: "Mercedes", Speed: 80, Fuel: 6, VehicleCost: 7000);
            Car car3 = new Car(СarRegistrationNumber: "7745", СarRegionNumber: 5, CarBrand: "Lamborghini", Speed: 120, Fuel: 11, VehicleCost: 12000);
            Car car4 = new Car(СarRegistrationNumber: "7325", СarRegionNumber: 3, CarBrand: "Tesla", Speed: 140, Fuel: 10, VehicleCost: 14000);
            carSortedList.Add('1', car1);
            carSortedList.Add('2', car2);
            carSortedList.Add('3', car3);
            carSortedList.Add('4', car4);
            Console.WriteLine("SortedList<char, Car>: ");
            foreach (Car car in carSortedList.Values)
            {
                Console.WriteLine($"Car's Brand: {car.CarBrand}, Car's Registration Number: {car.СarRegistrationNumber}, Сar's Region Number{car.СarRegionNumber})");
            }

            Console.WriteLine();
            Console.WriteLine();
            List<Car> carList = new List<Car>();

            foreach (char carKey in carSortedList.Keys)
                carList.Add(carSortedList[carKey]);

            Console.WriteLine("Transfer values from carSortedList to carList: ");
            foreach (Car car in carList)
                Console.WriteLine(car.ToString());
            Console.WriteLine();
            Console.WriteLine();

            /*Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте
            произвольный метод и зарегистрируйте его на событие CollectionChange.
            Напишите демонстрацию с добавлением и удалением элементов. В качестве
            типа T используйте свой класс из лабораторной №5 Наследование….*/
            ObservableCollection<Car> carObservable = new ObservableCollection<Car>();
            //Класс ObservableCollection определяет событие CollectionChanged, подписавшись на которое, мы можем обработать любые изменения коллекции
            carObservable.CollectionChanged += CarObservedCollectionChanged;
            carObservable.Add(car1);
            carObservable.Add(car2);
            carObservable.Add(car3);
            carObservable.Add(car4);
            carObservable.RemoveAt(2);//отсчет с 0
            carObservable[1] = car4;

            foreach (Car car in carObservable)
            {
                Console.WriteLine(car.CarBrand);
                //Console.WriteLine(car.ToString());
            }
            Console.ReadKey();

        }
        private static void CarObservedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Car newCar = e.NewItems[0] as Car;
                    Console.WriteLine($"Добавлен новый объект: {newCar.CarBrand}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Car oldCar = e.OldItems[0] as Car;
                    Console.WriteLine($"Удален объект: {oldCar.CarBrand}");
                    break;
                case NotifyCollectionChangedAction.Replace: 
                    Car replacedCar = e.OldItems[0] as Car;
                    Car replacingCar = e.NewItems[0] as Car;
                    Console.WriteLine($"Объект {replacedCar.CarBrand} заменен объектом {replacingCar.CarBrand}");
                    break;
            }
        }

    }
}
class Car : IComparable, IComparer<Car>
{
    public string СarRegistrationNumber { set; get; }
    public int СarRegionNumber { set; get; }
    public int Fuel { set; get; }
    public double VehicleCost { get; set; }
    public float Speed { get; set; }
    public string CarBrand { get; set; }
    public Car(string СarRegistrationNumber, int СarRegionNumber, string CarBrand, int Speed, int Fuel, int VehicleCost)
    {
        this.СarRegionNumber = СarRegionNumber;
        this.СarRegistrationNumber = СarRegistrationNumber;
        this.CarBrand = CarBrand;
        this.Speed = Speed;
        this.Fuel = Fuel;
        this.VehicleCost = VehicleCost;
    }
    public override int GetHashCode()
    {
        return Speed.GetHashCode();
    }
    public override bool Equals(object obj)
    {
        if (obj == null) // проверка, есть ли что в объекте
        {
            Console.WriteLine("Something went wrong!");
            return false;
        }

        obj = obj as Car; //as для привед. объекта к указанному типу, в случае невозможности привести объект к указанному типу мы вместо исключения получим null.

        if (obj != null)
        {
            return true;
        }

        return false;
    }
    public override string ToString()
    {
        return "Car's Brand:" + CarBrand + " Car's Registration Number:" + СarRegistrationNumber + " Сar's Region Number:" 
            + СarRegionNumber + " Speed:" + Speed + " Fuel consumtion:" + Fuel + "liters/km, Car Cost:" + VehicleCost + " ";
    }
    public int CompareTo(Object a)
    {
        Car b = (Car)a;
        if (this.СarRegionNumber < b.СarRegionNumber)
            return -1;
        else if (this.СarRegionNumber > b.СarRegionNumber)
            return 1;
        else
            return 0;
    }
    int IComparer<Car>.Compare(Car x, Car y)
    {
        return String.Compare(x.СarRegistrationNumber, y.СarRegistrationNumber);
    }
}