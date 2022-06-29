using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Owner
    {
        public string Name;
        public string Id;
        public string Organization;
    }
    public class MyList<T>
    { 

        public List<int> list = new List<int>();
        public MyList(List<int> list)
        {
            this.list = list;
        }
        public Owner owner { get; set; }
        public class Date
        {
            private DateTime globalStartTime;
            public Date()
            {
                this.globalStartTime = DateTime.Now;
            }
            public void ShowDateInfo()
            {
                Console.Write($"Объект был создан в следующее время: {this.globalStartTime}");
            }
        }
        public MyList<int> RemoveElement(MyList<int> someListForDeleting, int elementToDelete)
        {
            someListForDeleting.list.Remove(elementToDelete);
            return someListForDeleting;
        }
        public MyList<int> AddElement(MyList<int> someListForAdding, int elementToAdd)
        {
            someListForAdding.list.Add(elementToAdd);
            return someListForAdding;
        }
        public void ShowInfo()
        {
            Console.Write("Содержимое поля list экземпляра класса MyList: ");
            foreach (int i in this.list)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        /*public int FindListLength()
        {
            int listLength = 0;
            foreach (int i in this.list)
            {
                listLength++;
            }
            return listLength;
        }*/
        public static MyList<T> operator +(MyList<T> someListForAdding, int elementToAdd)
        {
            someListForAdding.list.Insert(0, elementToAdd);
            return someListForAdding;
        }
        public static MyList<T> operator --(MyList<T> someListForDeleting)
        {
           someListForDeleting.list.RemoveAt(someListForDeleting.list.Count-1);
           //someListForDeleting.list.RemoveAt(someListForDeleting.FindListLength() - 1);
           return someListForDeleting;
        }
        /*public override bool Equals(MyList<T> listToCompare)
        {
            if (listToCompare == null)
                return false;
            MyList<T> anotherListToCompare = listToCompare as MyList<T>; // возвращает null если объект нельзя привести к типу List<T>
            if (anotherListToCompare as MyList<T> == null)
                return false;

            return anotherListToCompare.list == listToCompare.list;
        }*/
        public static bool operator ==(MyList<T> firstList, MyList<T> secondList)
        {
            return firstList.list.SequenceEqual(secondList.list);//equals не работал верно, 
        }
        public static bool operator !=(MyList<T> firstList, MyList<T> secondList) //тк идут парой
        {
            //if (firstList.list != secondList.list) { return true; }
            //if (firstList.list.Equals(secondList.list)) { return false; }
            //else return true;
            return !(firstList.list.SequenceEqual(secondList.list)); //Если они ссылаются на разные списки, содержащие одни и те же элементы, X.Equals(Y) будет ложным, но X.SequenceEqual(Y) будет верным
        }
        public static bool operator true(MyList<T> firstList) //тк идут парой
        {
            List<int> listForSecond= firstList.list.ToList();//toList() возвращ новый лист, а не копию на first
            MyList<int> secondList = new MyList<int>(listForSecond);
            firstList.list.Sort();//если сортирую второй(клон?), сортируется и первый, наоборот такого не происходит
            if (firstList.list.SequenceEqual(secondList.list)) { return true; }
            else return false;
        }
        public static bool operator false(MyList<T> firstList) //тк идут парой
        {
            MyList<T> secondList = firstList;
            secondList.list.Sort();
            if (!firstList.list.SequenceEqual(secondList.list)) { return false; }
            else return true;
        }
    }
    public static class MyExtensions
    {
        //мои методы расширения(1 для строки, другой для списка)
        public static int NumberOfWordsInString(this string stringToFindNumberOfWords)
        {
            int numberOfWords = stringToFindNumberOfWords.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
            //Splits a string into substrings based on a specified delimiting string and, optionally, options.
            return numberOfWords;
        }


        //проверка на нулевые элементы в списке
        public static bool DoesListContainZeroElements(this MyList<int> someListToCheck)
        {
            /*if(someListToCheck.list.Any(i => i == 0))
            {
                return true;
            }
            else return false;*/

            if(someListToCheck.list.Count > 0)
            {
                for(int i = 0; i < someListToCheck.list.Count; i++)
                {
                    if(someListToCheck.list[i] == 0) return true;
                }
            }
            return false;
        }

    }
    public static class StaticOperations
    {
        //сумма элементов класса List
        public static int SumOfListElements(MyList<int> listToCountSumOfItsElements)
        {
            int sumOfElements= listToCountSumOfItsElements.list.ToArray().Sum();
            return sumOfElements;
        }
        //разница макс и мин элементов
        public static int DifferenceBetweenMaxAndMinElements(MyList<int> listToFindTheDifferenceBetweenMaxAndMinElements)
        {
            int maxElementOfList = listToFindTheDifferenceBetweenMaxAndMinElements.list.ToArray().Max();
            int minElementOfList = listToFindTheDifferenceBetweenMaxAndMinElements.list.ToArray().Min();
            int difference = maxElementOfList - minElementOfList;
            return difference;
        }
        //кол-во элементов
        public static int NumberOfElementsInList(MyList<int> listToFindItsLength)
        {
            int counter = listToFindItsLength.list.Count;
            return counter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyList<int>.Date globalStartTimeObj = new MyList<int>.Date();
            globalStartTimeObj.ShowDateInfo();
            Console.WriteLine();

            List<int> list = new List<int>() { 1, 2, 3, 4 };
            MyList<int> myList = new MyList<int>(list);
            Console.WriteLine("Поле list класса MyList пронициализировано!");
            myList.ShowInfo();
            Console.WriteLine();

            myList.owner = new Owner()
            {
                Name = "Valeria",
                Id = "73201010",
                Organization = "Belstu"
            };
            Console.WriteLine($"У класса MyList появился Owner с именем {myList.owner.Name}, id {myList.owner.Id}, учащийся в {myList.owner.Organization}!");
            Console.WriteLine();

            myList.RemoveElement(myList, 2);
            Console.WriteLine("Из поля list класса MyList удалено значение 2");
            myList.ShowInfo();
            Console.WriteLine();

            myList.AddElement(myList, 55);
            Console.WriteLine("В поле list класса MyList добавлено значение 55");
            myList.ShowInfo();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Перегрузка операторов");
            Console.WriteLine();

            Console.WriteLine("Перегрузка оператора +");
            MyList<int> firstList = myList + 45;
            firstList.ShowInfo();
            Console.WriteLine();

            Console.WriteLine("Перегрузка оператора --");
            firstList = myList--;
            firstList.ShowInfo();
            Console.WriteLine();

            Console.WriteLine("Перегрузка оператора !=");
            List<int> firstNewList = new List<int>() { 7, 8, 9 };
            MyList<int> firstNewListClass = new MyList<int>(firstNewList);

            List<int> secondNewList = new List<int>() { 7, 8, 10 };
            MyList<int> secondNewListClass = new MyList<int>(secondNewList);
            Console.WriteLine("Списки firstNewListClass и secondNewListClass одинаковы?");
            Console.WriteLine(firstNewListClass != secondNewListClass);

            firstNewListClass.RemoveElement(firstNewListClass, 9);
            firstNewListClass.AddElement(firstNewListClass, 10);
            Console.WriteLine("А сейчас списки firstNewListClass и secondNewListClass одинаковы?");
            Console.WriteLine(firstNewListClass != secondNewListClass);
            Console.WriteLine();

            Console.WriteLine("Перегрузка оператора true");
            if (firstNewListClass)
            {
                Console.WriteLine("Список firstNewListClass отсортирован");
            }
            Console.WriteLine("В конец списка firstNewListClass добавлена 1");
            firstNewListClass.AddElement(firstNewListClass, 1);
            if (firstNewListClass)
            {
                Console.WriteLine("Список firstNewListClass отсортирован");
            }
            else
            {
                Console.WriteLine("Список firstNewListClass НЕ отсортирован");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Методы расширения");
            string stringForExtensions = "Программа должна сказать, что в строке 8 слов";
            int counterOfWordsInString = stringForExtensions.NumberOfWordsInString();
            Console.WriteLine($"В строке {counterOfWordsInString} слов");

            List<int> listForExtensions = new List<int>() { 1, 0, 3, 7 };
            MyList<int> myListForExtensions = new MyList<int>(listForExtensions);
            bool toCheckZeroElement=myListForExtensions.DoesListContainZeroElements();
            if (toCheckZeroElement)
            {
                Console.WriteLine("В List есть 0 элемент(ы)");
            }
            else
            {
                Console.WriteLine("В List нет 0 элемента(ов)");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Статические методы из класса StaticOperations");
            Console.WriteLine();
            Console.WriteLine("Сумма должна быть равна 1+0+3+7=11");
            int variablForListSum=StaticOperations.SumOfListElements(myListForExtensions);
            Console.WriteLine($"Сумма элементов list равна {variablForListSum}");
            Console.WriteLine();

            Console.WriteLine("Разность должна быть равна 7-0=7");
            int differenceBetweenMaxAndMinOfList = StaticOperations.DifferenceBetweenMaxAndMinElements(myListForExtensions);
            Console.WriteLine($"Разница maх и min элементов list равна {differenceBetweenMaxAndMinOfList}");
            Console.WriteLine();

            Console.WriteLine("Число элементов должо быть 4");
            int countOfElementsInList = StaticOperations.NumberOfElementsInList(myListForExtensions);
            Console.WriteLine($"Число элементов списка равно {countOfElementsInList}");

            Console.ReadKey();
        }
    }
}
