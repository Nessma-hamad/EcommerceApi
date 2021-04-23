using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.DTO
{
    public class CategoryDto
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
    }

}
