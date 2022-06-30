using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Train
    {
        public Train(int HourOfDeparture, int HourOfArrival, int TrainCost, int Speed, string Destination)
        {
            this.HourOfDeparture = HourOfDeparture;
            this.HourOfArrival = HourOfArrival;
            this.TrainCost = TrainCost;
            this.Speed = Speed;
            this.Destination = Destination;
        }
        public int HourOfDeparture { get; set; }
        public int HourOfArrival { get; set; }
        public double TrainCost { get; set; }
        public float Speed { get; set; }
        public string Destination { get; set; }
    }
    class Car : IComparable, IComparer<Car>
    {
        public string Destination { get; set; }
        public string СarRegistrationNumber { set; get; }
        public int СarRegionNumber { set; get; }
        public int Fuel { set; get; }
        public double VehicleCost { get; set; }
        public float Speed { get; set; }
        public string CarBrand { get; set; }
        public Car(int Hours, int Minutes, string СarRegistrationNumber, int СarRegionNumber, string CarBrand, int Speed, int Fuel, int VehicleCost, string Destination)
        {
            this.Minutes = Minutes;
            this.Hours = Hours;
            if (hours >= 0 && hours < 6)
            {
                this.Time = "Ночь";
            }
            else if (hours >= 6 && hours < 12)
            {
                this.Time = "Утро";
            }
            else if (hours >= 12 && hours < 16)
            {
                this.Time = "День";
            }
            else if (hours >= 17 && hours < 24)
            {
                this.Time = "Вечер";
            }
            this.СarRegionNumber = СarRegionNumber;
            this.СarRegistrationNumber = СarRegistrationNumber;
            this.CarBrand = CarBrand;
            this.Speed = Speed;
            this.Fuel = Fuel;
            this.VehicleCost = VehicleCost;
            this.Destination = Destination;
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
            return "Time of car's departure: " + Hours + ":" + Minutes + ", Period of the day: " + Time + ", Car's Brand:" + CarBrand + " Car's Registration Number:" + СarRegistrationNumber + " Сar's Region Number:"
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
        public string Time { get; set; }
        private int hours;
        private int minutes;
        public int Hours
        {
            get => hours;
            set
            {
                if (value > 23) hours = 23;
                else if (value < 0) hours = 0;
                else hours = value;
            }
        }
        public int Minutes
        {
            get => minutes;
            set
            {
                if (value > 60) minutes = 59;
                else if (value < 0) minutes = 0;
                else minutes = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //ЗАДАНИЕ 1
            string[] monthsInAYear = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            //запрос возвращающий  последовательность месяцев с длиной строки равной n
            Console.Write("Enter n(length of the month): ");
            int length = Convert.ToInt32(Console.ReadLine());

            var selectedMonthsWithNLength = monthsInAYear.Where(m => m.Length == length);
            /*var selectedMonthsWithNLength = from m in monthsInAYear
                                            where m.Length == length
                                            select m;*/
            foreach (string item in selectedMonthsWithNLength)
                Console.Write(item + " ");

            //запрос возвращающий только летние и зимние месяцы
            string[] summerWinterMonths = { "January", "February", "June", "July", "August", "December" };
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Show only winter and summer months: ");
            var selectedSummerWinterMonths = monthsInAYear.Intersect<string>(summerWinterMonths); // Intersect - пересечение последовательностей (выбор общих элементов) 
            foreach (string item in selectedSummerWinterMonths)
                Console.Write(item + " ");
            Console.WriteLine();
            Console.WriteLine();
            //запрос вывода месяцев в алфавитном порядке
            var monthsInAlphabeticalOrder = from m in monthsInAYear
                                            orderby m
                                            select m;
            Console.WriteLine("\nShow months in alphabetical order: ");
            foreach (string item in monthsInAlphabeticalOrder)
                Console.Write(item + " ");
            Console.WriteLine();
            Console.WriteLine();
            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4 - х
            var monthsContainU = from m in monthsInAYear
                                 where m.Contains("u")
                                 select m;
            /*foreach (string item in monthsContainU) 
                Console.Write(item + " ");*/
            var selectedMonthsWithLengthMoreThan4 = from m in monthsInAYear
                                                    where m.Length >= 4
                                                    select m;
            /*foreach (string item in selectedMonthsWithLengthMoreThan4) 
                Console.Write(item + " ");*/
            var monthsWithUAndLengthMoreThan4 = monthsContainU.Intersect<string>(selectedMonthsWithLengthMoreThan4);
            Console.WriteLine("\nShow months with 'u' and length=>4 ");
            foreach (string item in monthsWithUAndLengthMoreThan4)
                Console.Write(item + " ");

            //ЗАДАНИЕ 2
            List<Car> cars = new List<Car>();
            Car car1 = new Car(Hours: 2, Minutes: 15, СarRegistrationNumber: "1231", СarRegionNumber: 2, CarBrand: "BMW", Speed: 70, Fuel: 8, VehicleCost: 5000, Destination: "Minsk");
            Car car2 = new Car(Hours: 7, Minutes: 20, СarRegistrationNumber: "2145", СarRegionNumber: 7, CarBrand: "Mercedes", Speed: 80, Fuel: 6, VehicleCost: 7000, Destination: "Mihailosk");
            Car car3 = new Car(Hours: 13, Minutes: 13, СarRegistrationNumber: "7745", СarRegionNumber: 5, CarBrand: "Lamborghini", Speed: 120, Fuel: 11, VehicleCost: 12000, Destination: "Brest");
            Car car4 = new Car(Hours: 20, Minutes: 25, СarRegistrationNumber: "7325", СarRegionNumber: 3, CarBrand: "Tesla", Speed: 140, Fuel: 10, VehicleCost: 14000, Destination: "Mitinsk");
            Car car5 = new Car(Hours: 21, Minutes: 35, СarRegistrationNumber: "7155", СarRegionNumber: 1, CarBrand: "Mazda", Speed: 100, Fuel: 9, VehicleCost: 8000, Destination: "Minusinsk");
            Car car6 = new Car(Hours: 2, Minutes: 10, СarRegistrationNumber: "1531", СarRegionNumber: 4, CarBrand: "BMW", Speed: 90, Fuel: 9, VehicleCost: 5000, Destination: "Vitebsk");
            Car car7 = new Car(Hours: 13, Minutes: 13, СarRegistrationNumber: "7012", СarRegionNumber: 3, CarBrand: "Volvo", Speed: 60, Fuel: 6, VehicleCost: 7000, Destination: "Miaskiy");
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            cars.Add(car4);
            cars.Add(car5);
            cars.Add(car6);
            cars.Add(car7);
            foreach (Car item in cars)
                item.ToString();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //ЗАДАНИЕ 3
            //время с заданным значением часов;

            Console.Write("Enter hours: ");
            int hour = Convert.ToInt32(Console.ReadLine());
            var carWithEnteredHour = from c in cars
                                     where c.Hours == hour
                                     select c;
            foreach (Car c in carWithEnteredHour)
                Console.WriteLine(c.ToString());

            //списки по группам ночь, утро, день, вечер
            var carGroupsByDayTime = from c in cars
                                     group c by c.Time;
            Console.WriteLine();
            Console.WriteLine("Groups of cars in list by their day time:");
            foreach (IGrouping<string, Car> carItems in carGroupsByDayTime)
            {
                Console.Write($"{carItems.Key}:");
                foreach (var c in carItems)
                    Console.Write($" {c.CarBrand},");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            //минимальное время
            var minHourOfAllCarsInList = cars.Min(c => c.Hours);

            var carsWithMinHour = from c in cars
                                  where c.Hours == minHourOfAllCarsInList
                                  select c;

            var minMinutesOfCarsWithMinHour = carsWithMinHour.Min(c => c.Minutes);
            var carsWithMinTime = from c in carsWithMinHour
                                  where c.Minutes == minMinutesOfCarsWithMinHour
                                  select c;
            Console.Write("Cars with min hours: minutes: ");
            foreach (Car item in carsWithMinTime)
                Console.WriteLine($"{item.Hours} : {item.Minutes} is {item.CarBrand}");
            Console.WriteLine();
            Console.WriteLine();

            //первое время в котором часы и минуты совпадают
            Car firstCar = cars.First(c => (c.Hours == c.Minutes));
            Console.WriteLine($"First car's time in list where minutes==hours: {firstCar.Hours}:{firstCar.Minutes} is {firstCar.CarBrand}");
            Console.WriteLine();
            Console.WriteLine();

            //упорядоченный список времен
            var selectedOrdH = from c in cars
                               orderby c.Hours, c.Minutes
                               select c;
            Console.WriteLine("Sorted list by hours, minutes: ");
            foreach (Car c in selectedOrdH)
                Console.WriteLine($"{c.Hours}:{c.Minutes}-{c.CarBrand}");
            Console.WriteLine();
            Console.WriteLine();

            //свой оператор условия(выбрала Where он же оператор фильтрации; отложенные вычисления)
            //https://studylib.ru/doc/4267388/2.-bazovye-tehnologii-platformy-.net стр 47
            Console.Write("Enter car brand: ");
            string brand = Console.ReadLine();
            var carWithEnteredBrand = cars.Where(c => c.CarBrand == brand);
            foreach (Car c in carWithEnteredBrand)
                Console.WriteLine(c.ToString());
            Console.WriteLine();
            Console.WriteLine();

            //свой оператор проекций Select отложенные вычисления
            Console.WriteLine("Selection of cars with their СarRegistrationNumber and СarRegionNumber:");
            var carsRegistrationsAndNumbers = cars.Select(c => new { c.СarRegistrationNumber, c.СarRegionNumber });//спросить про SelectMany
            foreach (var c in carsRegistrationsAndNumbers)//var тк anon
                Console.WriteLine($"{c.СarRegistrationNumber} - {c.СarRegionNumber}");
            Console.WriteLine();
            Console.WriteLine();

            //свой оператор упорядочивания OrderByDescending ThenBy
            Console.WriteLine("Sort cars by VehicleCost and Fuel:");
            var carSortByCostAndFuel = cars.OrderByDescending(s => s.VehicleCost).ThenBy(s => s.Fuel);
            foreach (var c in carSortByCostAndFuel)//var тк anon
                Console.WriteLine($"{c.VehicleCost} ; {c.Fuel}");
            Console.WriteLine();
            Console.WriteLine();
            //свой оператор группировки 
            var carGroupByCost = cars.GroupBy(c => c.VehicleCost);
            Console.WriteLine("Groups of cars in list by their cost:");
            foreach (IGrouping<double, Car> carItems in carGroupByCost)
            {
                Console.Write($"Cars that cost {carItems.Key}:");
                foreach (var c in carItems)
                    Console.Write($" {c.CarBrand},");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            //свой оператор агрегирования Min, Max, Average
            double minCarCost = cars.Min(c => c.VehicleCost);
            Console.WriteLine("Min car cost: " + minCarCost);
            Console.WriteLine();
            Console.WriteLine();

            double maxCarCost = cars.Max(c => c.VehicleCost);
            Console.WriteLine("Max car cost: " + maxCarCost);
            Console.WriteLine();
            Console.WriteLine();

            double averageCarCost = cars.Average(c => c.VehicleCost);
            Console.WriteLine("Average car cost: " + averageCarCost);
            Console.WriteLine();
            Console.WriteLine();
            //свой оператор кванторов
            var carsRegisterNumberStartWith7 = cars.Any(c => c.СarRegistrationNumber.StartsWith("7"));
            var carsRegisterNumberStartWith3 = cars.Any(c => c.СarRegistrationNumber.StartsWith("3"));
            Console.WriteLine("Does list has car/cars with registration number which starts with '7': " + carsRegisterNumberStartWith7);
            Console.WriteLine("Does list has car/cars with registration number which starts with '3': " + carsRegisterNumberStartWith3);
            Console.WriteLine();
            Console.WriteLine();
            //свой оператор разбиения
            var carSkipTake = cars.Skip(2).Take(3);
            foreach (Car item in carSkipTake)
                Console.WriteLine($"{item.CarBrand}");
            Console.WriteLine();
            Console.WriteLine();

            //свой join
            List<Train> trains = new List<Train>();
            Train train1 = new Train(HourOfDeparture: 14, HourOfArrival: 16, TrainCost: 120000, Speed: 300, Destination: "Minsk");
            Train train2 = new Train(HourOfDeparture: 20, HourOfArrival: 23, TrainCost: 150000, Speed: 600, Destination: "Moscow");
            Train train3 = new Train(HourOfDeparture: 2, HourOfArrival: 7, TrainCost: 100000, Speed: 250, Destination: "Minsk");
            trains.Add(train1);
            trains.Add(train2);
            trains.Add(train3);

            var carsAndTrainsJoined = from car in cars
                                      join train in trains on car.Destination equals train.Destination
                                      select new { Destination = car.Destination, Brand = car.CarBrand, Hour=train.HourOfDeparture};

            foreach (var item in carsAndTrainsJoined)
                Console.WriteLine($"Departure: {item.Destination} Brand cars to this place: {item.Brand} Hour of departure of trains to this place: {item.Hour}");

            Car[] carArray1 = { car1, car2, car3, car4 };

            Car[] carArray2 = { car5, car6, car7 };

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Special Request:");
            IEnumerable<Car> specialRequest = carArray1
               .Union(carArray2)  //объединение множеств из двух исходных последовательностей
               .Where(p => p.Destination.Contains("sk"))
               .OrderBy(p => p)//сначала по длине
               .ThenByDescending(p => p.Destination.Contains("M")) //сортирует по убыванию и дополнительному параметру
               .Skip(1); //пропускает n элементов, и возвращает последующие
            foreach (var str in specialRequest)
                Console.Write($"{str.CarBrand}-{str.Destination}({str.Destination.Length})\t");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}