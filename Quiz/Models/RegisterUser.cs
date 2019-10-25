using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class RegisterUser
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }

        [Required]
        [Display (Name = "User Role")]
        public string UserRole { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation does not match")]
        public string ConfirmPassword { get; set; }

        public int DataScore { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; internal set; }
    }
}