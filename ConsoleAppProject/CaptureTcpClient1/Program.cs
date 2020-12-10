using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// .net core가 아니라 .net framework으로 시작...이미지 처리에서 core에서 안되서...
/// </summary>
namespace CaptureTcpClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            int BUFF_SIZE = 1024;
            string server_ip = "127.0.0.1";
            int port = 9999;

            TcpClient tc = new TcpClient(server_ip, port);

            //이미지 Capture할 변수
            Bitmap bmp = ScreenCaputre();

            var imgconv = new ImageConverter();

            //이미지 컨버터 클래스형 인스턴스를 생성하여 이미지 컨버터 클래스에 정의된 컨버팅 메서드를 사용해
            //bitmap파일을 byte배열로 변환
            byte[] imgbytes = (byte[])imgconv.ConvertTo(bmp, typeof(byte[]));
            byte[] nbytes = BitConverter.GetBytes(imgbytes.Length);     //이미지 길이를 바이트로...길이가 4인 바이트 배열리턴...

            using (NetworkStream stream = tc.GetStream())
            {
                //데이터 크기 전달
                stream.Write(nbytes, 0, nbytes.Length);

                //실제 데이터 전달
                int end = imgbytes.Length;
                int start = 0;

                while (start < end)
                {
                    int n = end - start >= BUFF_SIZE ? BUFF_SIZE : end - start;
                    stream.Write(imgbytes, start, n);
                    start += n;
                }

                //결과 수신
                byte[] result = new byte[1];
                stream.Read(result, 0, result.Length);
                Console.WriteLine(result[0]);

            }
            tc.Close();
        }

        //화면 캡쳐실행
        // static 를 붙이면 class의 인스턴스를 생성안해도 실행가능
        static Bitmap ScreenCaputre()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            Bitmap scrbmp = new Bitmap(rect.Width, rect.Height);

            using (Graphics g = Graphics.FromImage(scrbmp))
            {
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, scrbmp.Size, CopyPixelOperation.SourceCopy);
            }
            return scrbmp;
        }
    }
}
