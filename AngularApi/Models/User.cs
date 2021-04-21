using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Wishlist WishList { get; set; }
      
        public virtual ICollection<Order> Orders { get; set; }
    }
}
