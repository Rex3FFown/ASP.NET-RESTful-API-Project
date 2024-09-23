using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using efcoreRestFull.Entities;
using Microsoft.AspNetCore.Identity;

namespace OnlineShoppingProject.Entities
{
    [Table("ma_customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")] public string Name { get; set; }
        [Column("surname")] public string Surname { get; set; }
        [Column("address")] public string Address { get; set; }
        [Column("email")] public string Email { get; set; }
        [Column("password")] public string Password { get; set; }

        [ForeignKey("CustomerId")] public virtual ICollection<Role> Roles { get; set; } = new HashSet<Role>();

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        public virtual ICollection<CustomerRole> CustomerRoles { get; set; } = new HashSet<CustomerRole>();
    }
}
    
