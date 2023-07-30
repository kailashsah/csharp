using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.webapi.two.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "email is required")]
        public string UserName { get; set; }
       
        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
    }
}
