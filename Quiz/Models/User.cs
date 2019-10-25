using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections;


namespace Quiz.Models
{
    public class User 
    {
        [Key]
        public int UserId { get; set; }
        [Display (Name = "First Name")]
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(50, ErrorMessage = "The name must be shorter than {1} characters.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(50, ErrorMessage = "The name must be shorter than {1} characters.")]
        public string LastName { get; set; }
        [Display( Name ="Age")]
        public int UserAge { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter a valid password")]
        [StringLength(50, ErrorMessage = "Password can not be more than {1} characters.")]
        public string Password { get; set; }
        public int DataScore { get; set; }
    }
}