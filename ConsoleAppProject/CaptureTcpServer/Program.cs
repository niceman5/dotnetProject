using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace CaptureTcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            RunServer();
            Console.ReadLine();
        }

        async static void RunServer()
        {
            int BUFF_SIZE = 1024;
            
            //TcpListener는 tcp연결을 받는 서버의 역할을 하기 때문에 IP와 포트를 담아 생성
            TcpListener listener = new TcpListener(IPAddress.Any, 9999);
            listener.Start();

            //async는 컴파일러에게 메서드에 await가 존재하는걸 알려줌.
            //await는 컴파일러가 해당 구문을 만나면 멈추지 않고 반복 메시지를 루프를 계속 돌도록 하는 역할.
            //즉 코드가 종료되지 않아도 그 다음 코드가 실행되게 함.(비동기 실행)
            while (true)
            {
                TcpClient tc = await listener.AcceptTcpClientAsync();
                NetworkStream stream = tc.GetStream();

                //데이터 수신 : 비동기로 클라이언트의 연결을 받아들이고 해당 연결 스트림을 가져와 
                //그 스트림에서 반복문을 거쳐 버퍼만큼 데이터를 가져온다.
                byte[] bytes = new byte[4];
                //nb에 데이터의 크기가 들어감. 
                //await stream.ReadAsync(bytes, 0, bytes.Length)는 stream에서 비동기로 bytes배열을 가져오는데 0에서 byte.Length만큼 가져옴.
                int nb = await stream.ReadAsync(bytes, 0, bytes.Length);

                if (nb != 4)
                {
                    throw new ApplicationException("invalid size");
                }
                int total = BitConverter.ToInt32(bytes, 0);

                //실제 데이터 수신
                string filename = Guid.NewGuid().ToString("N") + ".png";

                // using사용은 파일 close전에 프로그램 이상으로 종료시 close가 안되는 것을 방지하기 위해 using을 사용하여 
                // 자동으로 dispose메서드 호출하게 한다.
                using (var fs = new FileStream(filename, FileMode.CreateNew))
                {
                    var buff = new byte[BUFF_SIZE];
                    int recv_cnt = 0;
                    
                    // while문을 동작시키면서 버퍼만큼 1024바이트씩 데이터를 전송받는 과정. 만약 버퍼 크기보다 수신받을 데이터가 적을 경우
                    // 그 남은 데이터 양만큼 받게 하는 조건문
                    while (recv_cnt < total)
                    {
                        int n = total - recv_cnt >= BUFF_SIZE ? BUFF_SIZE : total - recv_cnt;
                        nb = await stream.ReadAsync(buff, 0, n);
                        recv_cnt += nb;

                        await fs.WriteAsync(buff, 0, nb);
                    }
                }

                byte[] result = new byte[1];
                result[0] = 1;
                await stream.WriteAsync(result, 0, result.Length);
                stream.Close();
                tc.Close();
            }
        }
    }
}
