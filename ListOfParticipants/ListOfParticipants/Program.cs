using Microsoft.EntityFrameworkCore;

namespace ListOfParticipants
{
    internal class Program
    {
        static void Main()
        {
        }
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class AppContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb; Database=ParticipantsDB; Trusted_Connection=True");
        }
    }
}
