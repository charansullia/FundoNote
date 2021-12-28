using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundooModel
{
  public class ForgetModel
    {
        [Required]
        public string Email { get; set; }
    }
}
