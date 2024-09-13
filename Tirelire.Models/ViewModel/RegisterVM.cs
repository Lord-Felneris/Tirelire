using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tirelire.Models.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password",ErrorMessage ="Confirm Password don't match !")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Required]
        public string? ConfirmPassword { get; set; }
        public string? Role { get; set; }
        public IEnumerable<SelectListItem>? RoleList { get; set; }

    }


}
