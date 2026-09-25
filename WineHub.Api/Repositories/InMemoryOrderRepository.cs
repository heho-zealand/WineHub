using WineHub.Api.Models;

namespace WineHub.Api.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    // Stage 1 deliberately uses a static in-memory list.
    // Later this class can be replaced by an EF Core/SQL Server implementation.
    private readonly List<Order> _orders =
    [
        new Order
        {
            Id = 1,
            CustomerName = "Restaurant Havfruen",
            OrderDate = new DateTime(2026, 9, 20),
            Total = 1245.50m,
            Status = "Confirmed"
        },
        new Order
        {
            Id = 2,
            CustomerName = "Café Central",
            OrderDate = new DateTime(2026, 9, 21),
            Total = 875.00m,
            Status = "Pending"
        },
        new Order
        {
            Id = 3,
            CustomerName = "Bistro Nord",
            OrderDate = new DateTime(2026, 9, 22),
            Total = 2150.75m,
            Status = "Shipped"
        }
    ];

    public IEnumerable<Order> GetAll() => _orders;

    public Order? GetById(int id) =>
        _orders.FirstOrDefault(order => order.Id == id);
}
