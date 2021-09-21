using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.ВСЕ ПРИМИТИВНЫЕ ТИПЫ

            bool bl = true;//Представлен системным типом System.Boolean
            byte bt = 1; //byte: хранит целое число от 0 до 255 и занимает 1 байт. Представлен системным типом System.Byte
            sbyte sbt = -101; //хранит целое число от -128 до 127 и занимает 1 байт. Представлен системным типом System.SByte
            short shrt = 102; //хранит целое число от -32768 до 32767 и занимает 2 байта. Представлен системным типом System.Int16
            ushort usrt = 1; //хранит целое число от 0 до 65535 и занимает 2 байта. Представлен системным типом System.UInt16
            int nt = -10; //хранит целое число от -2147483648 до 2147483647 и занимает 4 байта. Представлен системным типом System.Int32. 
                          //Все целочисленные литералы по умолчанию представляют значения типа int:
            uint unt = 10u; //хранит целое число от 0 до 4294967295 и занимает 4 байта. Представлен системным типом System.UInt32
            long lng = -100l; //хранит целое число от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807 и занимает 8 байт.
                              //Представлен системным типом System.Int64
            ulong ulng = 100ul; //хранит целое число от 0 до 18 446 744 073 709 551 615 и занимает 8 байт. 
                                //Представлен системным типом System.UInt64
            double dbl = 78.65; //хранит число с плавающей точкой от ±5.0*10-324 до ±1.7*10308 и занимает 8 байта. 
                                //Представлен системным типом System.Double
            float flt = 4.5f; //хранит число с плавающей точкой от -3.4*1038 до 3.4*1038 и занимает 4 байта.
                              //Представлен системным типом System.Single
            char chr = 'A'; // хранит одиночный символ в кодировке Unicode и занимает 2 байта. Представлен системным типом System.Char.
                            //Этому типу соответствуют символьные литералы:
            string str = "Hello"; //хранит набор символов Unicode. Представлен системным типом System.String.
                                  //Этому типу соответствуют строковые литералы.
            object obj1 = 18; //может хранить значение любого типа данных и занимает 4 байта на 32-разрядной платформе 
                              //и 8 байт на 64-разрядной платформе. Представлен системным типом System.Object,
                              //который является базовым для всех других типов и классов .NET.
            object obj2 = 9.24;
            object obj3 = "anything you fancy";

            decimal dcml = 334.8m; //хранит десятичное дробное число. Если употребляется без десятичной запятой, имеет значение
                                   //от ±1.0*10-28 до ±7.9228*1028, может хранить 28 знаков после запятой и занимает 16 байт. 
                                   //Представлен системным типом System.Decimal

            Console.WriteLine($"bool bl: {bl}");
            Console.WriteLine($"byte bt: {bt}");
            //1.ЯВНОЕ И НЕЯВНОЕ ПРИВЕДЕНИЕ ТИПОВ

            int i32 = 5; //слева Int32, справа Int32

            //неявные преобразования типов
            long i64 = i32; //слева Int64 справа Int32, неявно к Int64

            float single = i32; //слева Single справа Int32, неявно к Single

            int i = 5;
            float j = 4.5f;
            float result = i + j;//неявное int к float


            //явные преобразования типов
            byte b = (byte)i32; // слева Byte, справа явно Int32 к Byte

            short i16 = (short)single; //слева Int16, справа явно Single к Int16

            double d = 5.3;
            float s = (float)d; //слева Single, явно Double к Single

            float ff = 4.5f;// от double к float засчет суффикса

            double a1 = 0;
            bool result1 = Convert.ToBoolean(a1);//false

            double a2 = -3;
            bool result2 = Convert.ToBoolean(a2);//true

            string strVariable = "5";
            int iVariable = Convert.ToInt32(strVariable);

            string st = "1.9";

            //экземпляр класса NumberFormatInfo
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            {
                //поле
                NumberDecimalSeparator = ".",
            };

            double a = Convert.ToDouble(st, numberFormatInfo);

            string bla = "5";
            int blabla = int.Parse(bla);

            //УПАКОВКА, РАСПАКОВКА

            int variableInStack = 123; //variableInStack это value type(значимый тип)
            object objectInHeap = variableInStack; //упаковывание-процесс копирования значения в объект. в куче создается упаковка 
                                                   //variableInStack boxed, куда впоследствие перемещаются данные. в стеке хранится ссылка на boxed, который
                                                   //находится в куче
            int anotherVariableInStack = (int)objectInHeap; //значение изъято из упаковки и помещено обратно в область стека

            //НЕЯВНО ТИПИЗИРОВННАЯ ПЕРЕМЕННАЯ
            var implicityVariable = "some text";
            Console.WriteLine(implicityVariable.GetType()); //статический метод класса Object

            //РАБОТА С NULLABLE(это структура System.Nullable<T(конкретный тип данных)> с 2 полями: Value и HasValue)
            int? variableForNullable = null;
            Console.WriteLine(variableForNullable.HasValue); //false

            int? notNullable = 4;
            Console.WriteLine(notNullable.HasValue); //true

            //ОБЪЯВИТЬ СТРОКОВЫЕ ЛИТЕРАЛЫ, СРАВНИТЬ ИХ
            string string1 = "who are you?";
            Console.WriteLine(String.Compare(string1, "how are you?"));
            int comparisonResult = String.Compare(string1, "how are you?");
            if (comparisonResult < 0)
            {
                Console.WriteLine("Строка string1 выше по алфавиту перед строкой 2");
            }
            else if (comparisonResult > 0)
            {
                Console.WriteLine("Строка string1 стоит после строки 2");
            }
            else
            {
                Console.WriteLine("Строки string1 и 2 идентичны");
            }

            //КОНКАТЕНАЦИЯ
            string s1 = "it's";
            string s2 = "you";
            string s3 = s1 + " " + s2;//конкатенация
            string s4 = String.Concat(s3, "?", "!");//тоже конкатенация
            Console.WriteLine(s4);

            //КОПИРОВАНИЕ
            Console.WriteLine("Иходные строки s1 = " + "'{0}' and s2= '{1}'", s1, s2);
            s1 = String.Copy(s2);
            Console.WriteLine("Строка s2 после копирования в нее строки в s1 = '{0}'", s1);
            //Метод возвращает String объект, который имеет то же значение, что и исходная строка, но представляет другую ссылку на объект

            //ВЫДЕЛЕНИЕ ПОДСТРОКИ
            string text = "a kanye's new album";
            text = text.Substring(5); //начиная с 5 позиции
            Console.WriteLine(text); //ye's new album
            text = text.Substring(2, text.Length - 4); // начало обрезки уже новой строки!!! и длина вырезаемой части строки, 's new alb
            Console.WriteLine(text);

            //РАЗДЕЛЕНИЕ СТРОКИ НА СЛОВА
            string textToSplit = "ed sheeran's album release is on 29th of Oct";

            string[] words1 = textToSplit.Split(new char[] { ' ' });

            foreach (string iteration in words1)
            {
                Console.WriteLine(iteration);// минус когда много пробелов, решение снизу
            }
            Console.WriteLine();

            string[] words2 = textToSplit.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string iteration in words2)
            {
                Console.WriteLine(iteration);
            }

            //ВСТАВКА ПОДСТРОКИ В ДАННУЮ ПОЗИЦИЮ
            string mainString = "i hate something";
            string subString = "doing ";
            mainString = mainString.Insert(7, subString);//первым параметром в функции Insert является индекс, по которому надо вставлять подстроку, а второй параметр - собственно подстрока.
            Console.WriteLine(mainString);

            //УДАЛЕНИЕ ЗАДАННОЙ ПОДСТРОКИ
            string subStringToDelete = " hate doing";
            int n = mainString.IndexOf(subStringToDelete);
            mainString = mainString.Remove(n, subStringToDelete.Length);
            Console.WriteLine(mainString);

            //ПУСТЫЕ И NULL СТРОКИ
            string fullStr = "hello";
            string nullStr = null;
            string emptyStr = String.Empty;

            string tempStr = fullStr + nullStr;
            Console.WriteLine(tempStr);//hello
            bool areEqual = (emptyStr == nullStr);// false
            Console.WriteLine(areEqual);
            Console.WriteLine("eще одна проверка на равенство: " + (emptyStr.Equals(nullStr)));//false
            Console.WriteLine("cложение: " + (emptyStr + nullStr));//
            Console.WriteLine("сравнить содержимое empty.Str с содержимым nullStr: " + emptyStr.CompareTo(nullStr));//1

            //СОЗДАТЬ СТРОКУ НА ОСНОВЕ StringBuilder. Удалить опредленные позиции
            //и добавить новые символы в начало и конец строки

            StringBuilder stringBuilder = new StringBuilder("some dynamic string");
            Console.WriteLine($"длина строки: {stringBuilder.Length}");//чекнуть capacity
            stringBuilder.Append("!!!");//добавит в конец
            Console.WriteLine(stringBuilder);//some dynamic string!!!
            stringBuilder.Insert(0, "???");//добавит в начало
            Console.WriteLine(stringBuilder);//???some dynamic string!!!
            stringBuilder.Remove(8, 7);//c 8 позиции удалит 7 символов
            Console.WriteLine(stringBuilder);//???some  string!!!


            //СОЗДАТЬ МАТРИЦУ И ВЫВЕСТИ ЕЕ
            Random rand = new Random();//cоздание объекта для генерации чисел
            int[,] array = new int[4, 3];
            for (int ii = 0; ii < 4; ii++)
            {
                for (int jj = 0; jj < 3; jj++) {
                    array[ii, jj] = rand.Next(-10, 10);
                    Console.Write("{0}\t", array[ii, jj]);
                }
                Console.WriteLine();
            }

            //СОЗДАТЬ ОДНОМЕРНЫЙ МАССИВ СТРОК. ВЫВЕСТИ СОДЕРЖИМОЕ, ЕГО ДЛИНУ И ВЫВЕСТИ ЕЕ
            string[] diciplines = { "oop", "ksis", "composition","math"};
            for (int k = 0; k < diciplines.Length; k++) {
                Console.Write("{0}\t", diciplines[k]);
            }
            Console.WriteLine();
            Console.WriteLine(diciplines.Length);
            int indexofWordToChange = int.Parse(Console.ReadLine());
            string diciplineToChange = Console.ReadLine();
            diciplines[indexofWordToChange] = diciplineToChange; 
            for (int k = 0; k < diciplines.Length; k++)
            {
                Console.Write("{0}\t", diciplines[k]);
            }
            Console.WriteLine();


            //СОЗДАТЬ СТУПЕНЧАТЫЙ МАССИВ ВЕЩЕСТВ. ЧИСЕЛ С 3-мя строками, в каждой из которых
            //2, 3 и 4 столбцов соответственно. Значения массива введите с консоли.
            // Объявляем ступенчатый массив
            double[][] myArr = new double[3][];
            myArr[0] = new double[2];
            myArr[1] = new double[3];
            myArr[2] = new double[4];

            int q;
            // Инициализируем ступенчатый массив
            for (q = 0; q < 2; q++)
            {
                myArr[0][q] = double.Parse(Console.ReadLine());//вводить через запятую!
            }
            Console.WriteLine();
            for (q = 0; q < 3; q++)
            {
                myArr[1][q] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            for (q = 0; q < 4; q++)
            {
                myArr[2][q] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            for (q=0; q < 2; q++)
            {
                Console.Write("{0}\t", myArr[0][q]);
            }
            Console.WriteLine();
            for (q = 0; q < 3; q++)
            {
                Console.Write("{0}\t", myArr[1][q]);
            }
            Console.WriteLine();
            for (q = 0; q < 4; q++)
            {
                Console.Write("{0}\t", myArr[2][q]);
            }

            //Создайте неявно типизированные переменные для хранения массива и строки.
            var arrayy = new object[0];
            var strrr = "";

            var names = new[] { "lera", "nastya", "liza" }; //это не совсем то?


            //Задайте кортеж из 5 элементов с типами int, string, char, string, ulong
            (int age, string name, char gender, string status, ulong course) person= (19, "Lera",'F',"student", 2);
            //Console.WriteLine(person.age); 
            Console.WriteLine();
            Console.WriteLine(person);
            Console.WriteLine(person.Item1);
            Console.WriteLine(person.Item3);
            Console.WriteLine(person.Item4);

            //распаковка
            var (agee, namee, genderr, statuss, coursee) = person;

            (int age, string name, char gender, string status, ulong course) person1 = (20, "Lera", 'F', "student", 2);
            Console.WriteLine(person==person1);//false

            //Создайте локальную функцию в main и вызовите ее. Формальные параметры функции – массив целых и строка. 
            //Функция должна вернуть кортеж, содержащий: максимальный и минимальный элементы массива,
            //сумму элементов массива и первую букву строки.
            int[] arr = { 12, 3, 45, 6 };
            string textik = "blinbla";
            (int, int, int, char) GetValue(int[] arrCopy, string textikCopy)
            {
                return (arrCopy.Max(), arrCopy.Min(), arrCopy.Sum(), textikCopy[0]);
            }
            Console.WriteLine(GetValue(arr, textik));
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}



