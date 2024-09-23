using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using efcoreRestFull.Entities;
using Microsoft.AspNetCore.Identity;

namespace OnlineShoppingProject.Entities
{
    [Table("roles")]
    public class Role 
    {
       [Key] [Column("id")] public long Id { get; set; }
        [Column("active")] public bool Active { get; set; }
        [Column("role_name")]public string RoleName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        public virtual ICollection<CustomerRole> CustomerRoles { get; set; } = new HashSet<CustomerRole>();
    }
}