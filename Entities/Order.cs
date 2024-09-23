using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineShoppingProject.Entities
{
    [Table("ma_orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("customer_id")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
[JsonIgnore]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}