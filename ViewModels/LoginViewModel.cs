using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITRoots.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [MaxLength(30)]
        public string Password { get; set; }

        public bool IsActivated { get; set; } = false;
    }
}