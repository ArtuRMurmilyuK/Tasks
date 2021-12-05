using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessengerApp
{
    internal class Program
    {
        private static int port = 8005;
        static void Main(string[] args)
        {
            //получаем адресс для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                
            //создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listenSocket.Bind(ipPoint);

                listenSocket.Listen(10);

                Console.WriteLine("Сервер запущен. Ожидаем подключений...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    //получаем сообщение
                    while (true)
                    {
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0;
                        byte[] data = new byte[256];

                        do
                        {
                            bytes = handler.Receive(data);
                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));

                        } while (handler.Available > 0);

                        Console.WriteLine(DateTime.Now.ToShortTimeString() + ":" + builder.ToString());

                        Console.Write("Введите сообщение:");
                        string message = Console.ReadLine();
                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
