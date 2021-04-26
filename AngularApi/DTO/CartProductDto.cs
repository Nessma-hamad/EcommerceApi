using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.DTO
{
    public class CartProductDto
    {
        public int ID { get; set; }
        public int Quantity { get; set; }

        
        public string CartID { get; set; }
       
       
        public int ProductID { get; set; }
      
    }
}
