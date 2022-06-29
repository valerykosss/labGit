using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

/*Создать класс Train: Пункт назначения, Номер поезда,
Время отправления, Число мест (общих, купе, плацкарт,
люкс). Свойства и конструкторы должны обеспечивать
проверку корректности. Добавить метод вывода общего
числа мест в поезде.
Создать массив объектов. Вывести:
a) список поездов, следующих до заданного пункта
назначения;
b) список поездов, следующих до заданного пункта назначения
и отправляющихся после заданного часа;*/

namespace lab3
{
    //внутренний, доступен только из собственной сборки
    internal partial class Train
    {
        //все поля public из-за инициализаторов объекта trainFour
        private static DateTime globalStartTime;
        private readonly Guid id;
        private string destination;//тут вопрос??????
        //[Required(ErrorMessage = "destination не установлен", AllowEmptyStrings = false)] работает только при инициализаторах
        public string Destination
        {
            set {
                if (!String.IsNullOrEmpty(value))
                {
                    destination = value;
                }
                else
                    Console.WriteLine("destination не установлен");
            }
            get => destination;
        }
        //public get, но private set т.к. getter нужен из другого класса
        public int trainNumber { get; private set; }
        //public get, но private set т.к. getter нужен из другого класса
        public int hourOfDeparture { get; private set; }

        public struct TypesOfSeats
        {
            public int commonSeatsCount;
            public int compartmentSeatsCount;
            public int reservedSeatsCount;
            public int luxSeatsCount;

            public TypesOfSeats(int commonSeatsCount, int compartmentSeatsCount, int reservedSeatsCount, int luxSeatsCount)
            {
                this.commonSeatsCount = commonSeatsCount;
                this.compartmentSeatsCount = compartmentSeatsCount;
                this.reservedSeatsCount = reservedSeatsCount;
                this.luxSeatsCount = luxSeatsCount;
            }
        }
        /*private int commonSeatsCount { get; set; }
        private int compartmentSeatsCount { get; set; }
        private int reservedSeatsCount { get; set; }
        private int luxSeatsCount { get; set; }*/
        private const string belTrain = "БЧ";
        //Кол-во созданных объектов
        public static int trainsCount { get; private set; }

        /*singleton 
           скрыть конструктор по умолчанию и создать публичный статический метод, 
           который и будет контролировать жизненный цикл объекта-одиночки.
         1) Добавьте в класс приватное статическое поле, которое будет содержать одиночный объект.
         2) Объявите статический создающий метод, который будет использоваться для получения одиночки.
         3) Добавьте «ленивую инициализацию» (создание объекта при первом вызове метода) в создающий метод одиночки.
         4) Сделайте конструктор класса приватным.
         5) В клиентском коде замените вызовы конструктора одиночка вызовами его создающего метода.*/
        // Конструктор Одиночки всегда должен быть скрытым, чтобы предотвратить
        // создание объекта через оператор new.
        private Train() 
        {
            this.id = Guid.NewGuid();
            trainsCount++;
        }
        // Объект одиночки храниться в статичном поле класса
        //ОБЪЕКТ ОДИНОЧКИ(instance) 
        private static Train instance;
        private static Train.TypesOfSeats instanceTypeSeats;
        // При первом запуске, он создаёт экземпляр одиночки и помещает его в
        // статическое поле. При последующих запусках, он возвращает клиенту
        // объект, хранящийся в статическом поле.
        public static Train GetInstance()
        {
            if (instance == null)
            {
                instance = new Train();
                instanceTypeSeats = new Train.TypesOfSeats();
            }
            return instance;
        }
        public static void ShowTrainSingletonInfo()
        {
            Console.WriteLine($"SINGLETON TRAIN {belTrain}  Пункт назначения: {instance.destination} Номер поезда: {instance.trainNumber}  Время отправления: {instance.hourOfDeparture}" +
                $"  Количество общих мест: {instanceTypeSeats.commonSeatsCount}  Количество купе мест: {instanceTypeSeats.compartmentSeatsCount}  Количество плацкартных мест: {instanceTypeSeats.reservedSeatsCount}" +
                $"  Количество люкс мест: {instanceTypeSeats.luxSeatsCount} ID: {instance.id}");
        }

        /*1) в статических конструкторах нельзя использовать ключевое слово this
          2) не принимают параметров
          3) можно обращаться только к статическим членам класса
          4) нельзя вызывать вручную
          5) выполняются автоматически при самом первом создании объекта данного класса или при первом обращении к его статическим членам (если таковые имеются)
          6) статические конструкторы обычно используются для инициализации статических данных, либо же выполняют действия, которые требуется выполнить только один раз*/
        static Train()
        {
            Console.WriteLine("Static constructor, создан первый объект");
            globalStartTime = DateTime.Now;

            // эта строка выведется только в самом начале
            Console.WriteLine($"Static constructor sets global start time to {globalStartTime.ToLongTimeString()}");
            trainsCount = 0;
        }


        //РАСКОММЕНТИТЬ ЭТОТ И ЗАКОММЕНТИТЬ private construcor
        /*public Train()
        {
            this.id = Guid.NewGuid();
            trainsCount++;
            Console.WriteLine("\nConsructor without params");
        }*/
        public Train(string destination, int trainNumber = 10, int timeOfDeparture = 14, TypesOfSeats seatsInfo)// int commonSeatsCount = 10, int compartmentSeatsCount = 20, int reservedSeatsCount = 30, int luxSeatsCount = 40 )
        {
            if (!String.IsNullOrEmpty(destination) && trainNumber != 0 && timeOfDeparture!=0) //&& commonSeatsCount!=0 && compartmentSeatsCount!=0 && reservedSeatsCount!=0 && luxSeatsCount!=0)
            {
                Console.WriteLine("\nConsructor with params and default params");
                this.destination = destination;
                this.trainNumber = trainNumber;
                this.hourOfDeparture = timeOfDeparture;
                this.seatsInfo = new Train.TypesOfSeats(commonSeatsCount: 10, compartmentSeatsCount: 20, reservedSeatsCount: 30, luxSeatsCount: 40);
                /*this.commonSeatsCount = commonSeatsCount;
                this.compartmentSeatsCount = compartmentSeatsCount;
                this.reservedSeatsCount = reservedSeatsCount;
                this.luxSeatsCount = luxSeatsCount;*/
                this.id = Guid.NewGuid();
                trainsCount++;
            }
            else
                Console.WriteLine("Ошибка");//не зайдет же все равно?
        }

        public Train(string destination, int trainNumber)
        {
            if (!String.IsNullOrEmpty(destination) && trainNumber != 0)
            {
                Console.WriteLine("\nConsructor 1 with params");
                this.destination = destination;
                this.trainNumber = trainNumber;
                this.id = Guid.NewGuid();
                trainsCount++;
            }
            else
                Console.WriteLine("Ошибка");//не зайдет же все равно?
        }


        public Train(int trainNumber, int timeOfDeparture)
        {
            if (trainNumber != 0 && timeOfDeparture !=0)
            {
                Console.WriteLine("\nConsructor 2 with params");
                this.trainNumber = trainNumber;
                this.hourOfDeparture = timeOfDeparture;
                this.id = Guid.NewGuid();
                trainsCount++;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{belTrain}  Пункт назначения: {destination} Номер поезда: {trainNumber}  Время отправления: {hourOfDeparture}" +
                $"  Количество общих мест: {commonSeatsCount}  Количество купе мест: {compartmentSeatsCount}  Количество плацкартных мест: {reservedSeatsCount}" +
                $"  Количество люкс мест {luxSeatsCount} ID {id}");
        }


        //В CodeFile1.cs!
        /*public void GetTotalSeatsNumber()
        {
            Console.WriteLine($"Общее число мест по этому маршруту {this.commonSeatsCount + this.compartmentSeatsCount + this.reservedSeatsCount + this.luxSeatsCount}");
        }*/

        public void TravelTimeByNow()
        {
            /*TimeSpan is a duration, not a time. For example, if you subtract a DateTime
             * from another, you get a TimeSpan. If you add a TimeSpan to a DateTime, 
             * you geta new DateTime.*/

            TimeSpan timeInRouteByNow = DateTime.Now - globalStartTime;
            Console.WriteLine($"{this.trainNumber} is starting its route {timeInRouteByNow} minutes after global start time {globalStartTime.ToShortTimeString()}");
        }


        public override int GetHashCode()
        {
            return this.trainNumber.GetHashCode();
        }


        public override string ToString()
        {
            StringBuilder forToString = new StringBuilder();
            forToString.AppendFormat($" ВЫВЕДЕНО ЧЕРЕЗ override string ToString() {belTrain}  Пункт назначения: {destination} Номер поезда: {trainNumber}  Время отправления: {hourOfDeparture}" +
                $"  Количество общих мест: {commonSeatsCount}  Количество купе мест: {compartmentSeatsCount}  Количество плацкартных мест: {reservedSeatsCount}" +
                $"  Количество люкс мест {luxSeatsCount} ID {id}");
            return forToString.ToString();
        }

        /*Equals принимает в качестве параметра объект любого типа, 
         * который мы затем приводим к текущему, если они являются 
         * объектами одного класса. Затем сравниваем по именам. Если 
         * номера равны, возвращаем true, что будет говорить, что 
         * объекты равны. */
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Train train = (Train)obj;
            return (this.trainNumber == train.trainNumber);
        }

        public void GetTrainNumberRef(ref int trainNumber)
        {
            trainNumber+=10;
        }

        public void GetTrainNumberOut(out int trainNumber)
        {
            trainNumber = this.trainNumber;
        }
        ~Train() { Console.WriteLine("Object is destroyed"); }
    }

    class TrainsArray
    {
        Train[] trainsArray;
        public TrainsArray()
        {
            trainsArray = new Train[2];
        }
            // индексатор
        public Train this[int index]
        {
            get => trainsArray[index];
            set { trainsArray[index] = value; }
        }
    }
    class Program
    {
            static void Main(string[] args)
            {
                //статический конструктор срабатывает

                //конструктор без параметров по умолчанию, если он не закомменчен, в противном использ с парам и парам по умолч
                Train trainOne= new Train(trainNumber: 112, timeOfDeparture: 16);
                trainOne.Destination = ""; //для валидации в геттере. выведет else
                trainOne.Destination = "mogilev";

                trainOne.ShowInfo();
                trainOne.GetTotalSeatsNumber();
                Console.WriteLine();

                //конструктор c параметрами по умолчанию
                Train trainTwo= new Train(destination: "grodno", trainNumber: 10); //если где-то 0, не пройдет валидацию в if
                Console.WriteLine(trainTwo.ToString());
                trainTwo.GetTotalSeatsNumber();
                Console.WriteLine(trainTwo.GetHashCode());

                Console.WriteLine();

                //конструктор с параметрами по умолчанию
                Train trainThree = new Train(destination: "mogilev");
                trainThree.ShowInfo();
                trainThree.GetTotalSeatsNumber();

                Console.WriteLine();
                int refTrain = 222;
                Console.WriteLine($"Перед вызовом метода c передачей ref----{refTrain}");
                trainThree.GetTrainNumberRef(ref refTrain);
                Console.WriteLine($"После вызова метода с передачей ref----{refTrain}");

                //можно создавать переменную с out в параметрах
                trainThree.GetTrainNumberOut(out int outTrain);
                Console.WriteLine($"Результат метода c передачей out----{outTrain}");

                trainOne.TravelTimeByNow();
                /*Приостанавливает текущий поток на указанное количество миллисекунд*/
                System.Threading.Thread.Sleep(25);
                trainTwo.TravelTimeByNow();
                Console.WriteLine();

                Console.WriteLine(trainThree.Equals(trainTwo));//должно быть равно, т.к. номера поездов равны
            
                //доступ только через Train.
                Train trainFive = Train.GetInstance();
                Train trainSix = Train.GetInstance();
                Train.ShowTrainSingletonInfo();

                if (trainFive == trainSix)
                {
                    Console.WriteLine("Singleton works, both variables contain the same instance." +
                        "ТО ЕСТЬ trainFive и trainSix содержат один и тот же экземпляр объекта, т.к." +
                        " этот экземпляр единственный");
                }
                else
                {
                    Console.WriteLine("Singleton failed, variables contain different instances." +
                        "ТО ЕСТЬ trainFive и trainSix НЕ содержат один и тот же экземпляр объекта, " +
                        "что НЕВЕРНО, тк по идее должны содержать единственный!");
                }

                /*Первый параметр указывает на полное имя класса с пространством имен. В данном случае
                * класс Train находится в пространстве имен lab3. Второй параметр указывает, будет ли
                 * генерироваться исключение, если класс не удастся найти. В данном случае значение false означает,
                 * что исключение не будет генерироваться. И третий параметр указывает, надо ли учитывать регистр
                 * символов в первом параметре. Значение true означает, что регистр игнорируется.*/
                Type myType = Type.GetType("lab3.Train", false, true);

                /*Свойство MemberType возвращает значение из перечисления MemberTypes, в котором определены различные типы:
                    MemberTypes.Constructor
                    MemberTypes.Method
                    MemberTypes.Field
                    MemberTypes.Event
                    MemberTypes.Property
                    MemberTypes.NestedType
                Вместо получения всех отдельных частей типа через метод GetMembers() 
                можно по отдельности получать различные методы, свойства и т.д. через специальные методы.*/
                Console.WriteLine("---------------------------------------------");
                foreach (MemberInfo mi in myType.GetMembers())
                {
                    Console.WriteLine($"{mi.DeclaringType} {mi.MemberType} {mi.Name}");
                }

                Console.WriteLine($"Общее кол-во поездов {Train.trainsCount}");
                Train[] trainsArray = { trainOne, trainTwo, trainThree, trainFive, trainSix };
                foreach (Train train in trainsArray)
                {
                    if (train.Destination == "mogilev")
                    {
                        Console.WriteLine($"Номера поездов, следующего до {train.Destination}----{train.trainNumber}");
                    }
                }

                Console.WriteLine();
                foreach (Train train in trainsArray)
                {
                    if (train.hourOfDeparture > 13 && train.Destination == "mogilev")
                    {
                        Console.WriteLine($"Номера поездов, следующего до {train.Destination} позднее 13 ----{train.trainNumber} со временем отправления {train.hourOfDeparture}");
                    }
                }
                TrainsArray trainsArrayforIndexation = new TrainsArray();
                trainsArrayforIndexation[0] = new Train (destination: "brest");
                trainsArrayforIndexation[1] = new Train (destination: "gomel", trainNumber: 11);

                Train exampleOftrainsArrayforIndexation = trainsArrayforIndexation[0];
                Console.WriteLine(exampleOftrainsArrayforIndexation.hourOfDeparture);


                Console.ReadKey();
            }
    }
}
