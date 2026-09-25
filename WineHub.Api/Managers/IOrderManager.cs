using WineHub.Api.Models;

namespace WineHub.Api.Managers;

public interface IOrderManager
{
    IEnumerable<Order> GetOrders();
    Order? GetOrder(int id);
}
