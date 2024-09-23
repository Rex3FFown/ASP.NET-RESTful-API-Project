using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineShoppingProject.Entities
{
    [Table("ma_order_items")]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("price")] public decimal Price { get; set; }
        [Column("count")] public int Count { get; set; }

        [ForeignKey("Order")]
        [Column("order_id")]

        public int OrderId { get; set; }

        [JsonIgnore] public virtual Order Order { get; set; }

        [Column("product_id")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Column("basket_id")]
        [ForeignKey("Basket")]
        public int? BasketId { get; set; }

        public virtual Basket Basket { get; set; }
    }
}