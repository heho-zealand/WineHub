using WineHub.Api.Models;

namespace WineHub.Api.Repositories;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();
    Order? GetById(int id);
}
