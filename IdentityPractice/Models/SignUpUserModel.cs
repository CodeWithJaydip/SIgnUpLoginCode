using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityPractice.Models
{
    public class SignUpUserModel

    { 
        [Required(ErrorMessage ="Please enter your email")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [Compare("ConfirmPassword",ErrorMessage ="Password does not match")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm password is required")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }


    }
}
