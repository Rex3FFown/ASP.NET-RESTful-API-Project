using AutoMapper;
using efcoreRestFull.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Controllers;

[Route("orders")]
public class OrderController : Controller
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public OrderController(DataContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet("{customerId}")]
    public async Task<ActionResult> GetCustomerOrders(int customerId)
    {
        var orderId = await _context.Orders.Include(o => o.OrderItems).ThenInclude(p => p.Product)
            .ThenInclude(c => c.Category).Where(o => o.CustomerId == customerId).ToListAsync();
        return Ok(orderId);
    }

    [HttpPost("{customerId}")]
    public IActionResult addnewOrder(int customerId)
    {
        var customer = _context.Customers.Find(customerId);
        var basketId = _context.Baskets.Where(b => b.CustomerId == customerId).Select(p => p.Id).FirstOrDefault();
    
        var order = new Order
        {
            Customer = customer,
            Date = DateTime.UtcNow,
            CustomerId = customerId
        };

        _context.Orders.Add(order);
        _context.SaveChanges();

        var basketItems = _context.BasketItems.Include(p => p.Product).Where(b => b.BasketId == basketId).ToList();

        foreach (var basketItem in basketItems)
        {
            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = basketItem.Product.Id,
                Price = basketItem.Price,
                Count = basketItem.Quantity,
                BasketId = basketId
            };

            _context.OrderItems.Add(orderItem);

            var itemToRemove = _context.BasketItems.FirstOrDefault(b => b.Id == basketItem.Id);
            _context.BasketItems.Remove(itemToRemove);
        }

        _context.SaveChanges();

        return Ok(order);
    }

}