using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class Wishlist
    {
        public Wishlist()
        {
            Products = new List<Product>();
        }
        public int ID { get; set; }
        [Key, ForeignKey("User")]
        public string UserID { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
