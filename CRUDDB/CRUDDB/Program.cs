// Add
using CRUDDB;

using (ApplicationContext db = new ApplicationContext())
{
    User tom = new User { Name = "Tom", Age = 33 };
    User alice = new User { Name = "Alice", Age = 21 };

    db.Add(tom);
    db.Add(alice);
    db.SaveChanges();
}

// Receiving
using (ApplicationContext db = new ApplicationContext())
{
    var users = db.Users.ToList();
    Console.WriteLine("Data after adding:");
    foreach (var user in users)
    {
        Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
    }
}

// Editing
using (ApplicationContext db = new ApplicationContext())
{
   User? user = db.Users.FirstOrDefault();
    if( user != null)
    {
        user.Name = "Bob";
        user.Age = 21;
        db.SaveChanges();
    }

    Console.WriteLine("\nData after adding:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

// Delete
using (ApplicationContext db = new ApplicationContext())
{
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        db.Users.Remove(user);
        db.SaveChanges();
    }

    Console.WriteLine("\nData after delete:");
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}