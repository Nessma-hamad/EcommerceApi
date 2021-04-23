using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.DTO
{
    public class ProductDto
    {
        public int ID { get; set; }
       
        public string Name { get; set; }
        
        public string Description { get; set; }
        public int Rate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
       
        public string Image { get; set; }


       
        public int CategoryID { get; set; }
      

        public virtual string Color { get; set; }
      

    }
}
