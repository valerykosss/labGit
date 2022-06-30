using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    //делегаты
    public delegate void Upgrade(string info);
    public delegate int Work(int info);
    delegate int LengthLogin(string s);
    delegate bool BoolPassword(string s1, string s2);
    public class User
    {
        //события
        public event Upgrade UpgradeEvent;
        public event Work WorkEvent;
        public string version;
        public object date;
        private int time;
        public int Time
        {
            get => time;
            set { time = value; }
        }
        public void VersionIsOutOfDate(string oldVersion)
        {
            UpgradeEvent?.Invoke($"{oldVersion} is out-of-date!");
        }
        public void Message(string message)
        {
            UpgradeEvent?.Invoke($"You got a new message: {message}");
        }
        public void EnterPassword(string password)
        {
            LengthLogin lengthLoginDelegate = s => s.Length;
            int lengthLogin = lengthLoginDelegate(password);
            if (lengthLogin <= 3)
            {
                UpgradeEvent?.Invoke("Password should contain more than 3 symbols");
            }
            else UpgradeEvent?.Invoke("Password is correct!");
        }
        public void NewVersion(string newVersion, object timeOfUpdate)
        {

            UpgradeEvent?.Invoke($"New version {newVersion}  is updated on { timeOfUpdate}");

        }
        public void TimeWorking(int workingTime)
        {
            Time = WorkEvent.Invoke(workingTime);
            Console.WriteLine($"User has worked for {Time} hours");
        }
    }
    public class Operation
    {
        //public static string ToUpperStr(string stringToUpperCase)
        //{
        //    Console.WriteLine("\nString to Upper Case: ");
        //    return stringToUpperCase.ToUpper();
        //}
        //public static string ToLowerStr(string stringToLowerCase)
        //{
        //    Console.WriteLine("\nString to Lower Case");
        //    return stringToLowerCase.ToLower();
        //}
        public static string DeleteSpacesInString(string stringToDeleteSpaces)
        {
            Console.WriteLine("\nDelete spaces in a string");
            return stringToDeleteSpaces.Replace(" ", "");
        }
        public static string DeletePunctuationInString(string stringWithPunctuation)
        {
            Console.WriteLine("\nDelete punctuation in a string");
            StringBuilder sb = new StringBuilder();
            foreach (char c in stringWithPunctuation)
            {
                if (!char.IsPunctuation(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
    public class Show
    {
        public void ShowTextOnDisplayLower(String text)
        {
            // выводим текст на экран для Action
            Console.WriteLine($"Now it's lower: {text}");
        }
        public void ShowTextOnDisplayUpper(String text)
        {
            // выводим текст на экран для Action
            Console.WriteLine($"Now it's upper: {text}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User firstUser = new User();
            firstUser.UpgradeEvent += DisplayMessage;//обработчик для события 
            firstUser.VersionIsOutOfDate("--First user's software: Adobe Illustrator--");
            firstUser.date = DateTime.Now;
            firstUser.Message("--Don't forget to update your software--");
            Console.Write("Enter the version you want software to be updated: ");
            firstUser.version = Console.ReadLine();
            firstUser.NewVersion(firstUser.version, firstUser.date);
            firstUser.EnterPassword("121");
            firstUser.EnterPassword("goodpassword");
            firstUser.WorkEvent += IncrementWorkingHours;
            firstUser.TimeWorking(firstUser.Time);
            firstUser.TimeWorking(firstUser.Time);
            firstUser.TimeWorking(firstUser.Time);
            firstUser.WorkEvent += DecrementWorkingHours;
            firstUser.TimeWorking(firstUser.Time);
            Console.WriteLine();
            Console.WriteLine();

            User secondUser = new User();
            secondUser.UpgradeEvent += DisplayMessage;
            secondUser.VersionIsOutOfDate("--Second user's software: CorelDraw--");
            secondUser.date = DateTime.Now;
            firstUser.Message("--Don't forget to update your software--");
            Console.Write("Enter the version you want software to be updated: ");
            secondUser.version = Console.ReadLine();
            secondUser.NewVersion(secondUser.version, secondUser.date);
            //secondUser.EnterPassword("greatpassword");
            Console.Write("Enter password: ");
            string password1 = Console.ReadLine();
            Console.Write("Repeat password: ");
            string password2 = Console.ReadLine();
            // Используем лямбда выражение
            BoolPassword bp = (s1, s2) => s1 == s2;
            if (bp(password1, password2))
            {
                secondUser.EnterPassword(password1);
            }
            else
                Console.WriteLine("Passwords are not the same");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Enter string(toUpper, toLower)");
            String str1 = Console.ReadLine();
            //Action
            Show show = new Show();
            ToUpperStr(str1,show.ShowTextOnDisplayUpper);
            ToLowerStr(str1, show.ShowTextOnDisplayLower);

            Console.WriteLine();
            Console.WriteLine("Enter sentence with punctuation and spaces");
            String str2 = Console.ReadLine();

            //Func
            Func<string, string> strForEveryMethod = Operation.DeletePunctuationInString;
            Console.WriteLine(strForEveryMethod(str2));
            strForEveryMethod = Operation.DeleteSpacesInString;
            Console.WriteLine(strForEveryMethod(str2));
            Console.ReadKey();
        }
        private static void ToUpperStr(string stringToUpperCase, Action<string> showMethod)//тк void
        {
            Console.WriteLine("\nString to Upper Case: ");
            string newString;
            newString=stringToUpperCase.ToUpper();
            showMethod(newString.ToString());
        }
        private static void ToLowerStr(string stringToLowerCase, Action<string> showMethod)
        {
            Console.WriteLine("\nString to Lower Case");
            string newString;
            newString = stringToLowerCase.ToLower();
            showMethod(newString.ToString());
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        private static int IncrementWorkingHours(int i)
        {
            return ++i;
        }
        private static int DecrementWorkingHours(int i)
        {
            return --i;
        }
    }
}