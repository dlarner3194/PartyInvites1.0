using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
  public class GuestResponse
  {
    [Required(ErrorMessage = "Please enter your name")]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your email address")]
    [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter your phone number")]
    [Display(Name = "Phone Number")]
    [RegularExpression("^\\(?([0-9]{3})\\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Please specify whether you'll attend")]
    public bool? WillAttend { get; set; }
  }
}
