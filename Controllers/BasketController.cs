using AutoMapper;
using efcoreRestFull.Context;
using efcoreRestFull.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Controllers;

[Route("api/baskets")]
public class BasketController:Controller
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public BasketController(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("customer/{customerId}")]
    public IActionResult GetBasketIdByCustomerId(int customerId)
    {
        var basket = _context.Baskets.Include(b => b.BasketItems).ThenInclude(p=>p.Product).Where(b => b.CustomerId == customerId )
            .SelectMany(b=>b.BasketItems)
            .ToList();
        /* SelectMany(b=>b.BasketItems.Select(bi=> new BasketItemDTO
            {
                id = bi.Id,
                basketId = bi.BasketId,
                product = bi.Product,
                price = bi.Price,
                quantity = bi.Quantity
               
            }))*/
        var basketDto = _mapper.Map<List<BasketItemDTO>>(basket);
        
        return Ok(basketDto);
    }
    
    
}