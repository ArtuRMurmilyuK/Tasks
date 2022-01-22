namespace CookerProxy;

public interface IChief
{
    IDictionary<int, string> GetStatuses();
    IEnumerable<Order> GetOrders();
}