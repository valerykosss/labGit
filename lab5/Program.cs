using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    //Транспортное средство, Автомобиль, Двигатель, Поезд, Экспресс, Двигатель, Вагон.

    interface IMotor
    {
        //объем, расход, тип топлива добавить как свойства??????
        void MotorInfo();
    }
    interface IStopping
    {
        string[] StoppingTypesOfVehicle();
        void Stop();
    }
    abstract class Vehicle: IStopping, IMotor
    {
        protected float Speed { get; set; }
        public abstract void Move();
        public abstract void Stop();
        string[] IStopping.StoppingTypesOfVehicle()
        {
            return new string[] { "Vehicle" };
        }
        void IMotor.MotorInfo() 
        {
            Console.WriteLine("Every vehicle has its own type of engine"); 
        }
    }
    class Car : Vehicle, IStopping, IMotor
    {
        public Car(int Speed)
        {
            this.Speed = Speed;
        }
        public override void Move()
        {
            Console.WriteLine("Car is on its way!!!!");
        }
        public override void Stop()
        {
            Console.WriteLine("Abstract class method with the same name. Transport stopped");
        }
        void IStopping.Stop()
        {
            Console.WriteLine("Interface method with the same name. Transport stopped");
        }
        string[] IStopping.StoppingTypesOfVehicle()
        {
            return new string[] { "Car" };
        }
        public override int GetHashCode()
        {
            return Speed.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) // проверка, есть ли что в объекте
            {
                Console.WriteLine("Somethng went wrong!");
                return false;
            }

            obj = obj as Car; //as для привед. объекта к указанному типу, в случае невозможности привести объект к указанному типу мы вместо исключения получим null.

            if (obj != null)
            {
                Console.WriteLine("It's a car");
                return true;
            }

            Console.WriteLine("It's not a car");
            return false;
        }
        public override string ToString()
        {
            return "override ToString(): Car is on its way with speed " + Speed + " km/h";
        }
        void IMotor.MotorInfo()
        {
            Console.WriteLine("Some info about car engine: bla bla bla");
        }
    }
    //сделать вложением? класса Train(Наоборот короче)
    class Carriage: Vehicle, IStopping, IMotor
    {
        //кол-во мест
        protected int countOfCarriagesInTrain;
        public Carriage(int countOfCarriagesInTrain)
        {
            this.countOfCarriagesInTrain = countOfCarriagesInTrain;
            Speed = 0;
        }
        public override void Move()
        {
            Console.WriteLine("Carriages can be on their way ONLY as a part of Train");
        }
        public override void Stop()
        {
            Console.WriteLine("Abstract class method with the same name. Carriages can be stopped ONLY if it's a part of Train");
        }
        public override string ToString()
        {
            return "override ToString(): Carriages can't be ridden!!! theirs speed is " + Speed + " km/h";
        }
        string[] IStopping.StoppingTypesOfVehicle()
        {
            return new string[] { "Carriage" };
        }
        void IMotor.MotorInfo()
        {
            Console.WriteLine("Carriage doesn't have an engine, only Train has");
        }
    }
    class Train : Carriage, IStopping, IMotor
    {
        //public Carriage carriage { get; set; }
        public float SimpleSpeed = 62.2f;
        public string placeOfDeparture;
        public string placeOfArrival;
        public override void Move()
        {
            Console.WriteLine("Simple train with carriages is on its way");
        }
        public Train(int countOfCarriagesInTrain, string placeOfDeparture, string placeOfArrival) : base(countOfCarriagesInTrain)
        {
            this.placeOfDeparture = placeOfDeparture;
            this.placeOfArrival = placeOfArrival;
        }
        public virtual void TrainInfo()
        {
            Console.WriteLine($"Simple train with {countOfCarriagesInTrain} carriages goes from {placeOfDeparture} to {placeOfArrival} with speed {SimpleSpeed} km/h");
        }
        public override string ToString()
        {
            return "override ToString(): Train is on its way";
        }
        string[] IStopping.StoppingTypesOfVehicle()
        {
            return new string[] { "Train" };
        }
        void IMotor.MotorInfo()
        {
            Console.WriteLine("Some info about train engine: bla bla bla");
        }
    }
    sealed class ExpressTrain : Train, IStopping, IMotor
    {
        public float ExpressSpeed { get { return base.SimpleSpeed * 2; } }
        public ExpressTrain(int countOfCarriagesInTrain, string placeOfDeparture, string placeOfArrival) : base(countOfCarriagesInTrain, placeOfDeparture, placeOfArrival) { }
        public override void Move()
        {
            Console.WriteLine("Express train with carriages is on its way");
        }
        public override void TrainInfo()
        {
            Console.WriteLine($"Express train with {countOfCarriagesInTrain} carriages goes from {base.placeOfDeparture} to {base.placeOfArrival} with speed {ExpressSpeed} km/h");
        }
        string[] IStopping.StoppingTypesOfVehicle()
        {
            return new string[] { "Express Train" };
        }
        public override string ToString()
        {
            return "override ToString(): Express train is on its way";
        }
        void IMotor.MotorInfo()
        {
            Console.WriteLine("Some info about express train engine: bla bla bla");
        }
    }

    class Printer
    {
        public string IAmPrinting(Vehicle someVehicle)//vehicle 
        {
           if(someVehicle is Train)
           {
               someVehicle = someVehicle as Train;
               return String.Format($"({someVehicle.ToString()}");
           }
           else if(someVehicle is Car)
           {
               someVehicle = someVehicle as Car;
                return String.Format($"({someVehicle.ToString()}");
           }
           else if (someVehicle is ExpressTrain)
           {
               someVehicle = someVehicle as ExpressTrain;
                return String.Format($"({someVehicle.ToString()}");

           }
           else
           {
                return String.Format($"Error!");
           }
        }
    }
    class Program
    {
        /*trainInstance.carriage = new Carriage()
            {
                //поля
            };
            Console.WriteLine($"Instance of train has property carriage with data {trainInstance.carriage.св-во}");*/
        static void Main(string[] args)
        {
            Car varForСonveringFromCarToVehicle = new Car(Speed:40);
            Vehicle vehCar = varForСonveringFromCarToVehicle as Vehicle;
            if (vehCar == null)
            {
                Console.WriteLine("Convering went wrong");
            }
            else
            {
                Console.WriteLine("Converted from Car to Vehicle");
            }
            if (vehCar is Vehicle)
            {
                Console.WriteLine("Type of variable carExample is Vehicle");
            }
            else//не зайдет. восходящее преобразование(к базовому)
            {
                vehCar = (Vehicle)varForСonveringFromCarToVehicle;
                Console.WriteLine("It's not!");
            }
            Console.WriteLine();


            Vehicle carExample = new Car(Speed:60);//тип Vehicle хранит ссылку на Car
            Console.WriteLine(carExample.ToString());
            carExample.Move();
            Console.WriteLine();

            Car carExampleForTheSameFuncsNames1 = new Car(Speed: 80);
            IStopping carExampleForTheSameFuncsNames2 = new Car(Speed: 100);
            carExampleForTheSameFuncsNames1.Stop();
            carExampleForTheSameFuncsNames2.Stop();
            Console.WriteLine();

            Carriage carriageExample = new Carriage(countOfCarriagesInTrain: 5);
            Console.WriteLine(carriageExample.ToString());
            Console.WriteLine();

            Train trainExample = new Train(countOfCarriagesInTrain: 4, placeOfDeparture: "minsk", placeOfArrival: "gomel");
            trainExample.TrainInfo();
            Console.WriteLine();

            ExpressTrain expressTrainExample = new ExpressTrain(countOfCarriagesInTrain: 8, placeOfDeparture: "grodno", placeOfArrival: "vitebsk");
            expressTrainExample.TrainInfo();

            List<Vehicle> list = new List<Vehicle>();
            list.Add(carExample);
            list.Add(trainExample);
            list.Add(expressTrainExample);

            IMotor carForMotor = new Car(Speed: 100);
            carForMotor.MotorInfo();

            Console.WriteLine();
            Printer Print = new Printer();
            foreach (Vehicle veh in list)
            {
                Console.WriteLine(Print.IAmPrinting(veh));
            }


            Console.ReadKey();
        }
    }
}

