using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

            socket.Bind(ep);
            socket.Listen(10);      //한번에 연결할수 있는 최대 갯수

            Socket clientSocket = socket.Accept();

            Console.WriteLine("Client연결 대기중.............");

            int nRecv = 0;
            //key가 눌리지 않으면 실행
            while (!Console.KeyAvailable)
            {
                byte[] buff = new byte[2048];
                nRecv = clientSocket.Receive(buff); //수신한 바이트
                
                string result = Encoding.UTF8.GetString(buff, 0, nRecv);    //수신한 길이만큼 string을 result에 넣는다.

                Console.WriteLine(result);
            }
        }
    }
}
