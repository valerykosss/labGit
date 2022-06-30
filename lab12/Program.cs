using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;
////using System.Text.Json;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            //BINARY
            Console.WriteLine("BINARY SERALIZATION AND DESERIALIZATION");
            Train train1 = new Train(placeOfDeparture: "minsk", placeOfArrival: "gomel", commonSeatsCount: 10, compartmentSeatsCount: 20, reservedSeatsCount: 30, luxSeatsCount: 40, Speed: 65, VehicleCost: 3000);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //сериализация объекта
            using (FileStream fs = new FileStream("binaryTrain.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, train1);
                Console.WriteLine("train is serialized with BinaryFormatter:");
            }
            //десериализация объекта из файла
            using (FileStream fs = new FileStream("binaryTrain.dat", FileMode.OpenOrCreate))
            {
                Train trainForDeserialization = (Train)binaryFormatter.Deserialize(fs);
                Console.WriteLine("train is deserialized with BinaryFormatter: ");
                Console.WriteLine($"Train place of departure: {trainForDeserialization.placeOfDeparture}; Place Of Arrival: {trainForDeserialization.placeOfArrival}; Speed: {trainForDeserialization.Speed}; Cost of train: {trainForDeserialization.VehicleCost}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Train train2 = new Train(placeOfDeparture: "grodno", placeOfArrival: "gomel", commonSeatsCount: 20, compartmentSeatsCount: 15, reservedSeatsCount: 80, luxSeatsCount: 40, Speed: 65, VehicleCost: 7000);
            Train train3 = new Train(placeOfDeparture: "moscow", placeOfArrival: "vitebsk", commonSeatsCount: 30, compartmentSeatsCount: 12, reservedSeatsCount: 20, luxSeatsCount: 40, Speed: 65, VehicleCost: 5000);
            Train[] trains = new Train[] { train1, train2, train3 };
            //сериализация массива
            BinaryFormatter binaryFormatterForArray = new BinaryFormatter();
            using (FileStream fs = new FileStream("binaryTrains.dat", FileMode.OpenOrCreate))
            {
                binaryFormatterForArray.Serialize(fs, trains);
                Console.WriteLine("trains array is serialized with BinaryFormatter:");
            }
            //десериализация массива из файла
            using (FileStream fs = new FileStream("binaryTrains.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("trains array is deserialized with BinaryFormatter:");
                Train[] trainsArrayForDeserialization = (Train[])binaryFormatterForArray.Deserialize(fs);
                foreach (Train t in trainsArrayForDeserialization)
                {
                    Console.WriteLine($"Train place of departure: {t.placeOfDeparture}; Place Of Arrival: {t.placeOfArrival}; Speed: {t.Speed}; Cost of train: {t.VehicleCost}");
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            //JSON
            Console.WriteLine("JSON SERALIZATION AND DESERIALIZATION");
            ExpressTrain expressTrain1 = new ExpressTrain(placeOfDeparture: "grodno", placeOfArrival: "gomel", commonSeatsCount: 20, compartmentSeatsCount: 15, reservedSeatsCount: 80, luxSeatsCount: 40, Speed: 65, VehicleCost: 7);
            ExpressTrain expressTrain2 = new ExpressTrain(placeOfDeparture: "grodno", placeOfArrival: "gomel", commonSeatsCount: 20, compartmentSeatsCount: 15, reservedSeatsCount: 80, luxSeatsCount: 40, Speed: 65, VehicleCost: 7000);
            ExpressTrain expressTrain3 = new ExpressTrain(placeOfDeparture: "grodno", placeOfArrival: "gomel", commonSeatsCount: 20, compartmentSeatsCount: 15, reservedSeatsCount: 80, luxSeatsCount: 40, Speed: 65, VehicleCost: 7000);

            string expressTrainSerialized = JsonConvert.SerializeObject(expressTrain1);
            Console.WriteLine("express train is serialized with json:");
            ExpressTrain deserializedExpressTrain = JsonConvert.DeserializeObject<ExpressTrain>(expressTrainSerialized);
            Console.WriteLine("express train is deserialized with json:");
            Console.WriteLine($"ExpressTrain place of departure: {deserializedExpressTrain.placeOfDeparture}; Place Of Arrival: {deserializedExpressTrain.placeOfArrival}; Speed: {deserializedExpressTrain.Speed}; Cost of train: {deserializedExpressTrain.VehicleCost}");
            Console.WriteLine();
            Console.WriteLine();

            List<ExpressTrain> expressTrains = new List<ExpressTrain>();
            expressTrains.Add(expressTrain1);
            expressTrains.Add(expressTrain2);
            expressTrains.Add(expressTrain3);

            string expTrainArrSerialized = JsonConvert.SerializeObject(expressTrains);
            Console.WriteLine("express train array is serialized with json:");
            ExpressTrain[] deserializedExpTrain = JsonConvert.DeserializeObject<ExpressTrain[]>(expTrainArrSerialized);
            Console.WriteLine("express train array is deserialized with json:");
            foreach (ExpressTrain expTrain in deserializedExpTrain)
            {
                Console.WriteLine($"ExpressTrain place of departure: {expTrain.placeOfDeparture}; Place Of Arrival: {expTrain.placeOfArrival}; Speed: {expTrain.Speed}; Cost of train: {expTrain.VehicleCost}");
            }
            Console.WriteLine();
            Console.WriteLine();
            
            
            //SOAP
            Console.WriteLine("SOAP SERALIZATION AND DESERIALIZATION");
            Car car1 = new Car(Speed: 80, Fuel: 12, VehicleCost: 2000);
            Car car2 = new Car(Speed: 70, Fuel: 9, VehicleCost: 7000);
            Car car3 = new Car(Speed: 90, Fuel: 10, VehicleCost: 9000);

            Car[] cars = { car1, car2, car3};

            SoapFormatter soapFormatter = new SoapFormatter();
            // сериализация объекта
            using (FileStream fs = new FileStream("soapCar.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, car1);
                Console.WriteLine("car is serialized with soap:");
            }

            //десериализация объекта
            using (FileStream fs = new FileStream("soapCar.soap", FileMode.OpenOrCreate))
            {
                Car carToDeserialize = (Car)soapFormatter.Deserialize(fs);
                Console.WriteLine("car is deserialized with soap:");
                Console.WriteLine($"Speed {carToDeserialize.Speed}, Fuel:{carToDeserialize.Fuel}, VehicleCost:{carToDeserialize.VehicleCost}");
            }
            Console.WriteLine();
            Console.WriteLine();
            SoapFormatter soapFormatterArray = new SoapFormatter();
            // сериализация массива
            using (FileStream fs = new FileStream("soapCars.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, cars);

                Console.WriteLine("car array is serialized with soap:");
            }
            //десериализация массива объектов
            using (FileStream fs = new FileStream("soapCars.soap", FileMode.OpenOrCreate))
            {
                Car[] carsArrayToDeserialize = (Car[])soapFormatterArray.Deserialize(fs);
                Console.WriteLine("car array is deserialized with soap:");
                foreach (Car c in carsArrayToDeserialize)
                {
                    Console.WriteLine($"Speed {c.Speed}, Fuel:{c.Fuel}, VehicleCost:{c.VehicleCost}");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            //XML
            Console.WriteLine("XML SERALIZATION AND DESERIALIZATION");

            //передаем в конструктор тип класса
            XmlSerializer xmlFormatterCar = new XmlSerializer(typeof(Car));
            XmlSerializer xmlFormatterCarArray = new XmlSerializer(typeof(Car[]));

            //сериализация объекта
            using (FileStream fs = new FileStream("xmlCar.xml", FileMode.OpenOrCreate))
            {
                xmlFormatterCar.Serialize(fs, car1);
                Console.WriteLine("car is serialized with xml:");
            }
            //десериализация объекта
            using (FileStream fs = new FileStream("xmlCar.xml", FileMode.OpenOrCreate))
            {
                Car carToDeseralize = (Car)xmlFormatterCar.Deserialize(fs);
                Console.WriteLine("car is deserialized with xml:");
                Console.WriteLine($"Speed {carToDeseralize.Speed}, Fuel:{carToDeseralize.Fuel}, VehicleCost:{carToDeseralize.VehicleCost}");
            }
            Console.WriteLine();
            Console.WriteLine();
            //сериализация массива
            using (FileStream fs = new FileStream("xmlCars.xml", FileMode.OpenOrCreate))
            {
                xmlFormatterCarArray.Serialize(fs, cars);
                Console.WriteLine("car array is serialized with xml:");
            }
            //десериализация массива
            using (FileStream fs = new FileStream("xmlCars.xml", FileMode.OpenOrCreate))
            {
                Car[] carArrayToDerealize = (Car[])xmlFormatterCarArray.Deserialize(fs);
                Console.WriteLine("car array is deserialized with xml:");
                foreach (Car c in carArrayToDerealize)
                    Console.WriteLine($"Speed {c.Speed}, Fuel:{c.Fuel}, VehicleCost:{c.VehicleCost}");
            }

            Console.WriteLine();
            Console.WriteLine();
            //3. Используя XPath напишите два селектора для вашего XML документа.
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("xmlCars.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            XmlNode childnode1 = xRoot.SelectSingleNode("Car[VehicleCost='2000']");
            if (childnode1 != null)
                Console.WriteLine(childnode1.OuterXml);

            XmlNode childnode2 = xRoot.SelectSingleNode("Car[Fuel='10']");
            if (childnode2 != null)
                Console.WriteLine(childnode2.OuterXml);
            Console.WriteLine();
            Console.WriteLine();
            //4. Используя Linq to XML (или Linq to JSON) создайте новый xml (json) - документ и напишите несколько запросов


            XDocument xdoc = new XDocument();
            // создаем первый элемент
            XElement bikeXml1 = new XElement("bike");
            // создаем атрибут и элементы
            XAttribute bikeXmlBrand1 = new XAttribute("brand", "Stels");
            XElement trainXmlCountry1 = new XElement("manufacturerCountry", "Russia");
           
            // добавляем атрибут и элементы в первый элемент
            bikeXml1.Add(bikeXmlBrand1);
            bikeXml1.Add(trainXmlCountry1);

            // создаем второй элемент
            XElement bikeXml2 = new XElement("bike");
            // создаем атрибут и элементы
            XAttribute bikeXmlBrand2 = new XAttribute("brand", "Cannondale");
            XElement trainXmlCountry2 = new XElement("manufacturerCountry", "USA");
            // добавляем атрибут и элементы во второй элемент
            bikeXml2.Add(bikeXmlBrand2);
            bikeXml2.Add(trainXmlCountry2);

            // создаем корневой элемент
            XElement bikesXmlRoot = new XElement("bikes");
            // добавляем в корневой элемент
            bikesXmlRoot.Add(bikeXml1);
            bikesXmlRoot.Add(bikeXml2);
            // добавляем корневой элемент в документ
            xdoc.Add(bikesXmlRoot);
            //сохраняем документ
            xdoc.Save("bikesExercise4.xml");


            XDocument xdoc1 = XDocument.Load("bikesExercise4.xml");
            var items = from xe in xdoc1.Element("bikes").Elements("bike")
                        where xe.Element("manufacturerCountry").Value == "USA"
                        select new Bike
                        {
                            Brand = xe.Attribute("brand").Value,
                            ManufacturerCountry = xe.Element("manufacturerCountry").Value
                        };

            foreach (var item in items)
                Console.WriteLine($"{item.Brand} - {item.ManufacturerCountry}");
            Console.ReadLine();
        }
    }
}
public class Bike
{
    public string ManufacturerCountry { set; get; }
    public string Brand { set; get; }
}
interface IStopping
{
    void Stop();
}
[Serializable]
public abstract class Vehicle
{
    public int Fuel { set; get; }
    public int VehicleCost { get; set; }
    public float Speed { get; set; }
    public abstract void Move();
    public abstract void Stop();
}
[Serializable]
public class Train : Vehicle, IStopping
{
    [Serializable]
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
[Serializable]
sealed class ExpressTrain : Train, IStopping
{
    [Serializable]
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
[Serializable]
public class Car : Vehicle, IStopping
{
    public Car() { }
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