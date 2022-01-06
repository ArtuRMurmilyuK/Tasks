namespace LInQAndList
{
    internal class Program
    {
        static void Main()
        {
            var list = new ListOfParticipants();
            list.Add(21, "Popa", "Petrov");
            list.Add(18, "Edik", "Petrov");
            list.Add(20, "Artur", "Petrov");

            list.Show();
        }
    }
}
