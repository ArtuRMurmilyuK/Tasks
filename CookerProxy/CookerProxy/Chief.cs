namespace CookerProxy;

public class Chief : IChief
{
    public IDictionary<int, string> GetStatuses()
    {
        Dictionary<int, string> statuses = new()
        {
            {1, "ready"},
            {2, "not ready"},
            {3, "preparing"}
        };

        Thread.Sleep(2000);
        return statuses;
    }

    public IEnumerable<Order> GetOrders()
    {
        List < Order > orders = new()
        {
            new Order() {Name = "Burger", StatusId = RandomStatus()},
            new Order() {Name = "Pasta", StatusId = RandomStatus()},
            new Order(){Name = "Omelet", StatusId = RandomStatus ()}
        };

        return orders;
    }

    private static int RandomStatus() => new Random().Next(1, 4);
}