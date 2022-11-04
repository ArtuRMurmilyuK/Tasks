using BrainFuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BrainFuck
{
    internal class ControlUser
    {
        public static void CreateUser(string firstName, string username, int userId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //TODO: no username or firstname
                Users user = new Users { FirstName = firstName, Username = username, UserId = userId };

                // Add to db
                db.Users.Add(user);
                db.SaveChanges();
                Console.WriteLine("Объект успешно сохранены");
            }
        }
    }
}
