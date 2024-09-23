using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lombok.NET;

namespace OnlineShoppingProject.Entities
{
    [Table("baskets")]
    public class Basket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
[Column("customer_id")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; } = new HashSet<BasketItem>();
[Column("is_active")]
        public bool IsActive { get; set; }
    }
}
