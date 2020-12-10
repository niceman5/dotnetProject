using System;
using System.IO;
using System.Text;

namespace ConsoleAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string str = Console.ReadLine();

            StreamWriter st = new StreamWriter(@"C:\00.Dev\VSTestProject\ConsoleAppProject\Files\test01.txt", false, Encoding.Default);
            st.WriteLine(str);
            st.Close();

            StreamReader sr = new StreamReader(@"C:\00.Dev\VSTestProject\ConsoleAppProject\Files\test01.txt");
            Console.WriteLine( sr.ReadLine());
            sr.Close();
        }
    }
}
