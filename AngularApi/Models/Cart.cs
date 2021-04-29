using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    [Table("Cart")]
    public class Cart
    {
        public Cart()
        {
            CartProducts = new List<CartProduct>();
        }
        [Key, ForeignKey("User")]
        public string ID { get; set; }

        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual User User { get; set; }
    }
}
