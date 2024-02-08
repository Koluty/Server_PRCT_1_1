using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ipAddressString = "127.0.0.1"; // IP-адрес
            int port = 8888; // Порт

            IPAddress ipAddress = IPAddress.Parse(ipAddressString); // Перетворення строки у айпи адерсу
            IPEndPoint ipPoint = new IPEndPoint(ipAddress, port); // створення локальної точки

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipPoint);
            socket.Listen(1000); // Запуск прослуховування з розміром черги 1000

            Console.WriteLine("Сервер запущено. Очікування підключення");
            Socket client = socket.Accept();
            Console.WriteLine($"Адрес підключеного кліента: {client.RemoteEndPoint}");

            byte[] buffer = new byte[sizeof(double) * 3]; // буфер для зберігання даних
            client.Receive(buffer); // отримати дані від клієнта

            // Розшифрування отриманих даних у три числа типу double
            double[] receivedNumbers = new double[3];
            for (int i = 0; i < 3; i++)
            {
                receivedNumbers[i] = BitConverter.ToDouble(buffer, i * sizeof(double));
            }

            // Виведення отриманих чисел
            Console.WriteLine("Отримані числа:");
            foreach (double number in receivedNumbers)
            {
                Console.WriteLine(number);
            }

            Calculate calculate = new Calculate();
            double result = calculate.Calculate_formula(receivedNumbers[0], receivedNumbers[1], receivedNumbers[2]);
            Console.WriteLine(result);
            client.Send(BitConverter.GetBytes(result));
        }
    }
}
