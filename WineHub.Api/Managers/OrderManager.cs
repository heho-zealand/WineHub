using WineHub.Api.Models;
using WineHub.Api.Repositories;

namespace WineHub.Api.Managers;

public class OrderManager(IOrderRepository orderRepository) : IOrderManager
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    // The Manager is the application/use-case layer in this first version.
    // At this stage there is no complex orchestration yet.
    public IEnumerable<Order> GetOrders()
    {
        return _orderRepository.GetAll();
    }

    public Order? GetOrder(int id)
    {
        return _orderRepository.GetById(id);
    }
}
