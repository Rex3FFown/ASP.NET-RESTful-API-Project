namespace efcoreRestFull.DTOs;

public class BasketItemProductDTO
{
    public int id { get; set; }
    public int seq { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
    public string imageUrl { get; set; }
}