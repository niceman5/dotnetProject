using System;
using System.IO;

namespace FileCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("검색할 경로를 입력하세요.");
            string result1 = Console.ReadLine();
            Console.WriteLine("파일 확장자를 입력하세요.");
            string result2 = Console.ReadLine();
            FileHandle f1 = new FileHandle();
            
            f1.FileCheck(result1, result2);
        }
    }

    class FileHandle
    {
        public void FileCheck(string path, string file )
        {
            //string[] dirs = Directory.GetDirectories(path, $"*", SearchOption.AllDirectories);
            // $"" 문자열 보관기법 file은 확장자가 됨
            string[] files = Directory.GetFiles(path, $"*.{file}", SearchOption.AllDirectories);

            //Environment.NewLine 한줄띄우기...
            Console.WriteLine("-----------------------------" + Environment.NewLine);

            foreach(string a in files)
            {
                FileInfo file1 = new FileInfo(a);

                //파일의 크기가 1000이상이면
                if (file1.Length > 1000)
                {
                    Console.WriteLine(file1.Name);
                    Console.WriteLine(file1.FullName);
                    Console.WriteLine(file1.DirectoryName);
                    Console.WriteLine(file1.Length);
                }                
            }
        }
    }
}
