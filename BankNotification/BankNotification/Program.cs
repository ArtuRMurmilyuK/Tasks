using System;

namespace BankNotification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(200);
            // Добавляем в делегат ссылку на методы
            account.RegisterHandler(PrintSimpleMessage);
            account.RegisterHandler(PrintColorMessage);
            // Два раза подряд пытаемся снять деньги
            account.Take(100);
            account.Take(150);

            // Удаляем делегат
            account.UnregisterHandler(PrintColorMessage);
            // снова пытаемся снять деньги
            account.Take(50);
        }

        private static void PrintColorMessage(string message)
        {
            // Устанавливаем красный цвет символов
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            // Сбрасываем настройки цвета
            Console.ResetColor();
        }

        static void PrintSimpleMessage(string message) => Console.WriteLine(message);
    }
}
