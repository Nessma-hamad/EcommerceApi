using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    [Table("Product")]
    public class Product
    {
        public int ID { get; set; }
        [Required, MinLength(3)]
        public string Name { get; set; }
        [MinLength(10), MaxLength(300)]
        public string Description { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
      
        
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
       
        public virtual string Color { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ICollection<Wishlist> WishLists { get; set; }

    }
}
