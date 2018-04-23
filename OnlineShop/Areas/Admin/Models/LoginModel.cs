using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="hãy nhập Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "hãy nhập Password")]
        public string Password { get; set; }

        public string Remember { get; set; }


    }
}