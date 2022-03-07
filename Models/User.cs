using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITRoots.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
   
        
        public string UserName { get; set; }

        
        public string Email { get; set; }

       
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

      
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool IsActivated { get; set; } = false;

    }
}