namespace efcoreRestFull.DTOs;

public class ProductDTO
{
    public int id { get; set; }
    public int seq { get; set; }
    public string name { get; set; }
    public decimal price { get; set; }
    public int stock { get; set; }
    public string description { get; set; }
    public string imageUrl { get; set; }
    public string categoryName { get; set; }
    public int categoryId { get; set; }
}