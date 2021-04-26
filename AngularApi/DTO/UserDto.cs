using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.DTO
{
    public class UserDto
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Image { get; set; }
        
        public DateTime BirthDay { get; set; }
        [Required]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
