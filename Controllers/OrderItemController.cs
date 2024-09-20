using efcoreRestFull.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Controllers;

[Route("orderitem")]
public class OrderItemController : Controller
{
    private readonly DataContext _context;

    public OrderItemController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("{orderId}")]
    public async Task<ActionResult> GetOrderItem(int orderId)
    {
        var orderItems = await _context.OrderItems.Include(i => i.Order).Where(o => o.OrderId == orderId)
            .FirstOrDefaultAsync();
        return Ok(orderItems);
    }
}