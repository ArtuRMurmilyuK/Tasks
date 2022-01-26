using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] emails = 
            { 
                "johndoe@jooble.com", 
                "john+doe@jooble.com", 
                "john+doe@joo.ble.com", 
                "johndoe@jooble.com", 
                "john.doe.+jane.doe@jooble.com"
            };

            Console.WriteLine($"Количество подходящих майлов: {SuitableEmail(emails).Length}");
        }

        private static IEnumerable<string> RemoveIndex(string[] emails)
        {
            string[] newEmail = new string[emails.Length];

            for (int i = 0; i < emails.Length; i++)
            {
                newEmail[i] = emails[i].Remove(emails[i].IndexOf('@'));
                newEmail[i] = newEmail[i].Replace("+", "");
                newEmail[i] = newEmail[i].Replace(".", "");
                newEmail[i] += "@jooble.com";
            }

            return newEmail;
        }

        private static string[] SuitableEmail(string[] emails)
        {
            return RemoveIndex(emails).Distinct().ToArray();
        }
    }
}
