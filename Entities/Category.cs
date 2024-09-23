using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineShoppingProject.Entities
{
    [Table("ma_categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("seq")]
        public int Seq { get; set; }
        [Column("name")][MaxLength(255)]
        public string Name { get; set; }

        
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
