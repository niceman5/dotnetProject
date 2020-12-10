using System;
using System.Diagnostics;

namespace ProcessCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("번호를 입력하세요." + Environment.NewLine + "1번 : 전체 프로세스 / 2번 : 개별 프로세스");
            
            string procType = Console.ReadLine();

            if(procType == "1")
            {
                try
                {
                    Process[] allProc = Process.GetProcesses();
                    int procCnt = 1;
                    Console.WriteLine("----------- 모든 프로세스 정보 -----------");
                    Console.WriteLine("현재 실행중인 모든 프로세스 숫자 : {0}", allProc.Length);

                    foreach(Process p in allProc)
                    {
                        try
                        {
                            Console.WriteLine("{0} 번째 프로세스명 : {1} ", procCnt++, p.ProcessName);
                            WriteProcessInof(p);
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(ex.StackTrace);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine( ex.Message );
                    Console.WriteLine( ex.StackTrace);
                }
            }
            else if(procType == "2")
            {
                Console.WriteLine("프로세스의 이름을 입력하세요.");
                string pName = Console.ReadLine();

                foreach(var process in Process.GetProcessesByName(pName))
                {
                    WriteProcessInof(process);
                }
            }
            else
            {

            }
        }

        private static void WriteProcessInof(Process p)
        {
            Console.WriteLine("Process : {0}", p.ProcessName);
            Console.WriteLine("Process 시작시간 : {0}", p.StartTime);
            Console.WriteLine("Process Id: {0}", p.Id);
            Console.WriteLine("메모리: {0}", p.VirtualMemorySize64);
            Console.WriteLine("Process Path: {0}", p.MainModule.FileName);
        }        
    }
}
