using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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
        public void GetTotalSeatsNumber()
        {
            Console.WriteLine($"Общее число мест по этому маршруту {this.commonSeatsCount + this.compartmentSeatsCount + this.reservedSeatsCount + this.luxSeatsCount}");
        }
    }
}