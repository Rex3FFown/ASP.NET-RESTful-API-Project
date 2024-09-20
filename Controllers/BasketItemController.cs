using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using efcoreRestFull.Context;
using efcoreRestFull.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Controllers
{
    [Route("api/basketitems")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly DataContext _context;

        public BasketItemController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("addItem/{productId}/{basketId}")]
        public IActionResult AddItem(int productId, int basketId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            BasketItem basketItem = new BasketItem
            {
                BasketId = basketId,
                ProductId = productId,
                Quantity = 1,
                Price = product.Price
            };
            _context.BasketItems.Add(basketItem);
            _context.SaveChanges();
            return Ok(basketItem);
        }

        [HttpPut("{basketItemId}")]
        public IActionResult updateQuantity([FromRoute] int basketItemId, [FromBody] UpdateQuantityRequest request)
        {
            BasketItem basketitem = _context.BasketItems.Find(basketItemId);
            if ( request.NewQuantity<= 0)
            {
                _context.BasketItems.Remove(basketitem);
                return Ok("ok");
            }

            basketitem.Quantity = request.NewQuantity;
            _context.SaveChanges();
            return Ok(basketitem);
        }

        [HttpDelete("{basketItemId}")]
        public IActionResult deleteItem([FromRoute] int basketItemId)
        {
            BasketItem basketItem = _context.BasketItems.Find(basketItemId);
            _context.BasketItems.Remove(basketItem);
            _context.SaveChanges();
            return Ok(basketItem);
        }
    }
}