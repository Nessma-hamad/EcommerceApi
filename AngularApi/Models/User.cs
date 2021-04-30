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
        //public User()
        //{
        //    Cart = new Cart();
        //}
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Email { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "date")]
        public DateTime BirthDay { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Wishlist WishList { get; set; }
      
        public virtual ICollection<Order> Orders { get; set; }
    }
}
