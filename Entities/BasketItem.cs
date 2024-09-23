using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineShoppingProject.Entities
{
    
    [Table("basket_items")]
    public class BasketItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("basket_id")]
        [ForeignKey("Basket")]

        public int BasketId { get; set; }

        [JsonIgnore] 
        public virtual Basket Basket { get; set; }

        [Column("product_id")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        [Column("quantity")] public int Quantity { get; set; }
        [Column("price")] public decimal Price { get; set; }
    }
}