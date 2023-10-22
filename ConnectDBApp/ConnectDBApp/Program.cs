using ConnectDBApp;

using (HelloappContext db = new HelloappContext())
{
    var users = db.Users.ToList();
    Console.WriteLine("Users list: ");
    foreach (var user in users)
    {
        Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
    }
}