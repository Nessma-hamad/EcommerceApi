using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class Order
    {
        public int ID { get; set; }
        [ForeignKey("User")]
        public string UsertID { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public double CouponDiscount { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double NetPrice
        {
            get { return TotalPrice - CouponDiscount; }
            private set { }
        }
        public int ItemsCount { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
