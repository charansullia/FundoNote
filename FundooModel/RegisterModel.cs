using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModel
{
  public class RegisterModel
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+([.#_$+-][a-zA-Z0-9]+)*[@][a-zA-Z0-9]+[.][a-zA-Z]{2,3}([.][a-zA-Z]{2})?$", ErrorMessage = "E-mail is not valid.Please enter valid email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.?[A-Z])(?=.?[a-z])(?=.?[0-9])(?=.?[#?!@$ %^&*-]).{8,}$")]
        public string Password { get; set; }
    }
}
