using System;
using System.Collections.Generic;
using System.Linq;
using CollectionOfMonths.Models;

namespace CollectionOfMonths
{
    internal class Program
    {
        static void Main()
        {
            var calendar = new Calendar();
            calendar.ShowByAmountOfDay(17);
            calendar.ShowBySerialNumber(3);
            
        }
    }
    
    internal class Calendar
    {
        List<Month> _calendar = new List<Month>();
        public Calendar()
        {
            _calendar = new List<Month> { 
                new Month { Name = "January", AmountOfDays = 31, SerialNumber = 1 } ,
                new Month { Name = "February", AmountOfDays = 28, SerialNumber = 2 } ,
                new Month { Name = "March", AmountOfDays = 31, SerialNumber = 3 } ,
                new Month { Name = "April", AmountOfDays = 30, SerialNumber = 4 } ,
                new Month { Name = "May", AmountOfDays = 31, SerialNumber = 5 } ,
                new Month { Name = "June", AmountOfDays = 30, SerialNumber = 6 } ,
                new Month { Name = "July", AmountOfDays = 31, SerialNumber = 7 } ,
                new Month { Name = "August", AmountOfDays = 31, SerialNumber = 8 } ,
                new Month { Name = "September", AmountOfDays = 30, SerialNumber = 9 } ,
                new Month { Name = "October", AmountOfDays = 31, SerialNumber = 10 } ,
                new Month { Name = "November", AmountOfDays = 30, SerialNumber = 11 } ,
                new Month { Name = "December", AmountOfDays = 31, SerialNumber = 12 } ,
            };
        }
        public void ShowBySerialNumber(int num)
        {
            if (num > 0 && num <= 12)
            {
                var month = _calendar.Where(x => x.SerialNumber == num);
                foreach (var nameOfMonth in month)
                {
                    Console.WriteLine($"{ nameOfMonth.Name} has {nameOfMonth.AmountOfDays} days.");
                }
            }
            else
            {
                Console.WriteLine("Error, there is no such month");
            }
        }
        public void ShowByAmountOfDay(int num)
        {
            if (num > 0 && num <= 31)
            {
                var month = _calendar.Where(x => x.AmountOfDays >= num);
                foreach (var nameOfMonth in month)
                {
                    Console.WriteLine($"{ nameOfMonth.Name} has {nameOfMonth.AmountOfDays} days.");
                }
            }
            else
            {
                Console.WriteLine("Error, there is no such month");
            }
        }
    }
}
