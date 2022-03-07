using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITRoots.ViewModels
{
    public class RegisterViewModel
    {
        
        [Required(ErrorMessage = "User name is Required.")]
        [Display(Name = "User Name")]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is Required.")]
        [Display(Name = "First Name")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Required.")]
        [Display(Name = "Last Name")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [RegularExpression("^(?=.*?[A-Z]).{8,}$"
            , ErrorMessage = "Password minimum eight length, At least one uppercase English letter")]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confiramtion Password is Required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}