using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab7
{
    //Транспортное средство, Автомобиль, Двигатель, Поезд, Экспресс, Двигатель, Вагон.
    interface IStopping
    {
        void Stop();
    }
    abstract partial class Vehicle
    {
        private int fuel;
        public int Fuel
        {
            get { return fuel; }
            set
            {
                if (value < 0)
                {
                    throw new FuelException("Transport's fuel value can't be negative");
                }
                fuel = value;
            }
        }
    public int VehicleCost { get; set; }
        /*private double vehicleCost;
        public double VehicleCost
        {
            get
            {
                return vehicleCost;
            }
            set
            {
                vehicleCost = value;
            }
        }*/
         private float speed;
         public float Speed {
            get { return speed; }
            set
            {
                if (value > 650)
                {
                   throw new TooHighSpeedValueException("Land transport's speed can't be more than 650 km/h");
                }
                else if (value < 0)
                {
                    throw new NegativeSpeedValueException("Speed value can't be negative");
                }
                speed = value;
            }
         }
         public abstract void Move();
         public abstract void Stop();
    }
    class Car : Vehicle, IStopping
    {
        enum CarBrand
        {
            Lamborghini,
            Mercedes,
            Volkswagen,
            Jaguar
        }
        public void CarBrandFunc(int varForEnum)
        {
            Console.WriteLine($"Car's brand is {(CarBrand)varForEnum}");
        }
        public Car(int Speed, int Fuel, int VehicleCost)
        {
            this.Speed = Speed;
            this.Fuel = Fuel;
            this.VehicleCost = VehicleCost;
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
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return "override ToString(): Car is on its way with speed " + Speed + " km/h and fuel consumtion " + Fuel + " liters/km. Car cost is " + VehicleCost + " $";
        }
    }
    class Train : Vehicle, IStopping
    {
        public struct Carriage
        {
            public int commonSeatsCount;
            public int compartmentSeatsCount;
            public int reservedSeatsCount;
            public int luxSeatsCount;
            public Carriage(int commonSeatsCount, int compartmentSeatsCount, int reservedSeatsCount, int luxSeatsCount)
            {
                this.commonSeatsCount = commonSeatsCount;
                this.compartmentSeatsCount = compartmentSeatsCount;
                this.reservedSeatsCount = reservedSeatsCount;
                this.luxSeatsCount = luxSeatsCount;
            }
        }
        public Carriage carriage;
        public override void Stop()
        {
            Console.WriteLine("Abstract class method with the same name. Transport stopped");
        }
        void IStopping.Stop()
        {
            Console.WriteLine("Interface method with the same name. Transport stopped");
        }
        public string placeOfDeparture;
        public string placeOfArrival;
        public override void Move()
        {
            Console.WriteLine("Simple train with carriages is on its way");
        }
        public Train(string placeOfDeparture, string placeOfArrival, int commonSeatsCount, int compartmentSeatsCount, int reservedSeatsCount, int luxSeatsCount, float Speed, int VehicleCost)
        {
            this.carriage = new Train.Carriage(commonSeatsCount, compartmentSeatsCount, reservedSeatsCount, luxSeatsCount);
            this.placeOfDeparture = placeOfDeparture;
            this.placeOfArrival = placeOfArrival;
            this.Speed = Speed;
            this.VehicleCost = VehicleCost;
        }
        public virtual void TrainInfo()
        {
            Console.WriteLine($"Simple train goes from {placeOfDeparture} to {placeOfArrival} with speed {Speed} km/h. Common seats: {carriage.commonSeatsCount}, compartment seats: {carriage.compartmentSeatsCount} reserved seats: {carriage.reservedSeatsCount}, lux seats: {carriage.luxSeatsCount}");
        }
        public override string ToString()
        {
            return "override ToString(): Train is on its way with speed " + Speed + " km/h. Train cost is " + VehicleCost + " $";
        }
    }
    sealed class ExpressTrain : Train, IStopping
    {
        public struct ExpressCarriage
        {
            public int commonSeatsCount;
            public int compartmentSeatsCount;
            public int reservedSeatsCount;
            public int luxSeatsCount;
            public ExpressCarriage(int commonSeatsCount, int compartmentSeatsCount, int reservedSeatsCount, int luxSeatsCount)
            {
                this.commonSeatsCount = commonSeatsCount;
                this.compartmentSeatsCount = compartmentSeatsCount;
                this.reservedSeatsCount = reservedSeatsCount;
                this.luxSeatsCount = luxSeatsCount;
            }
        }
        public ExpressCarriage expressCarriage;
        public ExpressTrain(string placeOfDeparture, string placeOfArrival, int commonSeatsCount, int compartmentSeatsCount, int reservedSeatsCount, int luxSeatsCount, float Speed, int VehicleCost) : base(placeOfDeparture, placeOfArrival, commonSeatsCount, compartmentSeatsCount, reservedSeatsCount, luxSeatsCount, Speed, VehicleCost)
        {
            this.expressCarriage = new ExpressTrain.ExpressCarriage(commonSeatsCount, compartmentSeatsCount, reservedSeatsCount, luxSeatsCount);
            //this.Speed = Speed;
            //this.VehicleCost = VehicleCost;
        }
        public override void Move()
        {
            Console.WriteLine("Express train with carriages is on its way");
        }
        public override void TrainInfo()
        {
            Console.WriteLine($"Express train goes from {placeOfDeparture} to {placeOfArrival} with speed {Speed} km/h. Common seats: {expressCarriage.commonSeatsCount}, compartment seats: {expressCarriage.compartmentSeatsCount} reserved seats: {expressCarriage.reservedSeatsCount}, lux seats: {expressCarriage.luxSeatsCount}");
        }
        public override string ToString()
        {
            return "override ToString(): Express train is on its way with speed " + Speed + " km/h. Express Train cost is " + VehicleCost + " $";
        }
    }
    class TransportAgencyContainer
    {
        //стоимость всех транспортных средств
        public List<Vehicle> ListVehicles { get; set; }
        public TransportAgencyContainer()
        {
            ListVehicles = new List<Vehicle>();
        }
        public List<Vehicle> AddVehicleIntoList(Vehicle vehicleToAdd)
        {
            if (vehicleToAdd is Train)
            {
                ListVehicles.Add(vehicleToAdd as Train);
            }
            else if (vehicleToAdd is ExpressTrain)
            {
                ListVehicles.Add(vehicleToAdd as ExpressTrain);
            }
            else if (vehicleToAdd is Car)
            {
                ListVehicles.Add(vehicleToAdd as Car);
            }
            //ListVehicles.Add(vehicleToAdd);
            return ListVehicles;
        }
        public List<Vehicle> RemoveVehicleFromList(Vehicle vehicleToDelete)
        {
            if (vehicleToDelete is Train)
            {
                ListVehicles.Remove(vehicleToDelete as Train);
            }
            else if (vehicleToDelete is ExpressTrain)
            {
                ListVehicles.Remove(vehicleToDelete as ExpressTrain);
            }
            else if (vehicleToDelete is Car)
            {
                ListVehicles.Remove(vehicleToDelete as Car);
            }
            //ListVehicles.Remove(vehicleToDelete);
            return ListVehicles;
        }
        public void ShowListInfo()
        {
            Console.Write("TRANSPORT IN AGENCY: ");
            Console.WriteLine();
            foreach (Vehicle veh in ListVehicles)
            {
                Console.WriteLine(veh);
            }
            Console.WriteLine();
        }
        public double TransportCost()
        {
            double cost = 0;
            foreach (Vehicle veh in ListVehicles)
            {
                cost = cost + veh.VehicleCost;
            }
            return cost;
        }
    }
    class TransportAgencyController
    {
        public void SearchBySpeed(TransportAgencyContainer transportAgency, float minSpeed, float maxSpeed)
        {
            List<Vehicle> vehicleSelection = new List<Vehicle>();
            foreach (Vehicle veh in transportAgency.ListVehicles)
            {
                if (veh.Speed >= minSpeed && veh.Speed <= maxSpeed)
                {
                    vehicleSelection.Add(veh);
                    Console.WriteLine(veh);
                }
            }
        }
        public List<Vehicle> SortByFuel(TransportAgencyContainer transportAgency)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (Vehicle veh in transportAgency.ListVehicles)
            {
                /*if (veh is Train)
                {
                    vehicles.Add(veh as Train);
                }
                else if (veh is ExpressTrain)
                {
                    vehicles.Add(veh as ExpressTrain);
                }
                else if (veh is Car)
                {
                    vehicles.Add(veh as Car);
                }*/

                if (veh is Car)
                {
                    vehicles.Add(veh as Car);
                }
                else
                {
                    continue;
                }
            }
            vehicles.Sort((x, y) => x.Fuel.CompareTo(y.Fuel));
            return vehicles;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //проверка скорости через 2 класса-наследника
            try
            {
                Vehicle carExample = new Car(Speed: 660, Fuel: 10, VehicleCost: 1000);//тип Vehicle хранит ссылку на Car
                Console.WriteLine("No exceptions!");
 
            }
            catch (TooHighSpeedValueException ex)
            {
                Console.WriteLine("TooHighSpeedValueException!");
                Console.WriteLine(ex.Message);
            }
            catch (NegativeSpeedValueException ex)
            {
                Console.WriteLine("NegativeSpeedValueException!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Block is done");
            }
            Console.WriteLine();
            Console.WriteLine();

            //проверка всего через базовый класс
            try
            {
                Car carExampleForTheSameFuncsNames1 = new Car(Speed: -10, Fuel: 1, VehicleCost: 2000);
                Console.WriteLine("No exceptions!");

            }
            catch (CarException ex)
            {
                Console.WriteLine("CarException!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Block is done");
            }
            Console.WriteLine();
            Console.WriteLine();

            //проверка топлива
            try
            {
                Car carExampleForTheSameFuncsNames2 = new Car(Speed: 80, Fuel: -7, VehicleCost: 2000);
                Console.WriteLine("No exceptions!");

            }
            catch (FuelException ex)
            {
                Console.WriteLine("FuelException!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Block is done");
            }
            Console.WriteLine();
            Console.WriteLine();

            Car anothercarExample = new Car(Speed: 70, Fuel: 7, VehicleCost: 7000);
            Train trainExample = new Train(placeOfDeparture: "minsk", placeOfArrival: "gomel", commonSeatsCount: 10, compartmentSeatsCount: 20, reservedSeatsCount: 30, luxSeatsCount: 40, Speed: 65, VehicleCost: 3000);
            ExpressTrain expressTrainExample = new ExpressTrain(placeOfDeparture: "grodno", placeOfArrival: "vitebsk", commonSeatsCount: 15, compartmentSeatsCount: 25, reservedSeatsCount: 35, luxSeatsCount: 45, Speed: 124, VehicleCost: 4000);

            TransportAgencyContainer transportAgency = new TransportAgencyContainer();
            transportAgency.AddVehicleIntoList(anothercarExample);
            transportAgency.AddVehicleIntoList(trainExample);
            transportAgency.AddVehicleIntoList(expressTrainExample);
                       
            //несколько catch
            try
            {
                transportAgency.AddVehicleIntoList(new Car(Speed: 70, Fuel: -7, VehicleCost: 7000));
            }
            catch (FuelException ex)
            {

                Console.WriteLine("FuelException!");
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("Another type of exception!");
            }
            finally
            {
                Console.WriteLine("Block is done!");
            }
            try
            {
                anothercarExample.Speed = -70;
            }
            catch (SpeedException ex)
            {
                Console.WriteLine("NegativeSpeedValueException!");
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("Another type of exception!");
            }
            finally
            {
                Console.WriteLine("anothercarExample.Speed wasn't changed!");
            }
            Console.WriteLine();
            Console.WriteLine();
            transportAgency.ShowListInfo();
            Console.WriteLine();
            Console.WriteLine();

            //IndexOutOfRangeException
            try
            {
                Console.WriteLine(transportAgency.ListVehicles[7]);
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("IndexOutOfRangeException!");
            }
            Console.WriteLine();
            Console.WriteLine();

            //NullReferenceException
            try
            {
                string newDestination = null;
                if (newDestination == null) throw new SomeException("NullReferenceException!");
            }
            catch
            {
                Console.WriteLine("NullReferenceException was found");
            }
            /*try
            {
                string newDestination = trainExample.placeOfDeparture;
                newDestination = null;
                int length = newDestination.Length;//не ловит NullReferenceException
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("NullReferenceException!");
            }*/
            Console.WriteLine();
            Console.WriteLine();

            //DivideByZeroException
            try
            {
                int newCost = (expressTrainExample.VehicleCost) / 0;
                Console.WriteLine(newCost);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DivideByZeroException!");
            }
            Console.WriteLine();
            Console.WriteLine();

            //InvalidCastException
            try
            {
                Train objTrain = new Train(placeOfDeparture: "minsk", placeOfArrival: "gomel", commonSeatsCount: 10, compartmentSeatsCount: 20, reservedSeatsCount: 30, luxSeatsCount: 40, Speed: 65, VehicleCost: 3000);
                ExpressTrain objExpressTrain = (ExpressTrain)objTrain;//downcasting
                Console.WriteLine("Converted successfully");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Convertion failed(downcasting)");
                Console.WriteLine("InvalidCastException!");
            }
            Console.WriteLine();
            Console.WriteLine();

            //InvalidCastException
            try
            {
                ExpressTrain objExpressTrain = new ExpressTrain(placeOfDeparture: "minsk", placeOfArrival: "gomel", commonSeatsCount: 10, compartmentSeatsCount: 20, reservedSeatsCount: 30, luxSeatsCount: 40, Speed: 65, VehicleCost: 3000);
                Train objTrain = (Train)objExpressTrain; //upcasting
                Console.WriteLine("Converted successfully");
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Convertion failed(upcasting)");
                Console.WriteLine("InvalidCastException!");
            }

            //Assert
            /*string someVar = null;
            Debug.Assert(someVar != null, "String is null");*/
            Console.ReadKey();
        }
    }
}


