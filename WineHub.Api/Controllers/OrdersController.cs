using Microsoft.AspNetCore.Mvc;
using WineHub.Api.Managers;
using WineHub.Api.Models;

namespace WineHub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(IOrderManager orderManager) : ControllerBase
{
    private readonly IOrderManager _orderManager = orderManager;

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetOrders()
    {
        var orders = _orderManager.GetOrders();
        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Order> GetOrder(int id)
    {
        var order = _orderManager.GetOrder(id);

        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }
}
