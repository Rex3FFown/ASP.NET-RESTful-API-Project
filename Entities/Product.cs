using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineShoppingProject.Entities
{
    [Table("ma_products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("seq")] public int Seq { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("price")] public decimal Price { get; set; }
        [Column("stock")] public int Stock { get; set; }

        [Column("description", TypeName = "nvarchar(max)")]

        public string Description { get; set; }

        [Column("image_url", TypeName = "nvarchar(1000)")]

        public string ImageUrl { get; set; }

        [ForeignKey("Category")]
        [Column("category_id")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; } = new HashSet<BasketItem>();
    }
}