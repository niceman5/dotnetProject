using System;

namespace FileSaveLoadJson
{
    class Program
    {
        static void Main(string[] args)
        {

            fileSaveJson(@"C:\00.Dev\VSTestProject\WindowsFormsProject\FileSaveLoadJson\test.json");
            Console.ReadLine();
        }


        static void fileSaveJson( string fileName)
        {
            spList[] list = {
                                new spList() { dirInfo = @"C:\", spName = @"aaa.sql",  result = "" },
                                new spList() { dirInfo = @"C:\", spName = @"bbb.sql",  result = "" }
            };
            Console.WriteLine(list);



        }

    }

    public class spList
    {
        public string dirInfo { get; set; }
        public string spName { get; set; }
        public DateTime applyTime { get; set; }
        public string result { get; set; }

    }
}
