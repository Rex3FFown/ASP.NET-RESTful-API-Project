using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShoppingProject.Entities;

namespace efcoreRestFull.Entities;

[Table("customer_role")]
public class CustomerRole
{
    [Key][Column("id")] public int Id { get; set; }
    [Column("customer_id")] public int CustomerId { get; set; }
    [Column("role_id")] public long RoleId { get; set; }
 
    [ForeignKey("RoleId")] public Role Role { get; set; }
    [ForeignKey("CustomerId")] public Customer Customer { get; set; }
}