using ITRoots.Views.Shared;
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
        [Display(Name = "Email", ResourceType = typeof(SiteResource))]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [MaxLength(30)]
        [Display(Name = "Password", ResourceType = typeof(SiteResource))]
        public string Password { get; set; }

      
        public bool IsActivated { get; set; } = false;
    }
}