using OnlineShoppingProject.Entities;

namespace efcoreRestFull.DTOs
{
    public class BasketItemDTO
    {
        public int id { get; set; }
        public int basketId { get; set; }
        public BasketItemProductDTO product { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

        
    }
}