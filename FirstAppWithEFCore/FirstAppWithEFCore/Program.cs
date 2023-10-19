using FirstAppWithEFCore;

using (ApplicationContext db = new ApplicationContext())
{
    User tom = new User { Name = "Tom", Age = 33};
    User alice = new User { Name = "Alice", Age = 24 };

    db.Users.Add(tom);
    db.Users.Add(alice);
    db.SaveChanges();

    Console.WriteLine("Object added successfully");
    
    var users = db.Users.ToList();
    Console.WriteLine("Object list: ");
    foreach (User user  in users)
    {
        Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
    }
}