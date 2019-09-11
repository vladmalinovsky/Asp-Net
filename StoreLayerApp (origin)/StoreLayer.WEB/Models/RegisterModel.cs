using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreLayer.WEB.Models
{
    public class RegisterModel
    {
            public string Email { get; set; }
            
            [DataType(DataType.Password)]
            public string Password { get; set; }
            
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }
            
            public string FirstName { get; set; }
            
            public string LastName { get; set; }

    }
}