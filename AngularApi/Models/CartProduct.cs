using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    [Table("CartProduct")]
    public class CartProduct
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Cart")]
        public string CartID { get; set; }
        public virtual Cart Cart { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

    }
}
