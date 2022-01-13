using System;

namespace WeatherEvent
{
    internal class Program
    {
        static void Main()
        {
            var user1 = new User() {LastName = "MIlka", Name = "petro"};
            user1.EnableNotifications();
            user1.Show();
        }
    }

    public class WeatherApp
    {
        public delegate string NotifyDelegate();
        public event NotifyDelegate NotifyEvent;
        private int _temp;

        public WeatherApp()
        {
            Random rnd = new Random();
            _temp = rnd.Next(10);
        }
        public void EnableNotifications()
        {
            NotifyEvent += Notify;
        }
        public string Notify()
        {
            return $"Температура сегодня {_temp}";
        }

        public void Invoke()
        {
            Console.WriteLine( NotifyEvent.Invoke());
        }

        public void Dispose()
        {
            NotifyEvent -= Notify;
        }
    }
    public class User
    {
        private readonly WeatherApp _weather;
        public string Name { get; set; }
        public string LastName { get; set; }

        
        public User()
        {
            _weather = new WeatherApp();
        }

        public void EnableNotifications()
        {
            _weather.EnableNotifications();
        }

        public void Show()
        {
           _weather.Invoke();
        }

        public void OffNotifications()
        {
            _weather.Dispose();
        }
    }
}
