using All;
using DataModel.Standard;
using System;

namespace AttacheFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("첨부파일 관리자");
            //데이터베이스 연결 문자열
            //Data Source=(localdb)\v11.0;Initial Catalog=dev;Integrated Security=True;
            AddTest();
        }

        private static void AddTest()
        {
            var repo = new AttacheFileRepository();
            var model = new AttacheFileModel() { UserId=5, BoardId=4, ArticleId=1, FileName="photo.png", FileSize=1024 };
            
            repo.Add( model );
        }
    }
}